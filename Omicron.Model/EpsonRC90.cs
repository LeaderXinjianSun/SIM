using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb;
using SxjLibrary;
using ViewROI;
using HalconDotNet;
using System.IO;
using System.Diagnostics;
using System.Data;
using 臻鼎科技OraDB;

namespace Omicron.Model
{
    public class EpsonRC90
    {
        #region 属性
        public string IP { set; get; } = "192.168.1.2";
        public int TestSentPort { set; get; } = 2000;
        public int TestReceivePort { set; get; } = 2001;
        public int IOReceivePort { set; get; } = 2007;
        public int TestSentFlexPort { set; get; } = 2004;
        public int TestReceiveFlexPort { set; get; } = 2005;
        public int MsgReceivePort { set; get; } = 2002;
        public int CtrlPort { set; get; } = 5000;
        public bool TestSendStatus { get; set; } = false;
        public bool TestSendFlexStatus { get; set; } = false;

        public bool TestReceiveStatus { get; set; } = false;
        public bool TestReceiveFlexStatus { get; set; } = false;
        public bool MsgReceiveStatus { get; set; } = false;
        public bool IOReceiveStatus { get; set; } = false;
        public bool CtrlStatus { set; get; } = false;
        public double Coord_X { set; get; } = 0;
        public double Coord_Y { set; get; } = 0;
        public double Coord_Z { set; get; } = 0;
        public double Coord_U { set; get; } = 0;
        public string ScanVisionScriptFileName { set; get; }
        public virtual bool BarcodeMode { set; get; } = true;

        public bool TestCheckedAL { set; get; } = true;
        public bool TestCheckedAR { set; get; } = true;
        public bool TestCheckedBL { set; get; } = true;
        public bool TestCheckedBR { set; get; } = true;

        public string TestPcIPA { set; get; } = "192.168.1.101";
        public string TestPcIPB { set; get; } = "192.168.1.102";
        public int TestPcRemotePortA { set; get; } = 8000;
        public int TestPcRemotePortB { set; get; } = 8000;

        public string PickBracodeA_1 { set; get; }
        public string PickBracodeA_2 { set; get; }
        public string PickBracodeB_1 { set; get; }
        public string PickBracodeB_2 { set; get; }
        //public string TesterBracodeAL { set; get; } = "Null";
        //public string TesterBracodeAL { set; get; } = "Null";
        //public string TesterBracodeAR { set; get; } = "Null";
        //public string TesterBracodeAL { set; get; } = "Null";
        //public string TesterBracodeBL { set; get; } = "Null";
        //public string TesterBracodeBR { set; get; } = "Null";



        #endregion
        #region 变量
        public HdevEngine hdevScanEngine = new HdevEngine();
        public TCPIPConnect TestSentNet = new TCPIPConnect();
        public TCPIPConnect TestReceiveNet = new TCPIPConnect();
        public TCPIPConnect TestSentFlexNet = new TCPIPConnect();
        public TCPIPConnect TestReceiveFlexNet = new TCPIPConnect();
        public TCPIPConnect MsgReceiveNet = new TCPIPConnect();
        public TCPIPConnect CtrlNet = new TCPIPConnect();
        public TCPIPConnect IOReceiveNet = new TCPIPConnect();
        private string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        private string iniTesterResutPath = System.Environment.CurrentDirectory + "\\TesterResut.ini";
        private bool isLogined = false;
        //public Tester[] tester = new Tester[4];
        //public Testerwith4item[] testerwith4item = new Testerwith4item[2];
        public SIMTester[] sIMTester = new SIMTester[2];
        //private string barcodeString = "";
        private string BarcodeString = "";
        private string TestRecordSavePath = "";
        public UploadSoftwareStatus[] uploadSoftwareStatus = new UploadSoftwareStatus[4];
        private bool isCheckUpload = false;
        double PassLowLimitStop;
        int PassLowLimitStopNum;
        bool IsPassLowLimitStop;
        bool IsCheckINI;
        public int[] AdminAddNum = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        private string ScanCheckPickStr = "";
        public bool[] Rc90In { set; get; }
        public bool[] Rc90Out { set; get; }
        public bool DiaoLiaoStatus = false;
        int BarcodeItemNum;
        #endregion
        #region 事件定义
        public delegate void PrintEventHandler(string ModelMessageStr);
        public event PrintEventHandler ModelPrint;
        public event PrintEventHandler EPSONCommTwincat;
        public event PrintEventHandler DiaoLiaoEvent;
        public event PrintEventHandler EPSONDBSearch;
        public event PrintEventHandler EPSONSampleResult;
        public event PrintEventHandler EPSONSampleHave;
        public event PrintEventHandler EPSONSelectSampleResultfromDt;
        public event PrintEventHandler EPSONGRRTimesAsk;
        public delegate void EpsonStatusEventHandler(string EpsonStatusString);
        public event EpsonStatusEventHandler EpsonStatusUpdate;
        //public delegate void ScanEventHandler(string bar, HImage img);
        //public delegate void ScanP3EventHandler(string bar, HImage img, HObject hObject);
        //public delegate void ScanP3EventHandler1(string bar);
        //public event ScanEventHandler ScanUpdate;
        //public event ScanP3EventHandler ScanP3Update;
        //public event ScanP3EventHandler1 ScanP3Update1;
        public delegate void TestFinishedHandler(int index);
        public event TestFinishedHandler TestFinished;
       
        #endregion
        #region 构造函数
        public EpsonRC90()
        {
            Rc90In = new bool[100];
            Rc90Out = new bool[100];
            try
            {
                Scan.ini("COM1");
                IP = Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonIp", "192.168.1.2");
                TestSentPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestSendPort", "2000"));
                TestSentFlexPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestSendFlexPort", "2004"));
                TestReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestReceivePort", "2001"));
                IOReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonIOReceivePort", "2007"));
                TestReceiveFlexPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestReceiveFlexPort", "2005"));
                MsgReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonMsgReceivePort", "2002"));
                CtrlPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonRemoteControlPort", "5000"));
                BarcodeMode = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "BarcodeMode", "BarcodeMode", "True"));
                BarcodeItemNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BarcodeItem", "BarcodeItemNum", "3"));

                PickBracodeA_1 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "PickBracodeA_1", "Unknow");
                PickBracodeA_2 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "PickBracodeA_2", "Unknow");
                PickBracodeB_1 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "PickBracodeB_1", "Unknow");
                PickBracodeB_2 = Inifile.INIGetStringValue(iniParameterPath, "Barcode", "PickBracodeB_2", "Unknow");

                if (BarcodeMode)
                {
                    ScanVisionScriptFileName = Inifile.INIGetStringValue(iniParameterPath, "Camera", "ScanVisionScriptFileName", @"C:\test.hdev");
                }
                else
                {
                    ScanVisionScriptFileName = Inifile.INIGetStringValue(iniParameterPath, "Camera", "ScanVisionScriptFileNameP3", @"C:\test.hdev");
                }

                

                TestPcIPA = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcIPA", "192.168.1.101");
                TestPcIPB = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcIPB", "192.168.1.102");
                TestPcRemotePortA = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcRemotePortA", "8000"));
                TestPcRemotePortB = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcRemotePortB", "8000"));

                TestCheckedAL = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedAL", "True"));
                TestCheckedAR = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedAR", "True"));
                TestCheckedBL = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedBL", "True"));
                TestCheckedBR = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedBR", "True"));

                sIMTester[0] = new SIMTester(0);
                sIMTester[1] = new SIMTester(1);
                TestRecordSavePath = Inifile.INIGetStringValue(iniParameterPath, "SavePath", "TestRecordSavePath", "C:\\");
                isCheckUpload = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Upload", "IsCheckUploadStatus", "False"));
                PassLowLimitStop = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassLowLimitStop", "85"));
                PassLowLimitStopNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassLowLimitStopNum", "100"));
                IsPassLowLimitStop = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "IsPassLowLimitStop", "False"));
                IsCheckINI = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "CheckINI", "IsCheckINI", "False"));
                //isCheckUpload = true;
                //for (int i = 0; i < 4; i++)
                //{
                //    uploadSoftwareStatus[i] = new UploadSoftwareStatus(i);
                //}
                Async.RunFuncAsync(checkCtrlNet, null);
                Async.RunFuncAsync(checkTestSentNet, null);
                Async.RunFuncAsync(checkTestReceiveNet, null);
                Async.RunFuncAsync(checkIOReceiveNet, null);
                Async.RunFuncAsync(checkTestSentFlexNet, null);
                Async.RunFuncAsync(checkTestReceiveFlexNet, null);
                Async.RunFuncAsync(checkMsgReceiveNet, null);

                Async.RunFuncAsync(GetStatus, null);
                Async.RunFuncAsync(TestRevAnalysis,null);
                Async.RunFuncAsync(TestRevFlexAnalysis, null);
                Async.RunFuncAsync(MsgRevAnalysis, null);
                Async.RunFuncAsync(IORevAnalysis, null);
                Async.RunFuncAsync(EpsonRC90Init, null);
            }
            catch (Exception ex)
            {
                Log.Default.Error("EpsonRC90.EpsonRC90()", ex.Message);
            }
        }
        public void InitBarcodeList()
        {
            string filepath = TestRecordSavePath + "\\" + GetBanci() + ".csv";
            if (File.Exists(filepath))
            {
                DataTable dt = new DataTable();
                DataTable dt1;
                dt.Columns.Add("Time", typeof(string));
                dt.Columns.Add("Barcode", typeof(string));
                dt.Columns.Add("Result", typeof(string));
                dt.Columns.Add("Cycle", typeof(string));
                dt.Columns.Add("Index", typeof(string));
                try
                {
                    dt1 = Csvfile.csv2dt(filepath, 1, dt);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt1.Rows)
                        {
                            Testerwith4item.BarcodeList.Add(item["Barcode"].ToString());
                        }
                        ModelPrint("读取本地条码记录完成");
                    }
                    else
                    {
                        ModelPrint("本地文件无条码记录");
                    }
                }
                catch (Exception ex)
                {
                    Log.Default.Error("InitBarcodeList", ex.Message);
                }
            }
            else
            {
                ModelPrint("无当日本地记录文件");
            }
        }
        #endregion
        #region CheckNet
        public async void checkCtrlNet()
        {            
            while (true)
            {
                CtrlNet.IsOnline();
                if (!CtrlNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    CtrlNet.IsOnline();
                    if (!CtrlNet.tcpConnected)
                    {
                        isLogined = false;
                        bool r1 = await CtrlNet.Connect(IP, CtrlPort);
                        if (r1)
                        {
                            CtrlStatus = true;
                            ModelPrint("机械手CtrlNet连接");
                        }
                        else
                            CtrlStatus = false;
                    }
                }
                if (!isLogined && CtrlStatus)
                {
                    await CtrlNet.SendAsync("$login,123");
                    string s = await CtrlNet.ReceiveAsync();
                    if (s.Contains("#login,0"))
                        isLogined = true;
                    await Task.Delay(400);
                }
                else
                {
                    await Task.Delay(3000);
                }
            }
        }
        public async void checkTestSentNet()
        {
            while (true)
            {
                TestSentNet.IsOnline();
                await Task.Delay(400);
                if (!TestSentNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    TestSentNet.IsOnline();
                    if (!TestSentNet.tcpConnected)
                    {
                        bool r1 = await TestSentNet.Connect(IP, TestSentPort);
                        if (r1)
                        {
                            TestSendStatus = true;
                            ModelPrint("机械手TestSentNet连接");

                        }
                        else
                            TestSendStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        public async void checkTestSentFlexNet()
        {
            while (true)
            {
                TestSentFlexNet.IsOnline();
                await Task.Delay(400);
                if (!TestSentFlexNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    TestSentFlexNet.IsOnline();
                    if (!TestSentFlexNet.tcpConnected)
                    {
                        bool r1 = await TestSentFlexNet.Connect(IP, TestSentFlexPort);
                        if (r1)
                        {
                            TestSendFlexStatus = true;
                            ModelPrint("机械手TestSentFlexNet连接");

                        }
                        else
                            TestSendFlexStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        public async void checkTestReceiveNet()
        {
            while (true)
            {
                TestReceiveNet.IsOnline();
                await Task.Delay(400);
                if (!TestReceiveNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    TestReceiveNet.IsOnline();
                    if (!TestReceiveNet.tcpConnected)
                    {
                        bool r1 = await TestReceiveNet.Connect(IP, TestReceivePort);
                        if (r1)
                        {
                            TestReceiveStatus = true;
                            ModelPrint("机械手TestReceiveNet连接");

                        }
                        else
                            TestReceiveStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        public async void checkIOReceiveNet()
        {
            while (true)
            {
                IOReceiveNet.IsOnline();
                await Task.Delay(400);
                if (!IOReceiveNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    IOReceiveNet.IsOnline();
                    if (!IOReceiveNet.tcpConnected)
                    {
                        bool r1 = await IOReceiveNet.Connect(IP, IOReceivePort);
                        if (r1)
                        {
                            IOReceiveStatus = true;
                            ModelPrint("机械手IOReceiveNet连接");

                        }
                        else
                            IOReceiveStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        public async void checkTestReceiveFlexNet()
        {
            while (true)
            {
                TestReceiveFlexNet.IsOnline();
                await Task.Delay(400);
                if (!TestReceiveFlexNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    TestReceiveFlexNet.IsOnline();
                    if (!TestReceiveFlexNet.tcpConnected)
                    {
                        bool r1 = await TestReceiveFlexNet.Connect(IP, TestReceiveFlexPort);
                        if (r1)
                        {
                            TestReceiveFlexStatus = true;
                            ModelPrint("机械手TestReceiveFlexNet连接");

                        }
                        else
                            TestReceiveFlexStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        public async void checkMsgReceiveNet()
        {
            while (true)
            {
                MsgReceiveNet.IsOnline();
                await Task.Delay(400);
                if (!MsgReceiveNet.tcpConnected)
                {
                    await Task.Delay(1000);
                    MsgReceiveNet.IsOnline();
                    if (!MsgReceiveNet.tcpConnected)
                    {
                        bool r1 = await MsgReceiveNet.Connect(IP, MsgReceivePort);
                        if (r1)
                        {
                            MsgReceiveStatus = true;
                            ModelPrint("机械手MsgReceiveNet连接");

                        }
                        else
                            MsgReceiveStatus = false;
                    }
                }
                else
                { await Task.Delay(15000); }
            }
        }
        #endregion
        #region 工作函数
        private async void GetStatus()
        {
            string status = "";
            while (true)
            {
                if (isLogined == true)
                {
                    try
                    {
                        status = CtrlNet.SendThenReceive("$getstatus");
                        string[] statuss = status.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        if (statuss[0] == "#getstatus")
                        {
                            if (statuss[1].Length == 11)
                            {
                                EpsonStatusUpdate(statuss[1]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Default.Error("EpsonRC90.GetStatus", ex.Message);
                    }
                }
                await Task.Delay(1000);
            }
        }
        private async void TestRevAnalysis()
        {
            while (true)
            {
                //await Task.Delay(100);
                if (TestReceiveStatus == true)
                {
                    string s = await TestReceiveNet.ReceiveAsync();

                    string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        s = ss[0];
                    }
                    catch
                    {
                        s = "error";
                    }

                    if (s == "error")
                    {
                        TestReceiveNet.tcpConnected = false;
                        TestReceiveStatus = false;
                        ModelPrint("机械手TestReceiveNet断开");
                    }
                    else
                    {
                        ModelPrint("TestRev: " + s);
                        try
                        {
                            string[] strs = s.Split(',');
                            switch (strs[0])
                            {
                                case "Scan":
                                    R750Inspect(strs[2]);
                                    break;
                                case "ReleaseBarcode":
                                    switch (strs[2])
                                    {
                                        case "0":
                                            sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2] = PickBracodeA_1;
                                            Inifile.INIWriteValue(iniTesterResutPath, "Tester"+((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2).ToString(), "TesterBracode", PickBracodeA_1);
                                            PickBracodeA_1 = "NULL";
                                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_1", PickBracodeA_1);
                                            break;
                                        case "1":
                                            sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2 + 1] = PickBracodeA_2;
                                            Inifile.INIWriteValue(iniTesterResutPath, "Tester" + ((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2 + 1).ToString(), "TesterBracode", PickBracodeA_2);
                                            PickBracodeA_2 = "NULL";
                                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_2", PickBracodeA_2);
                                            break;
                                        case "2":
                                            sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2] = PickBracodeA_1;
                                            sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2 + 1] = PickBracodeA_2;
                                            Inifile.INIWriteValue(iniTesterResutPath, "Tester" + ((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2).ToString(), "TesterBracode", PickBracodeA_1);
                                            Inifile.INIWriteValue(iniTesterResutPath, "Tester" + ((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2 + 1).ToString(), "TesterBracode", PickBracodeA_2);
                                            PickBracodeA_1 = "NULL";
                                            PickBracodeA_2 = "NULL";
                                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_1", PickBracodeA_1);
                                            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_2", PickBracodeA_2);
                                            break;
                                        default:
                                            break;
                                    }                                    

                                    break;
                                case "SampleReleaseBarcode":
     
                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2] = PickBracodeA_1;
                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].TesterBracode[(int.Parse(strs[1]) - 1) % 2 * 2 + 1] = PickBracodeA_2;
                                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + ((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2).ToString(), "TesterBracode", PickBracodeA_1);
                                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + ((int.Parse(strs[1]) - 1) / 2 * 4 + (int.Parse(strs[1]) - 1) % 2 * 2 + 1).ToString(), "TesterBracode", PickBracodeA_2);
                                         
                       

                                    break;

                                case "SamDBSearch":
                                    switch (strs[1])
                                    {
                                        case "A":
                                            EPSONDBSearch("A");
                                            break;
                                        case "B":
                                            EPSONDBSearch("B");
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                

                                case "SampleResult":
                                    EPSONSampleResult(s);
                                    break;
                                case "SamPanelHave":
                                    EPSONSampleHave(s);
                                    break;
                                case "SelectSampleResultfromDt":
                                    EPSONSelectSampleResultfromDt("");
                                    break;
                                    
                                case "GRRTimesAsk":
                                    EPSONGRRTimesAsk("GRRTimesAsk");
                                    break;
                                case "FMOVE":
                                    EPSONCommTwincat(s);
                                    break;
                                case "TMOVE":
                                    EPSONCommTwincat(s);
                                    break;
                                case "ULOAD":
                                    EPSONCommTwincat(s);
                                    break;
                                case "DiaoLiao":
                                    DiaoLiaoEvent(strs[1]);
                                    break;     
                                case "ResetCMD":
                                    EPSONCommTwincat(s);
                                    break;
                                case "StatusOfUpload":
                                    AnswerStatusOfUpload();
                                    break;
                                case "StatusOfYield":
                                    AnswerStatusOfYield();
                                    break;
                                case "StatusOfDiaoLiao":
                                    AnsverStatusOfDiaoLiao();
                                    break;
                                default:
                                    ModelPrint("无效指令： " + s);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            ModelPrint("监听机械手命令出错");
                            Log.Default.Error("EpsonRC90.TestRevAnalysis", ex.Message);
                        }

                    }
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
        private async void TestRevFlexAnalysis()
        {
            while (true)
            {
                //await Task.Delay(100);
                if (TestReceiveFlexStatus == true)
                {
                    string s = await TestReceiveFlexNet.ReceiveAsync();

                    string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        s = ss[0];
                    }
                    catch
                    {
                        s = "error";
                    }

                    if (s == "error")
                    {
                        TestReceiveFlexNet.tcpConnected = false;
                        TestReceiveFlexStatus = false;
                        ModelPrint("机械手TestReceiveFlexNet断开");
                    }
                    else
                    {
                        ModelPrint("TestRevFlex: " + s);
                        try
                        {
                            string[] strs = s.Split(',');
                            switch (strs[0])
                            {
                                
                                case "Start":
                                    switch (strs[2])
                                    {
                                        case "0":
                                            switch ((int.Parse(strs[1]) - 1) % 2)
                                            {
                                                case 0:
                                                    //左穴测试
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start1(StartProcess);
                                                    break;
                                                case 1:
                                                    //右穴测试
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start3(StartProcess);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            
                                            break;
                                        case "1":
                                            switch ((int.Parse(strs[1]) - 1) % 2)
                                            {
                                                case 0:
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start2(StartProcess);
                                                    break;
                                                case 1:
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start4(StartProcess);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            switch ((int.Parse(strs[1]) - 1) % 2)
                                            {
                                                case 0:
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start1(StartProcess);
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start2(StartProcess);
                                                    break;
                                                case 1:
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start3(StartProcess);
                                                    sIMTester[(int.Parse(strs[1]) - 1) / 2].Start4(StartProcess);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                               
                                default:
                                    ModelPrint("无效指令： " + s);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            ModelPrint("监听机械手Flex命令出错");
                            Log.Default.Error("EpsonRC90.TestRevFlexAnalysis", ex.Message);
                        }

                    }
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
        private async void AnswerStatusOfUpload()
        {
            string str = "StatusOfUpload";
            for (int i = 0; i < 4; i++)
            {
                if (uploadSoftwareStatus[i].status || !isCheckUpload)
                {
                    str += ";1";
                }
                else
                {
                    str += ";0";
                }
            }

            if (TestSendStatus)
            {
                await TestSentNet.SendAsync(str);
            }
        }
        private async void AnswerStatusOfYield()
        {
            string str = "StatusOfYield";

            for (int i = 0; i < 4; i++)
            {
                if (sIMTester[i / 4].Yield[i % 4] >= PassLowLimitStop || !IsPassLowLimitStop || sIMTester[i / 4].TestCount[i % 4] < PassLowLimitStopNum + AdminAddNum[i])
                {
                    str += ";1";
                }
                else
                {
                    str += ";0";
                }
            }

            if (TestSendStatus)
            {
                await TestSentNet.SendAsync(str);
            }
        }
        private async void AnsverStatusOfDiaoLiao()
        {
            if (TestSendStatus)
            {
                if (DiaoLiaoStatus)
                {
                    await TestSentNet.SendAsync("StatusOfDiaoLiao;1");
                }
                else
                {
                    await TestSentNet.SendAsync("StatusOfDiaoLiao;2");
                }
            }

        }
        private async void CheckiniAction(string barcode, int index)
        {
            string iniFilepath = @"d:\test.ini";
            string sectionName = "";
            Stopwatch sw = new Stopwatch();
            switch (index)
            {
                case 0:
                    sectionName = "A";
                    break;
                case 1:
                    sectionName = "B";
                    break;
                case 2:
                    sectionName = "C";
                    break;
                case 3:
                    sectionName = "D";
                    break;
                default:
                    break;
            }
            sw.Start();
            await ((Func<Task>)(() =>
            {
                return Task.Run(() =>
                {
                    while (true)
                    {
                        System.Threading.Thread.Sleep(1000);
                        ModelPrint((index+1).ToString() + "条码比对中 " + Math.Round(sw.Elapsed.TotalSeconds, 1).ToString());
                        string bar1 = Inifile.INIGetStringValue(iniFilepath, sectionName, "bar", "999");
                        string rst = Inifile.INIGetStringValue(iniFilepath, sectionName, "result", "999"); 
                        if ((bar1 == barcode && rst == "OK") || sw.Elapsed.TotalSeconds > 10 || !IsCheckINI)
                        {
                            
                            break;
                        }
                        else
                        {
                            if (bar1 == barcode)
                            {
                                ModelPrint("条码 " + barcode +" 匹配成功，但结果异常");
                            }
                        }
                    }
                });
            }))();
            sw.Stop();
            if (sw.Elapsed.TotalSeconds > 10)
            {
                await TestSentNet.SendAsync("CheckBarcodeResult;2");
            }
            else
            {
                await TestSentNet.SendAsync("CheckBarcodeResult;1");
            }
            
        }
        public async void StartProcess(int index)
        {
            TestFinished(index);
            if (sIMTester[index / 4].testStatus[index % 4] == TestStatus.Err)
            {
                Log.Default.Error("测试机 " + (index + 1).ToString() + " 测试过程出错");
                ModelPrint("测试机 " + (index + 1).ToString() + " 测试过程出错");
            }
            else
            {
                if (sIMTester[index / 4].testStatus[index % 4] == TestStatus.Tested)
                {
                    ModelPrint("测试机 " + (index + 1).ToString() + " 测试完成 " + sIMTester[index / 4].testResult[index % 4].ToString());
                    string r = await TestSentFlexNet.SendAsync("TestResult;" + sIMTester[index / 4].testResult[index % 4].ToString() + ";" + (index + 1).ToString());
                    if (r == "error")
                    {
                        Log.Default.Error("TestSentFlex网络出错");
                        ModelPrint("TestSentFlex网络出错");
                        TestSentFlexNet.tcpConnected = false;
                        TestSendFlexStatus = false;
                    }
                }
            }
        }
        private string GetBanci()
        {
            string str, strdate;
            if (DateTime.Now.Hour < 8)
            {
                strdate = DateTime.Now.AddDays(-1).ToLongDateString();
            }
            else
            {
                strdate = DateTime.Now.ToLongDateString();
            }
            str = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "Day" : "Night";
            return strdate + str;
        }
        private string GetBanciShort()
        {
            string str, strdate;
            if (DateTime.Now.Hour < 8)
            {
                strdate = DateTime.Now.AddDays(-1).ToShortDateString();
            }
            else
            {
                strdate = DateTime.Now.ToShortDateString();
            }
            str = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "Day" : "Night";
            return strdate + str;
        }
        private void SaveStartBarcodetoCSV(string bar, int index_ii)
        {
            if (!Directory.Exists(TestRecordSavePath + @"\Barcode\" + GetBanci()))
            {
                Directory.CreateDirectory(TestRecordSavePath + @"\Barcode\" + GetBanci());
            }
            string filepath = TestRecordSavePath + @"\Barcode\" + GetBanci() + @"\Tester" + index_ii.ToString() + GetBanciShort().Replace("/", "") + ".csv";
            try
            {
                if (!File.Exists(filepath))
                {
                    string[] heads = { "DateTime", "TesterBarcode" };
                    Csvfile.savetocsv(filepath, heads);
                }
                string[] conte = { System.DateTime.Now.ToString(), bar };
                Csvfile.savetocsv(filepath, conte);
            }
            catch (Exception ex)
            {
                //Msg = messagePrint.AddMessage("写入CSV文件失败");
                Log.Default.Error("写入CSV文件失败", ex.Message);
            }
        }
        private async void IORevAnalysis()
        {
            while (true)
            {
                //await Task.Delay(100);
                if (IOReceiveStatus == true)
                {
                    string s = await IOReceiveNet.ReceiveAsync();

                    string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        s = ss[0];
 
                    }
                    catch
                    {
                        s = "error";
                    }

                    if (s == "error")
                    {
                        IOReceiveNet.tcpConnected = false;
                        IOReceiveStatus = false;
                        ModelPrint("机械手IOReceiveNet断开");
                    }
                    else
                    {
                        string[] strs = s.Split(',');
                        if (strs[0] == "IOCMD" && strs[1].Length == 100)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Rc90Out[i] = strs[1][i] == '1' ? true : false;
                            }
                            string RsedStr = "";
                            for (int i = 0; i < 100; i++)
                            {
                                RsedStr += Rc90In[i] ? "1" : "0";
                            }
                            await IOReceiveNet.SendAsync(RsedStr);
                        }
                        //ModelPrint("IORev: " + s);


                    }
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
        private async void MsgRevAnalysis()
        {
            while (true)
            {
                //await Task.Delay(100);
                if (MsgReceiveStatus == true)
                {
                    string s = await MsgReceiveNet.ReceiveAsync();

                    string[] ss = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        s = ss[0];
                    }
                    catch
                    {
                        s = "error";
                    }

                    if (s == "error")
                    {
                        MsgReceiveNet.tcpConnected = false;
                        MsgReceiveStatus = false;
                        ModelPrint("机械手MsgReceiveNet断开");
                    }
                    else
                    {
                        ModelPrint("MsgRev: " + s);
                    }
                }
                else
                {
                    await Task.Delay(100);
                }
            }
        }
        private async void EpsonRC90Init()
        {
            while (!TestSendStatus)
            {
                await Task.Delay(1000);
            }
            await TestSentNet.SendAsync("InitPar;123");
            ModelPrint("机械手控制器，初始化完成");
        }
 
        #endregion
        #region Scan

        public void R750Inspect(string index)
        {
            switch (index)
            {
                case "1":
                    Scan.GetBarCode(R750InspectCallback_1);
                    break;
                case "2":
                    Scan.GetBarCode(R750InspectCallback_2);
                    break;
                default:
                    break;
            }
        }
        private async void R750InspectCallback_1(string barcode)
        {
            PickBracodeA_1 = barcode;
            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_1", PickBracodeA_1);
            if (barcode == "Error")
            {

                ModelPrint("扫码不良");
                if (TestSendStatus)
                {
                    await TestSentNet.SendAsync("ScanResult;Ng;A");
                }
            }
            else
            {
                ModelPrint("扫码成功 " + barcode);
                if (TestSendStatus)
                {
                    await TestSentNet.SendAsync("ScanResult;Pass;A");
                }
            }
        }
        private async void R750InspectCallback_2(string barcode)
        {
            PickBracodeA_2 = barcode;
            Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA_2", PickBracodeA_2);
            if (barcode == "Error")
            {

                ModelPrint("扫码不良");
                if (TestSendStatus)
                {
                    await TestSentNet.SendAsync("ScanResult;Ng;A");
                }
            }
            else
            {
                ModelPrint("扫码成功 " + barcode);
                if (TestSendStatus)
                {
                    await TestSentNet.SendAsync("ScanResult;Pass;A");
                }
            }
        }
        
        private bool LookforDt(string barcode)
        {
            bool r = false;
            string[] arrField = new string[1];
            string[] arrValue = new string[1];
            try
            {
                string tablename = "FLUKE_DATA";
                OraDB oraDB = new OraDB("zdtdb", "ictdata", "ictdata*168");
                if (oraDB.isConnect())
                {

                    arrField[0] = "BARCODE";
                    arrValue[0] = barcode;
                    DataSet s = oraDB.selectSQL(tablename.ToUpper(), arrField, arrValue);
                    DataTable SinglDt = s.Tables[0];
                    if (SinglDt.Rows.Count < BarcodeItemNum)
                    {
                        ModelPrint("条码 " + barcode + " 记录 " + SinglDt.Rows.Count.ToString() + " < " + BarcodeItemNum.ToString() + " 合法");
                        r = true;

                    }
                    else
                    {
                        ModelPrint("条码 " + barcode + " 记录 " + SinglDt.Rows.Count.ToString() + " >= " + BarcodeItemNum.ToString() + " 非法");
                        r = false;
                    }


                }
                else
                {
                    ModelPrint("数据库连接失败");
                    r = true;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                ModelPrint(ex.Message);
                r = true;

            }
            return r;
        }
        
        public string getString(int count)
        {
            int number;
            string checkCode = String.Empty;
            System.Random myRandom = new Random();
            for (int i = 0; i < count; i++)
            {
                number = myRandom.Next();
                number = number % 36;
                if (number < 10)
                {
                    number += 48;
                }
                else
                {
                    number += 55;
                }
                checkCode += ((char)number).ToString();
            }
            return checkCode;
        }
        #endregion

    }
}
