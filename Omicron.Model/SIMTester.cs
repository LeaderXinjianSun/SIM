using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb;
using System.Diagnostics;

namespace Omicron.Model
{
    public class SIMTester
    {
        public static bool IsInSampleMode { set; get; } = false;
        public string[] TesterBracode { set; get; } = new string[4] { "Null", "Null", "Null", "Null" };
        public int TestTimeout { set; get; }
        public int Index { set; get; }
        public double[] TestSpan { set; get; } = new double[4] { 0, 0, 0, 0 };
        public int[] PassCount { set; get; } = new int[4];
        public int[] FailCount { set; get; } = new int[4];
        public int[] TestCount { set; get; } = new int[4];
        public double[] Yield { set; get; } = new double[4];
        public TestResult[] testResult { set; get; } = new TestResult[4] { TestResult.Unknow, TestResult.Unknow, TestResult.Unknow, TestResult.Unknow };
        public TestStatus[] testStatus { set; get; } = new TestStatus[4] { TestStatus.PreTest, TestStatus.PreTest, TestStatus.PreTest, TestStatus.PreTest };
        private string iniTestCommandpath = @"d:\barcode.ini";
        private string iniTesterResutPath = System.Environment.CurrentDirectory + "\\TesterResut.ini";
        private string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        private short[] StepFlag = new short[4];
        private bool[] TestActionSwitch = new bool[4];
        private bool[] result_flag = new bool[4];
        public delegate void StartProcessedDelegate(int i);
        public SIMTester( int index)
        {
            Index = index;
            switch (index)
            {
                case 0:
                    iniTestCommandpath = @"d:\barcode_1.ini";
                    break;
                case 1:
                    iniTestCommandpath = @"d:\barcode_2.ini";
                    break;
                default:
                    break;
            }
            TesterStatusInit();
            Async.RunFuncAsync(RunLoop, null);
        }
        public async void Start1(StartProcessedDelegate callback)
        {
            Stopwatch sw = new Stopwatch();
            int mResult = -2;
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    //开始动作

                    StepFlag[0] = 0;
                    TestActionSwitch[0] = true;

                    sw.Start();
                    testResult[0] = TestResult.Unknow;
                    testStatus[0] = TestStatus.Testing;
                    while (StepFlag[0] != 3)
                    {
                        if (mResult == 2)
                        {
                            TestActionSwitch[0] = false;
                            return;
                        }
                        TestSpan[0] = Math.Round(sw.Elapsed.TotalSeconds, 2);
                        await Task.Delay(50);
                    }
                    TestActionSwitch[0] = false;


                    if (result_flag[0])
                    {
                        mResult = 1;
                    }
                    else
                    {
                        mResult = 0;
                    }

                   
                });
            };
            Task taskDelay = Task.Delay(TestTimeout);
            var completeTask = await Task.WhenAny(startTask(), taskDelay);
            if (completeTask == taskDelay)
            {
                //超时退出
                mResult = 2;
            }
            UpdateTester(mResult, 0);
            callback(Index * 4 + 0);
        }
        public async void Start2(StartProcessedDelegate callback)
        {
            Stopwatch sw = new Stopwatch();
            int mResult = -2;
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    //开始动作

                    StepFlag[1] = 0;
                    TestActionSwitch[1] = true;

                    sw.Start();
                    testResult[1] = TestResult.Unknow;
                    testStatus[1] = TestStatus.Testing;
                    while (StepFlag[1] != 3)
                    {
                        if (mResult == 2)
                        {
                            TestActionSwitch[1] = false;
                            return;
                        }
                        TestSpan[1] = Math.Round(sw.Elapsed.TotalSeconds, 2);
                        await Task.Delay(50);
                    }
                    TestActionSwitch[1] = false;


                    if (result_flag[1])
                    {
                        mResult = 1;
                    }
                    else
                    {
                        mResult = 0;
                    }


                });
            };
            Task taskDelay = Task.Delay(TestTimeout);
            var completeTask = await Task.WhenAny(startTask(), taskDelay);
            if (completeTask == taskDelay)
            {
                //超时退出
                mResult = 2;
            }
            UpdateTester(mResult, 1);
            callback(Index * 4 + 1);
        }
        public async void Start3(StartProcessedDelegate callback)
        {
            Stopwatch sw = new Stopwatch();
            int mResult = -2;
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    //开始动作

                    StepFlag[2] = 0;
                    TestActionSwitch[2] = true;

                    sw.Start();
                    testResult[2] = TestResult.Unknow;
                    testStatus[2] = TestStatus.Testing;
                    while (StepFlag[2] != 3)
                    {
                        if (mResult == 2)
                        {
                            TestActionSwitch[2] = false;
                            return;
                        }
                        TestSpan[2] = Math.Round(sw.Elapsed.TotalSeconds, 2);
                        await Task.Delay(50);
                    }
                    TestActionSwitch[2] = false;


                    if (result_flag[2])
                    {
                        mResult = 1;
                    }
                    else
                    {
                        mResult = 0;
                    }


                });
            };
            Task taskDelay = Task.Delay(TestTimeout);
            var completeTask = await Task.WhenAny(startTask(), taskDelay);
            if (completeTask == taskDelay)
            {
                //超时退出
                mResult = 2;
            }
            UpdateTester(mResult, 2);
            callback(Index * 4 + 2);
        }
        public async void Start4(StartProcessedDelegate callback)
        {
            Stopwatch sw = new Stopwatch();
            int mResult = -2;
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    //开始动作

                    StepFlag[3] = 0;
                    TestActionSwitch[3] = true;

                    sw.Start();
                    testResult[3] = TestResult.Unknow;
                    testStatus[3] = TestStatus.Testing;
                    while (StepFlag[3] != 3)
                    {
                        if (mResult == 2)
                        {
                            TestActionSwitch[3] = false;
                            return;
                        }
                        TestSpan[3] = Math.Round(sw.Elapsed.TotalSeconds, 2);
                        await Task.Delay(50);
                    }
                    TestActionSwitch[3] = false;


                    if (result_flag[3])
                    {
                        mResult = 1;
                    }
                    else
                    {
                        mResult = 0;
                    }


                });
            };
            Task taskDelay = Task.Delay(TestTimeout);
            var completeTask = await Task.WhenAny(startTask(), taskDelay);
            if (completeTask == taskDelay)
            {
                //超时退出
                mResult = 2;
            }
            UpdateTester(mResult, 3);
            callback(Index * 4 + 3);
        }
        private void UpdateTester(int rst, int index_i)
        {
            /*result = 0 -> Ng
                  * result = 1 -> Pass
                  * result = 2 -> Timeout
                  */
            switch (rst)
            {
                case 0:
                    testStatus[index_i] = TestStatus.Tested;
                    testResult[index_i] = TestResult.Ng;

                    break;
                case 1:
                    testStatus[index_i] = TestStatus.Tested;
                    testResult[index_i] = TestResult.Pass;

                    break;
                case 2:
                    testStatus[index_i] = TestStatus.Tested;
                    testResult[index_i] = TestResult.TimeOut;
                    break;
                default:
                    testStatus[index_i] = TestStatus.Err;
                    testResult[index_i] = TestResult.TimeOut;
                    break;
            }
            if (!IsInSampleMode)
            {
                switch (rst)
                {
                    case 0:

                        FailCount[index_i]++;

                        break;
                    case 1:

                        PassCount[index_i]++;

                        break;
                    default:

                        break;
                }

                TestCount[index_i]++;
                if (PassCount[index_i] + FailCount[index_i] != 0)
                {
                    Yield[index_i] = Math.Round((double)PassCount[index_i] / (PassCount[index_i] + FailCount[index_i]) * 100, 2);
                }
                else
                {
                    Yield[index_i] = 0;
                }
                try
                {
                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + (Index * 4 + index_i).ToString(), "TestSpan", TestSpan[index_i].ToString());
                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + (Index * 4 + index_i).ToString(), "PassCount", PassCount[index_i].ToString());
                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + (Index * 4 + index_i).ToString(), "FailCount", FailCount[index_i].ToString());
                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + (Index * 4 + index_i).ToString(), "TestCount", TestCount[index_i].ToString());
                    Inifile.INIWriteValue(iniTesterResutPath, "Tester" + (Index * 4 + index_i).ToString(), "Yield", Yield[index_i].ToString());
                }
                catch
                {


                }
            }
            

        }
        private void TesterStatusInit()
        {
            for (int i = 0; i < 4; i++)
            {
                TesterBracode[i] = Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "TesterBracode", "Null");
                TestSpan[i] = double.Parse(Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "TestSpan", "0"));
                PassCount[i] = int.Parse(Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "PassCount", "0"));                
                FailCount[i] = int.Parse(Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "FailCount", "0"));                
                TestCount[i] = int.Parse(Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "TestCount", "0"));                
                Yield[i] = double.Parse(Inifile.INIGetStringValue(iniTesterResutPath, "Tester" + (Index * 4 + i).ToString(), "Yield", "0"));
                double timeout = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "FlexTest", "FlexTestTimeout", "100"));
                TestTimeout = (int)(timeout * 1000);
                
    }
        }
        /// <扫描周期>
        /// 100ms
        /// </扫描周期>
        private void RunLoop()
        {
            //[1]
            //--填入条码开始测试，测试完成条码会被清空
            //BARCODE=
            //--PASS;FAIL;
            //RESULT=
            //--0:需要复测;1:可以取出
            //TAKE=
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (TestActionSwitch[i])
                    {
                        switch (StepFlag[i])
                        {
                            case 0://写条码
                                Inifile.INIWriteValue(iniTestCommandpath, (i + 1).ToString(), "BARCODE", TesterBracode[i]);
                                Inifile.INIWriteValue(iniTestCommandpath, (i + 1).ToString(), "RESULT", "");
                                Inifile.INIWriteValue(iniTestCommandpath, (i + 1).ToString(), "TAKE", "");
                                StepFlag[i] = 1;
                                break;
                            case 1://读是否测试完成
                                string rststr = Inifile.INIGetStringValue(iniTestCommandpath,( i + 1).ToString(), "RESULT", "Error");
                                if (rststr == "PASS" || rststr == "FAIL")
                                {
                                    StepFlag[i] = 2;
                                }                                
                                break;
                            case 2://读Pass；读Ng
                                string takestr = Inifile.INIGetStringValue(iniTestCommandpath, (i + 1).ToString(), "TAKE", "Error");
                                Inifile.INIWriteValue(iniTestCommandpath, (i + 1).ToString(), "TAKE", "");
                                if (takestr == "0")
                                {
                                    System.Threading.Thread.Sleep(2000);
                                    StepFlag[i] = 0;
                                }
                                else
                                {
                                    string resultstr = Inifile.INIGetStringValue(iniTestCommandpath, (i + 1).ToString(), "RESULT", "PASS");
                                    Inifile.INIWriteValue(iniTestCommandpath, (i + 1).ToString(), "RESULT", "");
                                    result_flag[i] = resultstr == "PASS";
                                    StepFlag[i] = 3;
                                   
                                }
                                break;

                            case 3://完成
                                System.Threading.Thread.Sleep(100);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        StepFlag[i] = -1;

                    }
                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
