﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingLibrary.hjb;
using BingLibrary.hjb.Intercepts;
using System.ComponentModel.Composition;
using SxjLibrary;
using System.Windows;
using Omicron.Model;
using System.Windows.Forms;
using System.IO;
using ViewROI;
using HalconDotNet;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Threading;
using 臻鼎科技OraDB;
using System.Diagnostics;
using BingLibrary.hjb.PLC;
//using MahApps.Metro.Controls.Dialogs;

namespace Omicron.ViewModel
{
    [BingAutoNotify]
    public class MainDataContext : DataSource
    {
        #region 属性绑定区域
        public virtual uint UPH { set; get; }
        public virtual string M20027 { set; get; }
        public virtual string M20028 { set; get; }
        public virtual string M20029 { set; get; }
        public virtual string M20030 { set; get; }
        public virtual bool MenuIsEnabled { set; get; } = true;
        public virtual string AlarmViewPassword { set; get; }
        public virtual double Downtime { set; get; }//上料机故障时间
        public virtual string DowntimeStr { set; get; }
        public virtual double DowntimeDisp { set; get; }
        public virtual double Jigdowntime { set; get; }//治具故障时间
        public virtual string JigdowntimeStr { set; get; }
        public virtual double JigdowntimeDisp { set; get; }
        public virtual double Waitforinput { set; get; }//等待时间
        public virtual string WaitforinputStr { set; get; }
        public virtual double WaitforinputDisp { set; get; }
        public virtual double Waitfortray { set; get; }//下料等待时间
        public virtual string WaitfortrayStr { set; get; }
        public virtual double WaitfortrayDisp { set; get; }
        public virtual double Waitfortake { set; get; }//无TRAY时间
        public virtual string WaitfortakeStr { set; get; }
        public virtual double WaitfortakeDisp { set; get; }
        public virtual bool isDiaoLiaoStopFlag { set; get; }
        public virtual string AboutPageVisibility { set; get; } = "Collapsed";
        public virtual string HomePageVisibility { set; get; } = "Visible";
        public virtual string ParameterPageVisibility { set; get; } = "Collapsed";
        public virtual string HaoCaiVisibility { set; get; } = "Collapsed";
        public virtual string CameraHcPageVisibility { set; get; } = "Collapsed";
        public virtual string ScanCameraPageVisibility { set; get; } = "Collapsed";
        public virtual string BarcodeDisplayPageVisibility { set; get; } = "Collapsed";
        public virtual string OperaterActionPageVisibility { set; get; } = "Collapsed";
        public virtual string TestRecordPageVisibility { set; get; } = "Collapsed";
        public virtual string TwincatNcPageVisibility { set; get; } = "Collapsed";
        public virtual string ScanPageVisibility { set; get; } = "Collapsed";
        public virtual string SampleTestPageVisibility { set; get; } = "Collapsed";
        public virtual string SampleTestPage1Visibility { set; get; } = "Collapsed";
        public virtual string AlarmRecordPageVisibility { set; get; } = "Collapsed";
        public virtual string HelpPageVisibility { set; get; } = "Collapsed";
        public virtual string SampleTestResultPageVisibility { set; get; } = "Collapsed";
        public virtual string AlarmLockDisplayVisibility { set; get; } = "Collapsed";
        public virtual string SampleProcessDisplayVisibility { set; get; } = "Collapsed";
        public virtual string SafeDoorAlarmVisibility { set; get; } = "Collapsed";
        public virtual string PLCMessageVisibility { set; get; } = "Collapsed";
        public virtual string PLCMessage { set; get; }
        public virtual bool IsPLCConnect { set; get; } = false;
        public virtual bool IsTCPConnect { set; get; } = false;
        public virtual bool IsShieldTheDoor { set; get; } = false;
        public virtual bool IsOperateCiTie { set; get; } = true;
        public virtual string Msg { set; get; } = "";
        public virtual bool EpsonStatusAuto { set; get; } = false;
        public virtual bool EpsonStatusWarning { set; get; } = false;
        public virtual bool EpsonStatusSError { set; get; } = false;
        public virtual bool EpsonStatusSafeGuard { set; get; } = false;
        public virtual bool EpsonStatusEStop { set; get; } = false;
        public virtual bool EpsonStatusError { set; get; } = false;
        public virtual bool EpsonStatusPaused { set; get; } = false;
        public virtual bool EpsonStatusRunning { set; get; } = false;
        public virtual bool EpsonStatusReady { set; get; } = false;
        public virtual string SerialPortCom { set; get; }
        public virtual bool TestSendPortStatus { set; get; } = false;
        public virtual bool TestRevPortStatus { set; get; } = false;
        public virtual bool TestSendFlexPortStatus { set; get; } = false;
        public virtual bool TestRevFlexPortStatus { set; get; } = false;
        public virtual bool MsgRevPortStatus { set; get; } = false;
        public virtual bool IORevPortStatus { set; get; } = false;
        public virtual bool EllipseMsgRev { set; get; } = false;
        public virtual bool CtrlPortStatus { set; get; } = false;
        public virtual string EpsonIp { set; get; } = "192.168.1.2";
        public virtual int BarcodeItemNum { set; get; }
        public virtual int EpsonTestSendPort { set; get; } = 2000;
        public virtual int EpsonTestReceivePort { set; get; } = 2001;
        public virtual int EpsonTestSendFlexPort { set; get; } = 2004;
        public virtual int EpsonTestReceiveFlexPort { set; get; } = 2005;
        public virtual int EpsonMsgReceivePort { set; get; } = 2002;
        public virtual int EpsonIOReceivePort { set; get; } = 2007;
        public virtual int EpsonRemoteControlPort { set; get; } = 5000;
        public virtual string VisionScriptFileName { set; get; }
        public virtual string HcVisionScriptFileName { set; get; }
        public virtual string ScanVisionScriptFileName { set; get; }
        public virtual string ScanVisionScriptFileNameP3 { set; get; }
        public virtual HImage hImage { set; get; }
        public virtual ObservableCollection<HObject> hObjectList { set; get; }
        public virtual ObservableCollection<ROI> ROIList { set; get; } = new ObservableCollection<ROI>();
        public virtual int ActiveIndex { set; get; }
        public virtual bool Repaint { set; get; }

        public virtual HImage hImageScan { set; get; }
        public virtual ObservableCollection<HObject> hObjectListScan { set; get; }
        public virtual ObservableCollection<ROI> ROIListScan { set; get; } = new ObservableCollection<ROI>();
        public virtual int ActiveIndexScan { set; get; }
        public virtual bool RepaintScan { set; get; }

        public virtual string BarcodeDisplay { set; get; } = "C4671110MYFGXCLBJ";

        //public virtual bool FindFill1 { set; get; } = false;
        //public virtual bool FindFill2 { set; get; } = false;
        //public virtual bool FindFill3 { set; get; } = false;
        //public virtual bool FindFill4 { set; get; } = false;
        //public virtual bool FindFill5 { set; get; } = false;
        //public virtual bool FindFill6 { set; get; } = false;
        //public virtual bool FindFill7 { set; get; } = true;
        //public virtual bool FindFill8 { set; get; } = true;

        public virtual string TestPcIPA { set; get; } = "192.168.1.101";
        public virtual string TestPcIPB { set; get; } = "192.168.1.102";
        public virtual int TestPcRemotePortA { set; get; } = 8000;
        public virtual int TestPcRemotePortB { set; get; } = 8000;
        public virtual string TestPcPathA { set; get; } = "/Users/zdt/Desktop/UIExplore_1.2.17_Flex.app";
        public virtual string TestPcPathB { set; get; } = "/Users/zdt/Desktop/UIExplore_1.2.17_Flex.app";
        public virtual bool TestCheckedAL { set; get; } = true;
        public virtual bool TestCheckedAR { set; get; } = true;
        public virtual bool TestCheckedBL { set; get; } = true;
        public virtual bool TestCheckedBR { set; get; } = true;

        public virtual string PickBracodeA_1 { set; get; } = "Null";
        public virtual string PickBracodeB_1 { set; get; } = "Null";
        public virtual string TesterBracodeAL_1 { set; get; } = "Null";
        public virtual string TesterBracodeAR_1 { set; get; } = "Null";
        public virtual string TesterBracodeBL_1 { set; get; } = "Null";
        public virtual string TesterBracodeBR_1 { set; get; } = "Null";
        public virtual string PickBracodeA_2 { set; get; } = "Null";
        public virtual string PickBracodeB_2 { set; get; } = "Null";
        public virtual string TesterBracodeAL_2 { set; get; } = "Null";
        public virtual string TesterBracodeAR_2 { set; get; } = "Null";
        public virtual string TesterBracodeBL_2 { set; get; } = "Null";
        public virtual string TesterBracodeBR_2 { set; get; } = "Null";

        //public virtual DataTable TestRecodeDT { set; get; } = new DataTable();
        public virtual ObservableCollection<TestRecord> testRecord { set; get; } = new ObservableCollection<TestRecord>();
        public virtual ObservableCollection<AlarmRecord> alarmRecord { set; get; } = new ObservableCollection<AlarmRecord>();
        public virtual ObservableCollection<AlarmTableItem> alarmTableItems { set; get; } = new ObservableCollection<AlarmTableItem>();
        public virtual ObservableCollection<X758SampleResultData> X758SampleResultDataTableItems { set; get; } = new ObservableCollection<X758SampleResultData>();
        public virtual ObservableCollection<QuiLiaoBarcode> QueLiaoTable { set; get; } = new ObservableCollection<QuiLiaoBarcode>();
        public virtual uint LiaoCountIN { set; get; } = 0;
        public virtual uint LiaoCountOut { set; get; } = 0;
        public virtual int LiaoDelta { set; get; }
        public virtual double TestTime4 { set; get; } = 0;
        public virtual int TestCount4 { set; get; } = 0;
        public virtual int PassCount4 { set; get; } = 0;
        public virtual int FailCount4 { set; get; } = 0;
        public virtual double Yield4 { set; get; } = 0;
        public virtual double TestTime5 { set; get; } = 0;
        public virtual int TestCount5 { set; get; } = 0;
        public virtual int PassCount5 { set; get; } = 0;
        public virtual int FailCount5 { set; get; } = 0;
        public virtual double Yield5 { set; get; } = 0;
        public virtual double TestTime6 { set; get; } = 0;
        public virtual int TestCount6 { set; get; } = 0;
        public virtual int PassCount6 { set; get; } = 0;
        public virtual int FailCount6 { set; get; } = 0;
        public virtual double Yield6 { set; get; } = 0;
        public virtual double TestTime7 { set; get; } = 0;
        public virtual int TestCount7 { set; get; } = 0;
        public virtual int PassCount7 { set; get; } = 0;
        public virtual int FailCount7 { set; get; } = 0;
        public virtual double Yield7 { set; get; } = 0;
        public virtual double TestTime0 { set; get; } = 0;
        public virtual int TestCount0 { set; get; } = 0;
        public virtual int PassCount0 { set; get; } = 0;
        public virtual int FailCount0 { set; get; } = 0;
        public virtual double Yield0 { set; get; } = 0;

        public virtual double TestTime1 { set; get; } = 0;
        public virtual int TestCount1 { set; get; } = 0;
        public virtual int PassCount1 { set; get; } = 0;
        public virtual int FailCount1 { set; get; } = 0;
        public virtual double Yield1 { set; get; } = 0;

        public virtual double TestTime2 { set; get; } = 0;
        public virtual int TestCount2 { set; get; } = 0;
        public virtual int PassCount2 { set; get; } = 0;
        public virtual int FailCount2 { set; get; } = 0;
        public virtual double Yield2 { set; get; } = 0;

        public virtual double TestTime3 { set; get; } = 0;
        public virtual int TestCount3 { set; get; } = 0;
        public virtual int PassCount3 { set; get; } = 0;
        public virtual int FailCount3 { set; get; } = 0;
        public virtual double Yield3 { set; get; } = 0;


        public virtual double TestIdle0 { set; get; } = 0;
        public virtual double TestIdle1 { set; get; } = 0;
        public virtual double TestIdle2 { set; get; } = 0;
        public virtual double TestIdle3 { set; get; } = 0;

        public virtual double TestCycle0 { set; get; } = 0;
        public virtual double TestCycle1 { set; get; } = 0;
        public virtual double TestCycle2 { set; get; } = 0;
        public virtual double TestCycle3 { set; get; } = 0;

        public virtual double TestCycleAve { set; get; } = 0;

        public virtual int TestCount0_Nomal { set; get; } = 0;
        public virtual int PassCount0_Nomal { set; get; } = 0;
        public virtual int FailCount0_Nomal { set; get; } = 0;
        public virtual double Yield0_Nomal { set; get; } = 0;


        public virtual int TestCount1_Nomal { set; get; } = 0;
        public virtual int PassCount1_Nomal { set; get; } = 0;
        public virtual int FailCount1_Nomal { set; get; } = 0;
        public virtual double Yield1_Nomal { set; get; } = 0;


        public virtual int TestCount2_Nomal { set; get; } = 0;
        public virtual int PassCount2_Nomal { set; get; } = 0;
        public virtual int FailCount2_Nomal { set; get; } = 0;
        public virtual double Yield2_Nomal { set; get; } = 0;


        public virtual int TestCount3_Nomal { set; get; } = 0;
        public virtual int PassCount3_Nomal { set; get; } = 0;
        public virtual int FailCount3_Nomal { set; get; } = 0;
        public virtual double Yield3_Nomal { set; get; } = 0;

        public virtual string TesterResult0 { set; get; } = "Unknow";
        public virtual string TesterResult1 { set; get; } = "Unknow";
        public virtual string TesterResult2 { set; get; } = "Unknow";
        public virtual string TesterResult3 { set; get; } = "Unknow";

        public virtual string TesterStatusForeground0 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground1 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground2 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground3 { set; get; } = "Yellow";

        public virtual string TesterStatusBackGround0 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround1 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround2 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround3 { set; get; } = "Gray";

        public virtual string TesterResult4 { set; get; } = "Unknow";
        public virtual string TesterResult5 { set; get; } = "Unknow";
        public virtual string TesterResult6 { set; get; } = "Unknow";
        public virtual string TesterResult7 { set; get; } = "Unknow";

        public virtual string TesterStatusForeground4 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground5 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground6 { set; get; } = "Yellow";
        public virtual string TesterStatusForeground7 { set; get; } = "Yellow";

        public virtual string TesterStatusBackGround4 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround5 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround6 { set; get; } = "Gray";
        public virtual string TesterStatusBackGround7 { set; get; } = "Gray";

        public virtual string TestRecordSavePath { set; get; }
        public virtual string AlarmSavePath { set; get; }

        public virtual int NGContinueNum { set; get; }
        public virtual int NGOverlayNum { set; get; }
        public virtual bool IsReleaseFailContinue { set; get; }
        public virtual bool isScanCheckFlag { set; get; }

        public virtual string AlarmTextString { set; get; }
        public virtual string AlarmTextGridShow { set; get; } = "Collapsed";
        public virtual string SampleTextString { set; get; }
        public virtual string SampleTextGridShow { set; get; } = "Collapsed";
        public virtual string HaoCaiYuJingGridShow { set; get; } = "Collapsed";
        public virtual string HaoCaiYuJingBackGroudColor { set; get; }
        public virtual string HaoCaiYuJingString { set; get; }
        public virtual bool PLCPause { set; get; } = false;

        public virtual int SingleTestModeStageNum { set; get; } = 1;
        public virtual bool SingleTestMode { set; get; } = false;

        public virtual bool isGRRMode { set; get; } = false;

        public virtual bool AABReTest { set; get; } = false;

        public virtual int SingleTestTimes { set; get; } = 0;
        public virtual string SingleTestTimesVisibility { set; get; } = "Collapsed";
        public virtual string LoginButtonString { set; get; } = "登录";
        public virtual string LoginUserName { set; get; } = "Leader";
        public virtual string LoginPassword { set; get; } = "jsldr";
        public virtual bool isLogin { set; get; } = false;
        public virtual bool BarcodeMode { set; get; } = true;

        public virtual string LastChuiqiTimeStr { set; get; }

        public virtual bool IsTestersClean { set; get; }
        public virtual bool IsTestersSample { set; get; }

        public virtual bool AllowCleanActionCommand { set; get; } = false;
        public virtual bool AllowSampleTestCommand { set; get; } = false;

        public virtual TwinCATCoil1 XPos { set; get; }
        public virtual TwinCATCoil1 YPos { set; get; }
        public virtual TwinCATCoil1 FPos { set; get; }
        public virtual TwinCATCoil1 TPos { set; get; }
       

        public virtual TwinCATCoil1 PickPositionX { set; get; }
        public virtual TwinCATCoil1 PickPositionY { set; get; }
        public virtual TwinCATCoil1 WaitPositionX { set; get; }
        public virtual TwinCATCoil1 WaitPositionY { set; get; }

        public virtual TwinCATCoil1 ReleasePositionX1 { set; get; }
        public virtual TwinCATCoil1 ReleasePositionY1 { set; get; }
        public virtual TwinCATCoil1 ReleasePositionX2 { set; get; }
        public virtual TwinCATCoil1 ReleasePositionY2 { set; get; }
        public virtual TwinCATCoil1 ReleasePositionX3 { set; get; }
        public virtual TwinCATCoil1 ReleasePositionY3 { set; get; }
        public virtual TwinCATCoil1 OutputSafedoorFlag { set; get; }
        public virtual TwinCATCoil1 PowerOn1 { set; get; }
        public virtual TwinCATCoil1 PowerOn2 { set; get; }
        public virtual TwinCATCoil1 PowerOn3 { set; get; }
        public virtual TwinCATCoil1 PowerOn4 { set; get; }

        public virtual TwinCATCoil1 ServoRst1 { set; get; }
        public virtual TwinCATCoil1 ServoRst2 { set; get; }
        public virtual TwinCATCoil1 ServoRst3 { set; get; }
        public virtual TwinCATCoil1 ServoRst4 { set; get; }

        public virtual TwinCATCoil1 ServoSVN1 { set; get; }
        public virtual TwinCATCoil1 ServoSVN2 { set; get; }
        public virtual TwinCATCoil1 ServoSVN3 { set; get; }
        public virtual TwinCATCoil1 ServoSVN4 { set; get; }


        //UnloadTrayCMD
        public virtual TwinCATCoil1 UnloadTrayCMD { set; get; }
        public virtual TwinCATCoil1 UnloadTrayFinish { set; get; }

        public virtual bool ServoHomed1 { set; get; }
        public virtual bool ServoHomed2 { set; get; }
        public virtual bool ServoHomed3 { set; get; }
        public virtual bool ServoHomed4 { set; get; }

        public virtual TwinCATCoil1 XRDY { set; get; }
        public virtual TwinCATCoil1 YRDY { set; get; }
        public virtual TwinCATCoil1 FRDY { set; get; }
        public virtual TwinCATCoil1 TRDY { set; get; }

        public virtual TwinCATCoil1 XYInDebug { set; get; }
        public virtual TwinCATCoil1 FInDebug { set; get; }
        public virtual TwinCATCoil1 TInDebug { set; get; }

        public virtual bool _XYInDebug { set; get; }
        public virtual bool _FInDebug { set; get; }
        public virtual bool _TInDebug { set; get; }

        public virtual TwinCATCoil1 EF104 { set; get; }
        public virtual TwinCATCoil1 EF114 { set; get; }

        public virtual TwinCATCoil1 EF100 { set; get; }
        public virtual TwinCATCoil1 EF101 { set; get; }
        public virtual TwinCATCoil1 EF102 { set; get; }
        public virtual TwinCATCoil1 EF110 { set; get; }
        public virtual TwinCATCoil1 EF111 { set; get; }
        public virtual TwinCATCoil1 EF112 { set; get; }



        public virtual TwinCATCoil1 DebugXTargetPositon { set; get; }
        public virtual TwinCATCoil1 DebugYTargetPositon { set; get; }

        public virtual TwinCATCoil1 DebugFTargetPositon { set; get; }
        public virtual TwinCATCoil1 DebugTTargetPositon { set; get; }

        public virtual TwinCATCoil1 Calc_Start { set; get; }

        public virtual TwinCATCoil1 FPosition1 { set; get; }
        public virtual TwinCATCoil1 FPosition2 { set; get; }
        public virtual TwinCATCoil1 FPosition3 { set; get; }
        public virtual TwinCATCoil1 FPosition4 { set; get; }
        public virtual TwinCATCoil1 FPosition5 { set; get; }
        public virtual TwinCATCoil1 FPosition6 { set; get; }
        public virtual TwinCATCoil1 FPosition7 { set; get; }
        public virtual TwinCATCoil1 FPosition8 { set; get; }

        public virtual TwinCATCoil1 TPosition1 { set; get; }
        public virtual TwinCATCoil1 TPosition2 { set; get; }
        public virtual TwinCATCoil1 TPosition3 { set; get; }
        public virtual TwinCATCoil1 TPosition4 { set; get; }
        public virtual TwinCATCoil1 TPosition5 { set; get; }
        public virtual TwinCATCoil1 TPosition6 { set; get; }
        public virtual TwinCATCoil1 TPosition7 { set; get; }

        public virtual TwinCATCoil1 F200 { set; get; }
        public virtual TwinCATCoil1 F201 { set; get; }
        public virtual TwinCATCoil1 F202 { set; get; }
        public virtual TwinCATCoil1 F204 { set; get; }

        public virtual TwinCATCoil1 T200 { set; get; }
        public virtual TwinCATCoil1 T201 { set; get; }
        public virtual TwinCATCoil1 T202 { set; get; }
        public virtual TwinCATCoil1 T204 { set; get; }

        public virtual TwinCATCoil1 FCmdIndex { set; get; }
        public virtual TwinCATCoil1 FMoveCMD { set; get; }
        public virtual TwinCATCoil1 FMoveCompleted { set; get; }

        public virtual TwinCATCoil1 TCmdIndex { set; get; }
        public virtual TwinCATCoil1 TMoveCMD { set; get; }
        public virtual TwinCATCoil1 TMoveCompleted { set; get; }

        public virtual TwinCATCoil1 TUnloadCMD { set; get; }
        public virtual TwinCATCoil1 TUnloadCompleted { set; get; }

        public virtual TwinCATCoil1 ResetCMDComplete { set; get; }
        public virtual TwinCATCoil1 ResetCMD { set; get; }

        public virtual TwinCATCoil1 PLCUnload { set; get; }
        public virtual TwinCATCoil1 WaitPLCUnload { set; get; }

        public virtual TwinCATCoil1 SaveButton { set; get; }
        public virtual TwinCATCoil1 SuckFailedFlag { set; get; }
        public virtual TwinCATCoil1 SuckAlarmRst { set; get; }
        public virtual bool _SuckFailedFlag { set; get; }

        public virtual TwinCATCoil1 M420 { set; get; }
        public virtual TwinCATCoil1 M1202 { set; get; }

        public virtual TwinCATCoil1 AlarmStr { set; get; }

        public virtual TwinCATCoil1 XYRDYtoDebug { set; get; }
        public virtual TwinCATCoil1 FRDYtoDebug { set; get; }
        public virtual TwinCATCoil1 TRDYtoDebug { set; get; }

        public virtual bool _XYRDYtoDebug { set; get; }
        public virtual bool _FRDYtoDebug { set; get; }
        public virtual bool _TRDYtoDebug { set; get; }

        public virtual TwinCATCoil1 XYStared { set; get; }

        public virtual TwinCATCoil1 XYDebugCMD { set; get; }
        public virtual TwinCATCoil1 FDebugCMD { set; get; }
        public virtual TwinCATCoil1 TDebugCMD { set; get; }

        public virtual TwinCATCoil1 XYDebugComplete { set; get; }
        public virtual TwinCATCoil1 FDebugComplete { set; get; }
        public virtual TwinCATCoil1 TDebugComplete { set; get; }

        public virtual TwinCATCoil1 M1202_1 { set; get; }
        public virtual TwinCATCoil1 Thave_1 { set; get; }
        public virtual TwinCATCoil1 Thave_2 { set; get; }

        public virtual TwinCATCoil1 WaitCmd1 { set; get; }

        public virtual TwinCATCoil1 XErrorCode { set; get; }
        public virtual TwinCATCoil1 YErrorCode { set; get; }
        public virtual TwinCATCoil1 FErrorCode { set; get; }
        public virtual TwinCATCoil1 TErrorCode { set; get; }

        public virtual TwinCATCoil1 BFI1 { set; get; }
        public virtual TwinCATCoil1 BFI2 { set; get; }
        public virtual TwinCATCoil1 BFI3 { set; get; }
        public virtual TwinCATCoil1 BFI4 { set; get; }
        public virtual TwinCATCoil1 BFI5 { set; get; }
        public virtual TwinCATCoil1 BFI6 { set; get; }
        public virtual TwinCATCoil1 BFI7 { set; get; }
        public virtual TwinCATCoil1 BFI8 { set; get; }
        public virtual TwinCATCoil1 BFI9 { set; get; }
        public virtual TwinCATCoil1 BFI10 { set; get; }
        public virtual TwinCATCoil1 BFI11 { set; get; }
        public virtual TwinCATCoil1 BFI12 { set; get; }
        public virtual TwinCATCoil1 BFI13 { set; get; }

        public virtual TwinCATCoil1 BFO1 { set; get; }
        public virtual TwinCATCoil1 BFO2 { set; get; }
        public virtual TwinCATCoil1 BFO3 { set; get; }
        public virtual TwinCATCoil1 BFO4 { set; get; }
        public virtual TwinCATCoil1 BFO5 { set; get; }
        public virtual TwinCATCoil1 BFO6 { set; get; }
        public virtual TwinCATCoil1 BFO7 { set; get; }
        public virtual TwinCATCoil1 BFO8 { set; get; }
        public virtual TwinCATCoil1 BFO9 { set; get; }
        public virtual TwinCATCoil1 BFO10 { set; get; }
        public virtual TwinCATCoil1 BFO11 { set; get; }
        public virtual TwinCATCoil1 BFO12 { set; get; }
        public virtual TwinCATCoil1 BFO13 { set; get; }
        public virtual TwinCATCoil1 BFO14 { set; get; }
        public virtual TwinCATCoil1 BFO15 { set; get; }
        public virtual TwinCATCoil1 BFO16 { set; get; }

        public virtual TwinCATCoil1 PLCPreSuck { set; get; }
        public virtual string SQL_ora_server { set; get; }
        public virtual string SQL_ora_user { set; get; }
        public virtual string SQL_ora_pwd { set; get; }

        public virtual string Barsamuser_Uname { set; get; } = "ADMIN";
        public virtual string Barsamuser_Psw { set; get; }
        public virtual bool SamCheckinIsEnabled { set; get; }

        public virtual string Barsaminfo_Partnum { set; get; }
        public virtual string Barsaminfo_Barcode { set; get; }
        public virtual uint Barsaminfo_Stnum { set; get; } = 1000;
        public virtual uint Barsaminfo_Unum { set; get; } = 0;

        public virtual string DBSearch_Barcode { set; get; }

        public virtual string[] BarsamTableNames { set; get; } = new string[3] { "BARSAMINFO", "BARSAMREC", "FLUKE_DATA" };
        public virtual ushort BarsamTableIndex { set; get; } = 0;

        public virtual string[] SamNgItemsTableNames { set; get; } = new string[2] { "OK", "NG" };
        public virtual ushort SamNgItemsTableIndex { set; get; } = 0;

        public virtual DataTable SinglDt { set; get; }
        public virtual bool IsDBConnect { set; get; }

        public virtual bool SampleHave1 { set; get; }
        public virtual bool SampleHave2 { set; get; }
        public virtual bool SampleHave3 { set; get; }
        public virtual bool SampleHave4 { set; get; }
        public virtual bool SampleHave5 { set; get; }
        public virtual bool SampleHave6 { set; get; }
        public virtual bool SampleHave7 { set; get; }
        public virtual bool SampleHave8 { set; get; }
        public virtual bool SampleHave9 { set; get; }
        public virtual bool SampleHave10 { set; get; }
        public virtual bool SampleHave11 { set; get; }
        public virtual bool SampleHave12 { set; get; }
        public virtual string SampleData1 { set; get; }
        public virtual string SampleData2 { set; get; }
        public virtual string SampleData3 { set; get; }
        public virtual string SampleData4 { set; get; }
        public virtual string SampleData5 { set; get; }
        public virtual string SampleData6 { set; get; }
        public virtual string SampleData7 { set; get; }
        public virtual string SampleData8 { set; get; }
        public virtual string SampleData9 { set; get; }
        public virtual string SampleData10 { set; get; }
        public virtual string SampleData11 { set; get; }
        public virtual string SampleData12 { set; get; }

        public virtual string Barsamrec_Partnum { set; get; }
        public virtual string Barsamrec_Mno { set; get; }
        public virtual string Barsamrec_ID1 { set; get; }
        public virtual string Barsamrec_ID2 { set; get; }
        public virtual string Barsamrec_ID3 { set; get; }
        public virtual string Barsamrec_ID4 { set; get; }

        public virtual double SampleTimeElapse { set; get; }

        public virtual string LastSampleTestTimeStr { set; get; }

        public virtual string SampleRetestButtonVisibility { set; get; } = "Collapsed";

        public virtual ushort SampleNgitemsNum { set; get; } = 2;
        public virtual string OperateModeStr { set; get; } = "正常";
        public virtual ushort[] PcsGrrNeedNums { set; get; } = new ushort[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        public virtual ushort PcsGrrNeedNum { set; get; } = 0;
        public virtual ushort[] PcsGrrNeedCounts { set; get; } = new ushort[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        public virtual ushort PcsGrrNeedCount { set; get; } = 0;

        public virtual string SampleNgitem1 { set; get; }
        public virtual string SampleNgitem2 { set; get; }
        public virtual string SampleNgitem3 { set; get; }
        public virtual string SampleNgitem4 { set; get; }
        public virtual string SampleNgitem5 { set; get; }
        public virtual string SampleNgitem6 { set; get; }
        public virtual string SampleNgitem7 { set; get; }
        public virtual string SampleNgitem8 { set; get; }
        public virtual string SampleNgitem9 { set; get; }
        public virtual string SampleNgitem10 { set; get; }

        public virtual double PassMid { set; get; }
        public virtual double PassLowLimit { set; get; }
        public virtual double PassLowLimitStop { set; get; }
        public virtual int PassLowLimitStopNum { set; get; }
        public virtual bool IsPassLowLimitStop { set; get; }


        public virtual double FlexTestTimeout { set; get; }
        public virtual double FlexTestNomalTime { set; get; }

        public virtual string PassStatusDisplay1 { set; get; }
        public virtual string PassStatusDisplay2 { set; get; }
        public virtual string PassStatusDisplay3 { set; get; }
        public virtual string PassStatusDisplay4 { set; get; }
        public virtual string PassStatusDisplay5 { set; get; }
        public virtual string PassStatusDisplay6 { set; get; }
        public virtual string PassStatusDisplay7 { set; get; }
        public virtual string PassStatusDisplay8 { set; get; }
        public virtual string PassStatusColor1 { set; get; }
        public virtual string PassStatusColor2 { set; get; }
        public virtual string PassStatusColor3 { set; get; }
        public virtual string PassStatusColor4 { set; get; }
        public virtual string PassStatusColor5 { set; get; }
        public virtual string PassStatusColor6 { set; get; }
        public virtual string PassStatusColor7 { set; get; }
        public virtual string PassStatusColor8 { set; get; }

        public virtual bool IsCheckUploadStatus { set; get; }

        public virtual string SampleItemsStatus0 { set; get; }
        public virtual string SampleItemsStatus1 { set; get; }
        public virtual string SampleItemsStatus2 { set; get; }
        public virtual string SampleItemsStatus3 { set; get; }
        public virtual string SampleItemsStatus4 { set; get; }
        public virtual string SampleItemsStatus5 { set; get; }
        public virtual string SampleItemsStatus6 { set; get; }
        public virtual string SampleItemsStatus7 { set; get; }
        public virtual string SampleItemsStatus8 { set; get; }
        public virtual string SampleItemsStatus9 { set; get; }

        public virtual string SampleItemsStatus10 { set; get; }
        public virtual string SampleItemsStatus11 { set; get; }
        public virtual string SampleItemsStatus12 { set; get; }
        public virtual string SampleItemsStatus13 { set; get; }
        public virtual string SampleItemsStatus14 { set; get; }
        public virtual string SampleItemsStatus15 { set; get; }
        public virtual string SampleItemsStatus16 { set; get; }
        public virtual string SampleItemsStatus17 { set; get; }
        public virtual string SampleItemsStatus18 { set; get; }
        public virtual string SampleItemsStatus19 { set; get; }

        public virtual string SampleItemsStatus20 { set; get; }
        public virtual string SampleItemsStatus21 { set; get; }
        public virtual string SampleItemsStatus22 { set; get; }
        public virtual string SampleItemsStatus23 { set; get; }
        public virtual string SampleItemsStatus24 { set; get; }
        public virtual string SampleItemsStatus25 { set; get; }
        public virtual string SampleItemsStatus26 { set; get; }
        public virtual string SampleItemsStatus27 { set; get; }
        public virtual string SampleItemsStatus28 { set; get; }
        public virtual string SampleItemsStatus29 { set; get; }

        public virtual string SampleItemsStatus30 { set; get; }
        public virtual string SampleItemsStatus31 { set; get; }
        public virtual string SampleItemsStatus32 { set; get; }
        public virtual string SampleItemsStatus33 { set; get; }
        public virtual string SampleItemsStatus34 { set; get; }
        public virtual string SampleItemsStatus35 { set; get; }
        public virtual string SampleItemsStatus36 { set; get; }
        public virtual string SampleItemsStatus37 { set; get; }
        public virtual string SampleItemsStatus38 { set; get; }
        public virtual string SampleItemsStatus39 { set; get; }

        public virtual bool ShowSampleTestWindow { set; get; }
        public virtual bool QuitSampleTest { set; get; }

        public virtual bool ShowYieldAdminControlWindow { set; get; }
        public virtual bool QuitYieldAdminControl { set; get; }
        public virtual bool ShowDiaoLiaoWindow { set; get; }
        public virtual bool QuitDiaoLiaoWindow { set; get; }
        public virtual bool SampleWindowCloseEnable { set; get; } = true;

        public virtual int TotalAlarmNum { set; get; } = 0;
        public virtual double SampleWaitTime { set; get; } = 0;
        public virtual string SampleWaitTimeShow { set; get; } = "Collapsed";
        public virtual bool AdminControl { set; get; } = false;
        public virtual bool IsCheckINI { set; get; }
        public virtual string LastSampleTestFinishTime { set; get; }
        public virtual double SampleTestTimeSpan { set; get; }
        public virtual string AdminButtonVisibility { set; get; } = "Collapsed";
        public virtual string AdminPasswordstr { set; get; } = "";
        public virtual string AdminPasswordPageVisibility { set; get; } = "Collapsed";
        public virtual string AdminOperatePageVisibility { set; get; } = "Collapsed";
        public virtual int YieldAddNum1 { set; get; }
        public virtual int YieldAddNum2 { set; get; }
        public virtual int YieldAddNum3 { set; get; }
        public virtual int YieldAddNum4 { set; get; }
        public virtual bool YieldAddNum1Enable { set; get; }
        public virtual bool YieldAddNum2Enable { set; get; }
        public virtual bool YieldAddNum3Enable { set; get; }
        public virtual bool YieldAddNum4Enable { set; get; }
        public virtual int YieldNowNum1 { set; get; }
        public virtual int YieldNowNum2 { set; get; }
        public virtual int YieldNowNum3 { set; get; }
        public virtual int YieldNowNum4 { set; get; }
        public virtual bool WaitPcsFlag { set; get; }

        

        

        public virtual TwinCATCoil1 SuckCMD { set; get; }
        public virtual TwinCATCoil1 TRAYEmpty { set; get; }

        public virtual TwinCATCoil1 RollSet { set; get; }
        public virtual TwinCATCoil1 RollReset { set; get; }

        public virtual TwinCATCoil1 EmptyCMD { set; get; }
        public virtual TwinCATCoil1 PhotoCMD { set; get; }
        //public virtual TwinCATCoil1 NoPhotoCMD { set; get; }
        public virtual TwinCATCoil1 NoDown { set; get; }

        public virtual TwinCATCoil1 PhotoComplete { set; get; }
    
        public virtual TwinCATCoil1 E4 { set; get; }
        public virtual TwinCATCoil1 F4 { set; get; }
        public virtual TwinCATCoil1 G4 { set; get; }
        public virtual TwinCATCoil1 H4 { set; get; }
        public virtual TwinCATCoil1 J4 { set; get; }
        public virtual TwinCATCoil1 K4 { set; get; }

        public virtual TwinCATCoil1 E5 { set; get; }
        public virtual TwinCATCoil1 F5 { set; get; }
        public virtual TwinCATCoil1 G5 { set; get; }
        public virtual TwinCATCoil1 H5 { set; get; }
        public virtual TwinCATCoil1 J5 { set; get; }
        public virtual TwinCATCoil1 K5 { set; get; }
        public virtual TwinCATCoil1 ShangLiao { set; get; }
        public virtual TwinCATCoil1 ShangLiaoFlag { set; get; }

        public virtual string ZhiJu1ZuoBupin1 { set; get; }
        public virtual string ZhiJu1ZuoBupin2 { set; get; }
        public virtual string ZhiJu1ZuoBupin3 { set; get; }
        public virtual string ZhiJu1ZuoBupin4 { set; get; }
        public virtual string ZhiJu1ZuoBupin5 { set; get; }
        public virtual int ZhiJu1ZuoDangqian1 { set; get; }
        public virtual int ZhiJu1ZuoDangqian2 { set; get; }
        public virtual int ZhiJu1ZuoDangqian3 { set; get; }
        public virtual int ZhiJu1ZuoDangqian4 { set; get; }
        public virtual int ZhiJu1ZuoDangqian5 { set; get; }
        public virtual int ZhiJu1ZuoShouMing1 { set; get; }
        public virtual int ZhiJu1ZuoShouMing2 { set; get; }
        public virtual int ZhiJu1ZuoShouMing3 { set; get; }
        public virtual int ZhiJu1ZuoShouMing4 { set; get; }
        public virtual int ZhiJu1ZuoShouMing5 { set; get; }
        public virtual int ZhiJu1ZuoYujing1 { set; get; }
        public virtual int ZhiJu1ZuoYujing2 { set; get; }
        public virtual int ZhiJu1ZuoYujing3 { set; get; }
        public virtual int ZhiJu1ZuoYujing4 { set; get; }
        public virtual int ZhiJu1ZuoYujing5 { set; get; }

        public virtual string ZhiJu1YouBupin1 { set; get; }
        public virtual string ZhiJu1YouBupin2 { set; get; }
        public virtual string ZhiJu1YouBupin3 { set; get; }
        public virtual string ZhiJu1YouBupin4 { set; get; }
        public virtual string ZhiJu1YouBupin5 { set; get; }
        public virtual int ZhiJu1YouDangqian1 { set; get; }
        public virtual int ZhiJu1YouDangqian2 { set; get; }
        public virtual int ZhiJu1YouDangqian3 { set; get; }
        public virtual int ZhiJu1YouDangqian4 { set; get; }
        public virtual int ZhiJu1YouDangqian5 { set; get; }
        public virtual int ZhiJu1YouShouMing1 { set; get; }
        public virtual int ZhiJu1YouShouMing2 { set; get; }
        public virtual int ZhiJu1YouShouMing3 { set; get; }
        public virtual int ZhiJu1YouShouMing4 { set; get; }
        public virtual int ZhiJu1YouShouMing5 { set; get; }
        public virtual int ZhiJu1YouYujing1 { set; get; }
        public virtual int ZhiJu1YouYujing2 { set; get; }
        public virtual int ZhiJu1YouYujing3 { set; get; }
        public virtual int ZhiJu1YouYujing4 { set; get; }
        public virtual int ZhiJu1YouYujing5 { set; get; }

        public virtual string ZhiJu2ZuoBupin1 { set; get; }
        public virtual string ZhiJu2ZuoBupin2 { set; get; }
        public virtual string ZhiJu2ZuoBupin3 { set; get; }
        public virtual string ZhiJu2ZuoBupin4 { set; get; }
        public virtual string ZhiJu2ZuoBupin5 { set; get; }
        public virtual int ZhiJu2ZuoDangqian1 { set; get; }
        public virtual int ZhiJu2ZuoDangqian2 { set; get; }
        public virtual int ZhiJu2ZuoDangqian3 { set; get; }
        public virtual int ZhiJu2ZuoDangqian4 { set; get; }
        public virtual int ZhiJu2ZuoDangqian5 { set; get; }
        public virtual int ZhiJu2ZuoShouMing1 { set; get; }
        public virtual int ZhiJu2ZuoShouMing2 { set; get; }
        public virtual int ZhiJu2ZuoShouMing3 { set; get; }
        public virtual int ZhiJu2ZuoShouMing4 { set; get; }
        public virtual int ZhiJu2ZuoShouMing5 { set; get; }
        public virtual int ZhiJu2ZuoYujing1 { set; get; }
        public virtual int ZhiJu2ZuoYujing2 { set; get; }
        public virtual int ZhiJu2ZuoYujing3 { set; get; }
        public virtual int ZhiJu2ZuoYujing4 { set; get; }
        public virtual int ZhiJu2ZuoYujing5 { set; get; }

        public virtual string ZhiJu2YouBupin1 { set; get; }
        public virtual string ZhiJu2YouBupin2 { set; get; }
        public virtual string ZhiJu2YouBupin3 { set; get; }
        public virtual string ZhiJu2YouBupin4 { set; get; }
        public virtual string ZhiJu2YouBupin5 { set; get; }
        public virtual int ZhiJu2YouDangqian1 { set; get; }
        public virtual int ZhiJu2YouDangqian2 { set; get; }
        public virtual int ZhiJu2YouDangqian3 { set; get; }
        public virtual int ZhiJu2YouDangqian4 { set; get; }
        public virtual int ZhiJu2YouDangqian5 { set; get; }
        public virtual int ZhiJu2YouShouMing1 { set; get; }
        public virtual int ZhiJu2YouShouMing2 { set; get; }
        public virtual int ZhiJu2YouShouMing3 { set; get; }
        public virtual int ZhiJu2YouShouMing4 { set; get; }
        public virtual int ZhiJu2YouShouMing5 { set; get; }
        public virtual int ZhiJu2YouYujing1 { set; get; }
        public virtual int ZhiJu2YouYujing2 { set; get; }
        public virtual int ZhiJu2YouYujing3 { set; get; }
        public virtual int ZhiJu2YouYujing4 { set; get; }
        public virtual int ZhiJu2YouYujing5 { set; get; }

        public virtual int JiTaiDangqian1 { set; get; }
        public virtual int JiTaiDangqian2 { set; get; }
        public virtual int JiTaiDangqian3 { set; get; }
        public virtual int JiTaiDangqian4 { set; get; }
        public virtual int JiTaiDangqian5 { set; get; }
        public virtual int JiTaiDangqian6 { set; get; }
        public virtual int JiTaiShouMing1 { set; get; }
        public virtual int JiTaiShouMing2 { set; get; }
        public virtual int JiTaiShouMing3 { set; get; }
        public virtual int JiTaiShouMing4 { set; get; }
        public virtual int JiTaiShouMing5 { set; get; }
        public virtual int JiTaiShouMing6 { set; get; }
        public virtual int JiTaiYujing1 { set; get; }
        public virtual int JiTaiYujing2 { set; get; }
        public virtual int JiTaiYujing3 { set; get; }
        public virtual int JiTaiYujing4 { set; get; }
        public virtual int JiTaiYujing5 { set; get; }
        public virtual int JiTaiYujing6 { set; get; }

        

        

        #endregion
        #region 变量定义区域
        //private int WarnTimeSec1 = 0, WarnTimeSec2 = 0, WarnTimeSec3 = 0, WarnTimeSec4 = 0, WarnTimeSec5 = 0, WarnTimeSec6 = 0, WarnTimeSec7 = 0, WarnTimeSec8 = 0, WarnTimeSec9 = 0;
        //private bool WarnTimeFlag1 = false, WarnTimeFlag2 = false, WarnTimeFlag3 = false, WarnTimeFlag4 = false, WarnTimeFlag5 = false, WarnTimeFlag6 = false, WarnTimeFlag7 = false, WarnTimeFlag8 = false, WarnTimeFlag9 = false;
        private bool downtimeflag = false, jigdowntimeflag = false, waitforinputflag = false, waitfortrayflag = false, waitfortakeflag = false;
        private MessagePrint messagePrint = new MessagePrint();
        private dialog mydialog = new dialog();
        private string iniParameterPath = System.Environment.CurrentDirectory + "\\Parameter.ini";
        private string iniAlarmRecordPath = System.Environment.CurrentDirectory + "\\AlarmRecord.ini";
        private string TwincatParameterPath = System.Environment.CurrentDirectory + "\\TwincatParameter.ini";
        private string iniTesterResutPath = System.Environment.CurrentDirectory + "\\TesterResut.ini";
        private string iniTimeCalcPath = System.Environment.CurrentDirectory + "\\TimeCalc.ini";
        private string iniAdminControl = @"C:\WINDOWS\AdminControl.ini";
        private string iniPassWord = @"C:\PassWord.ini";
        private string iniFClient = @"C:\FClient.ini";
        private string LimitSwStatusRecord = @"C:\WINDOWS\LimitSwStatus.csv";
        //private XinjiePlc XinjiePLC;
        ThingetPLC Xinjie;
        private HdevEngine hdevEngine = new HdevEngine();
        //private HdevEngine hdevScanEngine = new HdevEngine();
        private EpsonRC90 epsonRC90 = new EpsonRC90();
        private bool NeedNoiseReduce = false;
        private bool NeedLoadMaters = false;
        private bool NeedUnloadMaters = false;
        //private string PreFeedFillStr = "FeedFill;0;0;0;0;0;0;";
        Queue<TestRecord> myTestRecordQueue = new Queue<TestRecord>();
        Queue<AlarmRecord> myAlarmRecordQueue = new Queue<AlarmRecord>();
        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private bool PLCNeedContinue = false;
        private DateTimeUtility.SYSTEMTIME lastchuiqi = new DateTimeUtility.SYSTEMTIME();

        private DateTimeUtility.SYSTEMTIME lastSample = new DateTimeUtility.SYSTEMTIME();

        TwinCATAds _TwinCATAds = new TwinCATAds();
        double DebugTargetX = 0;
        double DebugTargetH = 0;
        double DebugTargetS = 0;
        double DebugTargetY = 0;
        double DebugTargetF = 0;
        double DebugTargetT = 0;
        ushort fti = 1;

        bool EStop = false;

        bool isCheckined, isCheckinSuccessed;
        bool SampleAlarm_IsNeedCheckin = false, SampleAlarm_IsNeedCheckin_finish = false, NeedCheckin = false;

        DataTable SampleDt = new DataTable();

        List<AlarmTableItem> alarmTableItemsList = new List<AlarmTableItem>();

        int AlarmLastDayofYear = 0;
        bool Alarm_allowClean = true;
        string lastAlarmString = "";

        int AlarmLastClearHourofYear = 0;
        bool isIn8or20 = false;
        bool _isIn8or20 = false;

        string AlarmLastDateNameStr = "";
        private int LastSampleHour = -1;

        //int aaa = 0;

        private string[,] SampleDisplayArray = new string[4, 10];
        private bool SampleWaitTime_Cancel = false;
        private ushort UpdateSeverTimes = 0;
        private bool _AutoClean = false;

        double waitforinput = 0;
        int inputtimes = 0;
        //int downtimes = 0;
        double downtime = 0;
        double runtime = 0;
        double totaltime = 0;

        ushort WaitPcsSecend = 0;
        ObservableCollection<bool> XinJieOut;
        bool[] XinJieIn = new bool[64];
        bool[] XinJiePhotoResult = new bool[128];
        private List<QuiLiaoBarcode> QueLiaoWorkList = new List<QuiLiaoBarcode>();
        private List<QuiLiaoBarcode> QueLiaoTable1 = new List<QuiLiaoBarcode>();

        uint liaoCountIN = 0, liaoCountOUT = 0;
        uint liaoinput = 0, liaooutput = 0;

        string LastCleanAlarmDatetime;
        bool RobotPauseCompleteFlag = false;


        double down_min = 0, jigdown_min = 0, waitinput_min = 0, waittray_min = 0, waittake_min = 0, run_min = 0, world_min = 0,work_min = 0;
        bool down_flag = false, jigdown_flag = false, waitinput_flag = false, waittray_flag = false, waittake_flag = false,work_flag = false;
        short tick_secend = 0;
        double AchievingRate, ProperRate, ProperRate_AutoMation, ProperRate_Jig;
        string DangbanFirstProduct = "";

        bool[] _fill = new bool[80];
        bool RobotRestarted = false;
        #endregion
        #region 构造函数
        public MainDataContext()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    SampleDisplayArray[i, j] = "";
                }
            }
            epsonRC90.ModelPrint += ModelPrintEventProcess;
            epsonRC90.EPSONCommTwincat += EPSONCommTwincatEventProcess;
      
            epsonRC90.EPSONDBSearch += EPSONDBSearchEventProcess;
            epsonRC90.EPSONSampleResult += EPSONSampleResultProcess;
            //epsonRC90.EPSONSampleHave += EPSONSampleHaveProcess;
            epsonRC90.EPSONSelectSampleResultfromDt += EPSONSelectSampleResultfromDtProcess;
            epsonRC90.EPSONGRRTimesAsk += EPSONEPSONGRRTimesAskProcess;
            epsonRC90.EpsonStatusUpdate += EpsonStatusUpdateProcess;
            //epsonRC90.ScanUpdate += ScanUpdateProcess;
            //epsonRC90.ScanP3Update += ScanP3UpdateProcess;
            //epsonRC90.ScanP3Update1 += ScanP3Update1Process;
            epsonRC90.TestFinished += StartUpdateProcess;
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTickUpdateUi);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            SampleDt.Columns.Add("PARTNUM", typeof(string));
            SampleDt.Columns.Add("SITEM", typeof(string));
            SampleDt.Columns.Add("BARCODE", typeof(string));
            SampleDt.Columns.Add("NGITEM", typeof(string));
            SampleDt.Columns.Add("TRES", typeof(string));
            SampleDt.Columns.Add("MNO", typeof(string));
            SampleDt.Columns.Add("CDATE", typeof(string));
            SampleDt.Columns.Add("CTIME", typeof(string));
            SampleDt.Columns.Add("SR01", typeof(string));
            SampleDt.Columns.Add("FL02", typeof(string));
            SampleDt.Columns.Add("FL03", typeof(string));

            alarmTableItemsList.Add(new AlarmTableItem("Station1"));
            alarmTableItemsList.Add(new AlarmTableItem("Station2"));
            alarmTableItemsList.Add(new AlarmTableItem("Station3"));
            alarmTableItemsList.Add(new AlarmTableItem("Station4"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition1"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition2"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition3"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition4"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition5"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition6"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition7"));
            alarmTableItemsList.Add(new AlarmTableItem("LoadPanelPosition8"));

            ReadAlarmRecord();

            TwinCatVarInit();


            Async.RunFuncAsync(UpdateUI, null);
            epsonRC90.InitBarcodeList();
        }
        private void TwinCatVarInit()
        {
            XPos = new TwinCATCoil1(new TwinCATCoil("MAIN.XPos", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            YPos = new TwinCATCoil1(new TwinCATCoil("MAIN.YPos", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPos = new TwinCATCoil1(new TwinCATCoil("MAIN.FPos", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPos = new TwinCATCoil1(new TwinCATCoil("MAIN.TPos", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            PickPositionX = new TwinCATCoil1(new TwinCATCoil("MAIN.PickPositionX", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PickPositionY = new TwinCATCoil1(new TwinCATCoil("MAIN.PickPositionY", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            WaitPositionX = new TwinCATCoil1(new TwinCATCoil("MAIN.WaitPositionX", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            WaitPositionY = new TwinCATCoil1(new TwinCATCoil("MAIN.WaitPositionY", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            ReleasePositionX1 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionX1", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ReleasePositionY1 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionY1", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ReleasePositionX2 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionX2", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ReleasePositionY2 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionY2", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ReleasePositionX3 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionX3", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ReleasePositionY3 = new TwinCATCoil1(new TwinCATCoil("MAIN.ReleasePositionY3", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            OutputSafedoorFlag = new TwinCATCoil1(new TwinCATCoil("MAIN.OutputSafedoorFlag", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            PowerOn1 = new TwinCATCoil1(new TwinCATCoil("MAIN.PowerOn1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PowerOn2 = new TwinCATCoil1(new TwinCATCoil("MAIN.PowerOn2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PowerOn3 = new TwinCATCoil1(new TwinCATCoil("MAIN.PowerOn3", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PowerOn4 = new TwinCATCoil1(new TwinCATCoil("MAIN.PowerOn4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            ServoRst1 = new TwinCATCoil1(new TwinCATCoil("MAIN.E2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoRst2 = new TwinCATCoil1(new TwinCATCoil("MAIN.F2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoRst3 = new TwinCATCoil1(new TwinCATCoil("MAIN.G2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoRst4 = new TwinCATCoil1(new TwinCATCoil("MAIN.H2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            ServoSVN1 = new TwinCATCoil1(new TwinCATCoil("MAIN.E1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoSVN2 = new TwinCATCoil1(new TwinCATCoil("MAIN.F1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoSVN3 = new TwinCATCoil1(new TwinCATCoil("MAIN.G1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ServoSVN4 = new TwinCATCoil1(new TwinCATCoil("MAIN.H1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);


            UnloadTrayCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.UnloadTrayCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            UnloadTrayFinish = new TwinCATCoil1(new TwinCATCoil("MAIN.UnloadTrayFinish", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PLCPreSuck = new TwinCATCoil1(new TwinCATCoil("MAIN.PLCPreSuck", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XRDY = new TwinCATCoil1(new TwinCATCoil("MAIN.XRDY", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            YRDY = new TwinCATCoil1(new TwinCATCoil("MAIN.YRDY", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FRDY = new TwinCATCoil1(new TwinCATCoil("MAIN.FRDY", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TRDY = new TwinCATCoil1(new TwinCATCoil("MAIN.TRDY", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XYInDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.XYInDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FInDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.FInDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TInDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.TInDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            EF104 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF104", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF114 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF114", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            EF100 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF100", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF101 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF101", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF102 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF102", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF110 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF110", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF111 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF111", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            EF112 = new TwinCATCoil1(new TwinCATCoil("MAIN.EF112", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            DebugXTargetPositon = new TwinCATCoil1(new TwinCATCoil("MAIN.DebugXTargetPositon", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            DebugYTargetPositon = new TwinCATCoil1(new TwinCATCoil("MAIN.DebugYTargetPositon", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            DebugFTargetPositon = new TwinCATCoil1(new TwinCATCoil("MAIN.DebugFTargetPositon", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            DebugTTargetPositon = new TwinCATCoil1(new TwinCATCoil("MAIN.DebugTTargetPositon", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            Calc_Start = new TwinCATCoil1(new TwinCATCoil("MAIN.Calc_Start", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            FPosition1 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition1", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition2 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition2", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition3 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition3", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition4 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition4", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition5 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition5", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition6 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition6", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition7 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition7", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FPosition8 = new TwinCATCoil1(new TwinCATCoil("MAIN.FPosition8", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            TPosition1 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition1", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition2 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition2", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition3 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition3", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition4 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition4", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition5 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition5", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition6 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition6", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TPosition7 = new TwinCATCoil1(new TwinCATCoil("MAIN.TPosition7", typeof(double), TwinCATCoil.Mode.Notice), _TwinCATAds);

            F200 = new TwinCATCoil1(new TwinCATCoil("MAIN.F200", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            F201 = new TwinCATCoil1(new TwinCATCoil("MAIN.F201", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            F202 = new TwinCATCoil1(new TwinCATCoil("MAIN.F202", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            F204 = new TwinCATCoil1(new TwinCATCoil("MAIN.F204", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            T200 = new TwinCATCoil1(new TwinCATCoil("MAIN.T200", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            T201 = new TwinCATCoil1(new TwinCATCoil("MAIN.T201", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            T202 = new TwinCATCoil1(new TwinCATCoil("MAIN.T202", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            T204 = new TwinCATCoil1(new TwinCATCoil("MAIN.T204", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            FMoveCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.FMoveCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FMoveCompleted = new TwinCATCoil1(new TwinCATCoil("MAIN.FMoveCompleted", typeof(bool), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);
            FCmdIndex = new TwinCATCoil1(new TwinCATCoil("MAIN.FCmdIndex", typeof(ushort), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);

            TMoveCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.TMoveCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TMoveCompleted = new TwinCATCoil1(new TwinCATCoil("MAIN.TMoveCompleted", typeof(bool), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);
            TCmdIndex = new TwinCATCoil1(new TwinCATCoil("MAIN.TCmdIndex", typeof(ushort), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);

            TUnloadCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.TUnloadCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TUnloadCompleted = new TwinCATCoil1(new TwinCATCoil("MAIN.TUnloadCompleted", typeof(bool), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);

            ResetCMDComplete = new TwinCATCoil1(new TwinCATCoil("MAIN.ResetCMDComplete", typeof(bool), TwinCATCoil.Mode.Notice, 1), _TwinCATAds);
            ResetCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.ResetCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            PLCUnload = new TwinCATCoil1(new TwinCATCoil("MAIN.PLCUnload", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            WaitPLCUnload = new TwinCATCoil1(new TwinCATCoil("MAIN.WaitPLCUnload", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            SaveButton = new TwinCATCoil1(new TwinCATCoil("MAIN.SaveButton", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            SuckFailedFlag = new TwinCATCoil1(new TwinCATCoil("MAIN.SuckFailedFlag", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            SuckAlarmRst = new TwinCATCoil1(new TwinCATCoil("MAIN.SuckAlarmRst", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            M420 = new TwinCATCoil1(new TwinCATCoil("MAIN.M420", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            M1202 = new TwinCATCoil1(new TwinCATCoil("MAIN.M1202", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            AlarmStr = new TwinCATCoil1(new TwinCATCoil("MAIN.AlarmStr", typeof(string), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XYRDYtoDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.XYRDYtoDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            
            FRDYtoDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.FRDYtoDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TRDYtoDebug = new TwinCATCoil1(new TwinCATCoil("MAIN.TRDYtoDebug", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XYDebugCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.XYDebugCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            
            FDebugCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.FDebugCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TDebugCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.TDebugCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            XYStared = new TwinCATCoil1(new TwinCATCoil("MAIN.XYStared", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XYDebugComplete = new TwinCATCoil1(new TwinCATCoil("MAIN.XYDebugComplete", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            
            FDebugComplete = new TwinCATCoil1(new TwinCATCoil("MAIN.FDebugComplete", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TDebugComplete = new TwinCATCoil1(new TwinCATCoil("MAIN.TDebugComplete", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            M1202_1 = new TwinCATCoil1(new TwinCATCoil("MAIN.M1202_1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            Thave_1 = new TwinCATCoil1(new TwinCATCoil("MAIN.Thave_1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            Thave_2 = new TwinCATCoil1(new TwinCATCoil("MAIN.Thave_2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            WaitCmd1 = new TwinCATCoil1(new TwinCATCoil("MAIN.WaitCmd1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            XErrorCode = new TwinCATCoil1(new TwinCATCoil("MAIN.XErrorCode", typeof(uint), TwinCATCoil.Mode.Notice), _TwinCATAds);
            YErrorCode = new TwinCATCoil1(new TwinCATCoil("MAIN.YErrorCode", typeof(uint), TwinCATCoil.Mode.Notice), _TwinCATAds);
            FErrorCode = new TwinCATCoil1(new TwinCATCoil("MAIN.FErrorCode", typeof(uint), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TErrorCode = new TwinCATCoil1(new TwinCATCoil("MAIN.TErrorCode", typeof(uint), TwinCATCoil.Mode.Notice), _TwinCATAds);
            

            BFI1 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI2 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI3 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI3", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI4 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI5 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI6 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI6", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI7 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI7", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI8 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI8", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI9 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI9", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI10 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI10", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI11 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI11", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI12 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI12", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFI13 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFI13", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            BFO1 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO1", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO2 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO2", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO3 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO3", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO4 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO5 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO6 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO6", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO7 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO7", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO8 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO8", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO9 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO9", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO10 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO10", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO11 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO11", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO12 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO12", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO13 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO13", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO14 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO14", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO15 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO15", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            BFO16 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO16", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            BFO15 = new TwinCATCoil1(new TwinCATCoil("MAIN.BFO15", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            

            
            
            SuckCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.SuckCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            TRAYEmpty = new TwinCATCoil1(new TwinCATCoil("MAIN.TRAYEmpty", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            
            EmptyCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.EmptyCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            //NoPhotoCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.NoPhotoCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            NoDown = new TwinCATCoil1(new TwinCATCoil("MAIN.NoDown", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            E4 = new TwinCATCoil1(new TwinCATCoil("MAIN.E4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            F4 = new TwinCATCoil1(new TwinCATCoil("MAIN.F4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            G4 = new TwinCATCoil1(new TwinCATCoil("MAIN.G4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            H4 = new TwinCATCoil1(new TwinCATCoil("MAIN.H4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            J4 = new TwinCATCoil1(new TwinCATCoil("MAIN.J4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            K4 = new TwinCATCoil1(new TwinCATCoil("MAIN.K4", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            E5 = new TwinCATCoil1(new TwinCATCoil("MAIN.E5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            F5 = new TwinCATCoil1(new TwinCATCoil("MAIN.F5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            G5 = new TwinCATCoil1(new TwinCATCoil("MAIN.G5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            H5 = new TwinCATCoil1(new TwinCATCoil("MAIN.H5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            J5 = new TwinCATCoil1(new TwinCATCoil("MAIN.J5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            K5 = new TwinCATCoil1(new TwinCATCoil("MAIN.K5", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);


            ShangLiao = new TwinCATCoil1(new TwinCATCoil("MAIN.ShangLiao", typeof(uint), TwinCATCoil.Mode.Notice), _TwinCATAds);
            ShangLiaoFlag = new TwinCATCoil1(new TwinCATCoil("MAIN.ShangLiaoFlag", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);


            RollSet = new TwinCATCoil1(new TwinCATCoil("MAIN.RollSet", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            RollReset = new TwinCATCoil1(new TwinCATCoil("MAIN.RollReset", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            PhotoCMD = new TwinCATCoil1(new TwinCATCoil("MAIN.PhotoCMD", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);
            PhotoComplete = new TwinCATCoil1(new TwinCATCoil("MAIN.PhotoComplete", typeof(bool), TwinCATCoil.Mode.Notice), _TwinCATAds);

            _TwinCATAds.StartNotice();
        }
        #endregion
        #region 功能和方法
        public async void WriteAlarmCSV_Robot(string er)
        {
            RobotPauseCompleteFlag = false;
            string date;
            if (DateTime.Now.Hour < 8)
            {
                date = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            }
            else
            {
                date = DateTime.Now.ToString("yyyy/MM/dd");
            }
            string banbie = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "D" : "N";
            string start = DateTime.Now.ToString("HH:mm:ss");
            int sec = 0;
            while (!RobotPauseCompleteFlag)
            {
                await Task.Delay(1000);
                sec++;
            }
            string stop = DateTime.Now.ToString("HH:mm:ss");
            string span = ((double)sec / 60).ToString("F2");
            string error = GetErrorCode(er);

            if (!File.Exists(System.Environment.CurrentDirectory + "\\fault_list.csv"))
            {
                string[] heads = { "日期", "班别", "Start time", "End time", "故障时间（分）", "异常描述" };
                Csvfile.savetocsv(System.Environment.CurrentDirectory + "\\fault_list.csv", heads);
            }
            string[] count = { date, banbie, start, stop, span, er, error };
            Csvfile.savetocsv(System.Environment.CurrentDirectory + "\\fault_list.csv", count);
        }
        public async void WriteAlarmCSV_Zhiju(int flex)
        {           
            string date;
            if (DateTime.Now.Hour < 8)
            {
                date = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            }
            else
            {
                date = DateTime.Now.ToString("yyyy/MM/dd");
            }
            string banbie = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "D" : "N";
            string start = DateTime.Now.ToString("HH:mm:ss");
            int sec = 0;
            while (true)
            {
                await Task.Delay(1000);
                sec++;
                if (flex == 0)
                {
                    if (TestCheckedAL)
                    {
                        break;
                    }
                }
                if (flex == 1)
                {
                    if (TestCheckedBL)
                    {
                        break;
                    }
                }
            }
            string stop = DateTime.Now.ToString("HH:mm:ss");
            string span = ((double)sec / 60).ToString("F2");
            string error = flex == 0 ? "左治具被屏蔽" : "右治具被屏蔽";

            if (!File.Exists(System.Environment.CurrentDirectory + "\\fault_list.csv"))
            {
                string[] heads = { "日期", "班别", "Start time", "End time", "故障时间（分）", "异常描述" };
                Csvfile.savetocsv(System.Environment.CurrentDirectory + "\\fault_list.csv", heads);
            }
            string[] count = { date, banbie, start, stop, span, flex == 0 ? "032" : "033", error };
            Csvfile.savetocsv(System.Environment.CurrentDirectory + "\\fault_list.csv", count);
        }
        private string GetErrorCode(string str)
        {
            string eer = "";
            switch (str)
            {
                case "000":
                    eer = "测试机1，吸取失败";
                    break;
                case "001":
                    eer = "测试机2，吸取失败";
                    break;
                case "002":
                    eer = "测试机3，吸取失败";
                    break;
                case "003":
                    eer = "测试机4，吸取失败";
                    break;
                case "004":
                    eer = "上料盘1，吸取失败";
                    break;
                case "005":
                    eer = "上料盘2，吸取失败";
                    break;
                case "006":
                    eer = "上料盘3，吸取失败";
                    break;
                case "007":
                    eer = "上料盘4，吸取失败";
                    break;
                case "008":
                    eer = "上料盘5，吸取失败";
                    break;
                case "009":
                    eer = "上料盘6，吸取失败";
                    break;
                case "010":
                    eer = "上料盘7，吸取失败";
                    break;
                case "011":
                    eer = "上料盘8，吸取失败";
                    break;
                case "012":
                    eer = "测试机1，测试超时";
                    break;
                case "013":
                    eer = "测试机2，测试超时";
                    break;
                case "014":
                    eer = "测试机3，测试超时";
                    break;
                case "015":
                    eer = "测试机4，测试超时";
                    break;
                case "016":
                    eer = "测试机1，连续NG";
                    break;
                case "017":
                    eer = "测试机2，连续NG";
                    break;
                case "018":
                    eer = "测试机3，连续NG";
                    break;
                case "019":
                    eer = "测试机4，连续NG";
                    break;
                case "020":
                    eer = "测试机1，上传软体异常";
                    break;
                case "021":
                    eer = "测试机2，上传软体异常";
                    break;
                case "022":
                    eer = "测试机3，上传软体异常";
                    break;
                case "023":
                    eer = "测试机4，上传软体异常";
                    break;
                case "024":
                    eer = "测试机1，良率异常";
                    break;
                case "025":
                    eer = "测试机2，良率异常";
                    break;
                case "026":
                    eer = "测试机3，良率异常";
                    break;
                case "027":
                    eer = "测试机4，良率异常";
                    break;
                case "028":
                    eer = "比对INI记录异常";
                    break;
                case "029":
                    eer = "存在掉料";
                    break;
                case "030":
                    eer = "A爪手掉料";
                    break;
                case "031":
                    eer = "B爪手掉料";
                    break;
                case "034":
                    eer = "上料小车吸取失败";
                    break;
                default:
                    break;
            }
            return eer;
        }
        public void ConfigAlarmView()
        {
            var password = Inifile.INIGetStringValue(iniPassWord, "Admin", "PassWord", "AS56GHK");
            if (AlarmViewPassword == password)
            {
                MenuIsEnabled = true;
                ChoseHomePage();
                //AlarmViewPassword = "";
            }
            AlarmViewPassword = "";
        }
        public void ChoseHomePage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Visible";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            AlarmLockDisplayVisibility = "Collapsed";
            SamCheckinIsEnabled = false;
            isLogin = false;
            Barsamuser_Psw = "";
            LoginButtonString = "登录";
            HaoCaiVisibility = "Collapsed";

        }
        public void ChoseAlarmLockDisplay()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            AlarmLockDisplayVisibility = "Visible";
            HaoCaiVisibility = "Collapsed";

        }
        public void ChoseAboutPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Visible";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
            //MaopaoPaixu();
        }

        public void ChoseHaoCaiPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Visible";
            //MaopaoPaixu();
        }
        public void ChoseHelpPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Visible";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
            //MaopaoPaixu();
        }
        public void ChoseParameterPage()
        {
            ParameterPageVisibility = "Visible";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseOperaterActionPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Visible";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseCameraPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseCameraHcPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Visible";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        //public void ChoseScanCameraPage()
        //{
        //    ParameterPageVisibility = "Collapsed";
        //    AboutPageVisibility = "Collapsed";
        //    HomePageVisibility = "Collapsed";
        //    CameraHcPageVisibility = "Collapsed";
        //    ScanCameraPageVisibility = "Visible";
        //    OperaterActionPageVisibility = "Collapsed";
        //    BarcodeDisplayPageVisibility = "Collapsed";
        //    TestRecordPageVisibility = "Collapsed";
        //}
        public void ChoseScanPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Visible";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseTwincatNcPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Visible";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseBarcodeDisplayPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Visible";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseTestRecordPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Visible";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseAlarmRecordPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Visible";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseSampleTestPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Visible";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseSampleTestPage1()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Visible";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseSampleTestResultPage()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Visible";
            SampleProcessDisplayVisibility = "Collapsed";
            HaoCaiVisibility = "Collapsed";
        }
        public void ChoseSampleProcessDisplay()
        {
            ParameterPageVisibility = "Collapsed";
            AboutPageVisibility = "Collapsed";
            HomePageVisibility = "Collapsed";
            CameraHcPageVisibility = "Collapsed";
            ScanPageVisibility = "Collapsed";
            OperaterActionPageVisibility = "Collapsed";
            BarcodeDisplayPageVisibility = "Collapsed";
            TestRecordPageVisibility = "Collapsed";
            TwincatNcPageVisibility = "Collapsed";
            SampleTestPageVisibility = "Collapsed";
            AlarmRecordPageVisibility = "Collapsed";
            SampleTestPage1Visibility = "Collapsed";
            HelpPageVisibility = "Collapsed";
            SampleTestResultPageVisibility = "Collapsed";
            SampleProcessDisplayVisibility = "Visible";
            HaoCaiVisibility = "Collapsed";
        }
        public async void ShieldDoorFunction()
        {

            if (!IsShieldTheDoor)
            {
                mydialog.changeaccent("red");
                var r = await mydialog.showconfirm("确定屏蔽安全门吗？请小心操作！");
                if (r)
                {
                    IsShieldTheDoor = !IsShieldTheDoor;
                }
                mydialog.changeaccent("blue");
            }
            else
            {
                IsShieldTheDoor = !IsShieldTheDoor;
            }
        }
        public async void OperateCiTieFunction()
        {

            if (IsOperateCiTie)
            {
                mydialog.changeaccent("red");
                var r = await mydialog.showconfirm("确定释放电磁铁吗？");
                if (r)
                {
                    IsOperateCiTie = !IsOperateCiTie;
                    Msg = messagePrint.AddMessage("电磁铁释放");
                }
                mydialog.changeaccent("blue");
            }
            else
            {
                IsOperateCiTie = !IsOperateCiTie;
            }
        }
        private string MaopaoPaixu()
        {
            string str = "";
            double[] Array_A = new double[4];
            ushort[] Array_B = new ushort[4];

            for (ushort k = 0; k < 4; k++)
            {
                Array_A[k] = epsonRC90.sIMTester[k / 2].Yield[k % 2 * 2] + epsonRC90.sIMTester[k / 2].Yield[k % 2 * 2 + 1];
                Array_B[k] = k;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3 - i; j++)
                {
                    if (Array_A[j] < Array_A[j + 1])
                    {
                        var temp1 = Array_A[j];
                        var temp2 = Array_B[j];
                        Array_A[j] = Array_A[j + 1];
                        Array_B[j] = Array_B[j + 1];
                        Array_A[j + 1] = temp1;
                        Array_B[j + 1] = temp2;
                    }
                }
            }
            int i_index = 0;
            for (int m = 0; m < 4; m++)
            {
                if (Array_B[m] == 0)
                {
                    i_index = m;
                    break;
                }
            }
            if (i_index == 3)
            {
                var temp5 = Array_B[i_index];
                Array_B[i_index] = Array_B[2];
                Array_B[2] = temp5;
            }
            for (int l = 0; l < 4; l++)
            {
                str += Array_B[l].ToString() + ";";
            }
            return str;
        }
        public async void EpsonOpetate(object p)
        {
            string s = p.ToString();
            switch (s)
            {
                //启动
                case "1":
                    AlarmTextGridShow = "Collapsed";
                    if (epsonRC90.CtrlStatus && EpsonStatusReady && !EpsonStatusEStop)
                    {
                        Testerwith4item.IsInSampleMode = false;

                            string maopaostr = MaopaoPaixu();

                            await epsonRC90.CtrlNet.SendAsync("$start,0");
                            Msg = messagePrint.AddMessage("正常模式");
                            OperateModeStr = "正常";
                            AllowCleanActionCommand = true;
                            AllowSampleTestCommand = true;
                            await Task.Delay(200);
                            if (epsonRC90.TestSendStatus)
                            {
                                await epsonRC90.TestSentNet.SendAsync("IndexArray_i;" + maopaostr);
                            }
                            if (!IsTestersSample && epsonRC90.TestSendStatus)
                            {
                                await Task.Delay(200);
                                await epsonRC90.TestSentNet.SendAsync("GONOGOCancel");
                            }
               
                    }
                    break;
                //暂停
                case "2":
                    if (epsonRC90.CtrlStatus)
                    {
                        await epsonRC90.CtrlNet.SendAsync("$pause");
                    }
                    break;
                //继续
                case "3":
                    AlarmTextGridShow = "Collapsed";
                    if (epsonRC90.CtrlStatus)
                    {
                        await epsonRC90.CtrlNet.SendAsync("$continue");
                        if (SampleRetestButtonVisibility == "Visible")
                        {
                            SampleRetestButtonVisibility = "Collapsed";
                        }
                    }
                    if (PLCPause)
                    {
                        PLCNeedContinue = true;
                    }
                    RobotPauseCompleteFlag = true;
                    break;
                //重启
                case "4":
                    AlarmTextGridShow = "Collapsed";
                    mydialog.changeaccent("red");
                    var r = await mydialog.showconfirm("确定进行停止机械手重启操作吗？");
                    if (r && epsonRC90.CtrlStatus)
                    {
                        await epsonRC90.CtrlNet.SendAsync("$stop");
                        await Task.Delay(300);
                        await epsonRC90.CtrlNet.SendAsync("$SetMotorOff,1");
                        await Task.Delay(400);
                        await epsonRC90.CtrlNet.SendAsync("$reset");
                    }
                    RobotPauseCompleteFlag = true;
                    mydialog.changeaccent("blue");
                    break;
                //排料
                case "5":
                    mydialog.changeaccent("red");
                    r = await mydialog.showconfirm("确定进行排料操作吗？");
                    if (r && epsonRC90.TestSendStatus && (EpsonStatusRunning || EpsonStatusPaused) && !isGRRMode)
                    {
                        await epsonRC90.TestSentNet.SendAsync("Discharge");
                    }
                    mydialog.changeaccent("blue");
                    break;
                //暂停
                case "6":
                    if (epsonRC90.CtrlStatus)
                    {
                        await epsonRC90.CtrlNet.SendAsync("$reset");
                    }
                    break;
                default:
                    break;
            }
        }
        public async void SampleWindowOperate(object p)
        {
            string s = p.ToString();
            switch (s)
            {
                case "1":
                    mydialog.changeaccent("red");
                    bool r = await mydialog.showconfirm("确定要进行测样本吗？");
                    if (r)
                    {
                        ShowSampleTestWindow = !ShowSampleTestWindow;
                    }
                    mydialog.changeaccent("blue");

                    break;
                case "2":
                    QuitSampleTest = !QuitSampleTest;
                    break;
            }
        }
        public void AdminWindowOperate(object p)
        {
            string s = p.ToString();
            switch (s)
            {
                case "1":

                    ShowYieldAdminControlWindow = !ShowYieldAdminControlWindow;
                    AdminPasswordPageVisibility = "Visible";
                    AdminOperatePageVisibility = "Collapsed";

                    break;
                //case "2":

                //    break;
                case "3":
                    if (AdminPasswordstr == LoginPassword)
                    {
                        AdminPasswordPageVisibility = "Collapsed";
                        AdminOperatePageVisibility = "Visible";
                        //Yield0_Nomal
                        //PassLowLimitStop
                        //PassLowLimitStopNum
                        YieldAddNum4 = YieldAddNum3 = YieldAddNum2 = YieldAddNum1 = 0;
                        YieldAddNum1Enable = Yield0 < PassLowLimitStop && TestCount0 >= PassLowLimitStopNum + epsonRC90.AdminAddNum[0];
                        if (YieldAddNum1Enable)
                        {
                            //YieldAddNum1 = (TestCount0_Nomal / 10);
                            YieldAddNum1 = 200;
                        }
                        YieldAddNum2Enable = Yield1 < PassLowLimitStop && TestCount1 >= PassLowLimitStopNum + epsonRC90.AdminAddNum[1];
                        if (YieldAddNum2Enable)
                        {
                            //YieldAddNum2 = (TestCount1_Nomal / 10);
                            YieldAddNum2 = 200;
                        }
                        YieldAddNum3Enable = Yield2 < PassLowLimitStop && TestCount2 >= PassLowLimitStopNum + epsonRC90.AdminAddNum[2];
                        if (YieldAddNum3Enable)
                        {
                            //YieldAddNum3 = (TestCount2_Nomal / 10);
                            YieldAddNum3 = 200;
                        }
                        YieldAddNum4Enable = Yield3 < PassLowLimitStop && TestCount3 >= PassLowLimitStopNum + epsonRC90.AdminAddNum[3];
                        if (YieldAddNum4Enable)
                        {
                            //YieldAddNum4 = (TestCount3_Nomal / 10);
                            YieldAddNum4 = 200;
                        }
                    }
                    AdminPasswordstr = "";

                    break;
                case "4":
                    if (YieldAddNum1Enable)
                    {
                        //epsonRC90.AdminAddNum[0] = TestCount0_Nomal - PassLowLimitStopNum + (YieldAddNum1 > (TestCount0_Nomal / 10) ? (TestCount0_Nomal / 10) : YieldAddNum1);
                        epsonRC90.AdminAddNum[0] = TestCount0 - PassLowLimitStopNum + YieldAddNum1;
                    }
                    if (YieldAddNum2Enable)
                    {
                        //epsonRC90.AdminAddNum[1] = TestCount1_Nomal - PassLowLimitStopNum + (YieldAddNum2 > (TestCount1_Nomal / 10) ? (TestCount1_Nomal / 10) : YieldAddNum2);
                        epsonRC90.AdminAddNum[1] = TestCount1 - PassLowLimitStopNum + YieldAddNum2;
                    }
                    if (YieldAddNum3Enable)
                    {
                        //epsonRC90.AdminAddNum[2] = TestCount2_Nomal - PassLowLimitStopNum + (YieldAddNum3 > (TestCount2_Nomal / 10) ? (TestCount2_Nomal / 10) : YieldAddNum3);
                        epsonRC90.AdminAddNum[2] = TestCount2 - PassLowLimitStopNum + YieldAddNum3;
                    }
                    if (YieldAddNum4Enable)
                    {
                        //epsonRC90.AdminAddNum[3] = TestCount3_Nomal - PassLowLimitStopNum + (YieldAddNum4 > (TestCount3_Nomal / 10) ? (TestCount3_Nomal / 10) : YieldAddNum4);
                        epsonRC90.AdminAddNum[3] = TestCount3 - PassLowLimitStopNum + YieldAddNum4;
                    }
                    QuitYieldAdminControl = !QuitYieldAdminControl;
                    AdminButtonVisibility = "Collapsed";
                    break;
            }
        }
        public void NoiseReduce()
        {
            NeedNoiseReduce = true;
        }
        public void LoadMaters()
        {
            NeedLoadMaters = true;
        }
        public void UnLoadMaters()
        {
            NeedUnloadMaters = true;
        }
        public void SaveParameter()
        {

            var r1 = WriteParameter();
            if (r1)
            {
                Msg = messagePrint.AddMessage("写入参数成功");
            }
            else
            {
                Msg = messagePrint.AddMessage("写入参数成功");
            }
        }
        public void Selectfile(object p)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            switch (p.ToString())
            {
                case "0":
                    dlg.Filter = "视觉文件(*.vbai)|*.vbai|所有文件(*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        VisionScriptFileName = dlg.FileName;
                        Inifile.INIWriteValue(iniParameterPath, "Camera", "VisionScriptFileName", VisionScriptFileName);
                    }
                    break;
                case "1":
                    dlg.Filter = "视觉文件(*.hdev)|*.hdev|所有文件(*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        HcVisionScriptFileName = dlg.FileName;
                        Inifile.INIWriteValue(iniParameterPath, "Camera", "HcVisionScriptFileName", HcVisionScriptFileName);
                    }
                    break;
                case "2":
                    dlg.Filter = "视觉文件(*.hdev)|*.hdev|所有文件(*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ScanVisionScriptFileName = dlg.FileName;
                        Inifile.INIWriteValue(iniParameterPath, "Camera", "ScanVisionScriptFileName", ScanVisionScriptFileName);
                    }
                    break;
                case "3":
                    dlg.Filter = "视觉文件(*.hdev)|*.hdev|所有文件(*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ScanVisionScriptFileNameP3 = dlg.FileName;
                        Inifile.INIWriteValue(iniParameterPath, "Camera", "ScanVisionScriptFileNameP3", ScanVisionScriptFileNameP3);
                    }
                    break;
                default:
                    break;
            }
            //dlg.InitialDirectory = System.Environment.CurrentDirectory;

            dlg.Dispose();
        }

        public async void UpdateSelectFlexer()
        {
            string str = "Select;";
            int num = 0;
            if (TestCheckedAL)
            {
                str += "1;";
                num++;
            }
            else
            {
                str += "0;";

            }

            if (TestCheckedAR)
            {
                str += "1;";
                num++;
            }
            else
            {
                str += "0;";
            }

            if (TestCheckedBL)
            {
                str += "1;";
                num++;
            }
            else
            {
                str += "0;";
            }

            if (TestCheckedBR)
            {
                str += "1;";
                num++;
            }
            else
            {
                str += "0;";
            }
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync(str + "123");
                Msg = messagePrint.AddMessage(str);
            }


            Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedAL", TestCheckedAL.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedAR", TestCheckedAR.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedBL", TestCheckedBL.ToString());
            Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedBR", TestCheckedBR.ToString());

            str = "NGContinueNum;" + NGContinueNum.ToString();
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync(str);
                Msg = messagePrint.AddMessage(str);
            }

            Inifile.INIWriteValue(iniParameterPath, "Tester", "NGContinueNum", NGContinueNum.ToString());

            str = "NGOverlayNum;" + NGOverlayNum.ToString();
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync(str);
                Msg = messagePrint.AddMessage(str);
            }

            Inifile.INIWriteValue(iniParameterPath, "NGOverlay", "NGOverlayNum", NGOverlayNum.ToString());

            //str = "BarcodeMode;" + BarcodeMode.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "BarcodeMode", "BarcodeMode", BarcodeMode.ToString());
            //str = "CheckUpload;" + IsCheckUploadStatus.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "Upload", "IsCheckUploadStatus", IsCheckUploadStatus.ToString());

            //str = "IsPassLowLimitStop;" + IsPassLowLimitStop.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "PassYield", "IsPassLowLimitStop", IsPassLowLimitStop.ToString());

            //str = "IsCheckINI;" + IsCheckINI.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "CheckINI", "IsCheckINI", IsCheckINI.ToString());

            //str = "IsReleaseFailContinue;" + IsReleaseFailContinue.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "ReleaseFail", "IsReleaseFailContinue", IsReleaseFailContinue.ToString());

            //str = "isScanCheckFlag;" + isScanCheckFlag.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "CheckScan", "isScanCheckFlag", isScanCheckFlag.ToString());

            ////if (num < 2)
            ////{
            ////    AABReTest = false;
            ////}
            //str = "AABReTest;" + AABReTest.ToString();
            //if (epsonRC90.TestSendStatus)
            //{
            //    await epsonRC90.TestSentNet.SendAsync(str);
            //    Msg = messagePrint.AddMessage(str);
            //}
            //Inifile.INIWriteValue(iniParameterPath, "ReTest", "AABReTest", AABReTest.ToString());
        }
        public async void ClearFlexer()
        {
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync("Clear;123");
                Msg = messagePrint.AddMessage("Clear;");
            }

        }
        private void AutoClean()
        {
            _AutoClean = true;
            waitforinput = 0;
            Inifile.INIWriteValue(iniAlarmRecordPath, "Summary", "waitforinput", waitforinput.ToString());
            inputtimes = 0;
            Inifile.INIWriteValue(iniAlarmRecordPath, "Summary", "inputtimes", inputtimes.ToString());
            downtime = 0;
            Inifile.INIWriteValue(iniAlarmRecordPath, "Summary", "downtime", downtime.ToString());
            for (int i = 0; i < 8; i++)
            {
                CleantoZero(i);
            }
            TotalAlarmNum = 0;
            ClearAlarmRecord();
            AlarmLastDayofYear = DateTime.Now.DayOfYear;
            Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastDayofYear", AlarmLastDayofYear.ToString());
            _AutoClean = false;

        }
        public void CleantoZero(object p)
        {
            string s = p.ToString();
            int i = int.Parse(s);
            try
            {

                epsonRC90.sIMTester[i / 4].TestSpan[i % 4] = 0;
                epsonRC90.sIMTester[i / 4].PassCount[i % 4] = 0;
                epsonRC90.sIMTester[i / 4].FailCount[i % 4] = 0;
                epsonRC90.sIMTester[i / 4].TestCount[i % 4] = 0;
                epsonRC90.sIMTester[i / 4].Yield[i % 4] = 0;
                Inifile.INIWriteValue(iniTesterResutPath, "Tester" + i.ToString(), "TestSpan", "0");
                Inifile.INIWriteValue(iniTesterResutPath, "Tester" + i.ToString(), "PassCount", "0");
                Inifile.INIWriteValue(iniTesterResutPath, "Tester" + i.ToString(), "FailCount", "0");
                Inifile.INIWriteValue(iniTesterResutPath, "Tester" + i.ToString(), "TestCount", "0");
                Inifile.INIWriteValue(iniTesterResutPath, "Tester" + i.ToString(), "Yield", "0");
                Msg = messagePrint.AddMessage("测试机 " + (i + 1).ToString() + "数据清空");

                if (!_AutoClean)
                {
                    TotalAlarmNum = 0;
                    ClearAlarmRecord();
                    DeleteAlarmFile();
                    liaoinput = 0;
                    liaooutput = 0;
                }


            }
            catch
            {

            }
        }
        private void DeleteAlarmFile()
        {
            string Bancistr = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "白班" : "夜班";
            string filepath = AlarmSavePath + "\\Alarm" + AlarmLastDateNameStr + Bancistr + ".csv";
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                else
                {
                    Msg = messagePrint.AddMessage("报警文件不存在");
                }

            }
            catch (Exception ex)
            {
                Msg = messagePrint.AddMessage("删除报警文件失败");
                Log.Default.Error("删除报警文件失败", ex.Message);
            }
        }
        public void SelectSavePath(object p)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "请选择文件路径";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (p.ToString())
                {
                    case "0":
                        TestRecordSavePath = dlg.SelectedPath;
                        Inifile.INIWriteValue(iniParameterPath, "SavePath", "TestRecordSavePath", TestRecordSavePath);

                        break;
                    case "1":
                        AlarmSavePath = dlg.SelectedPath;
                        Inifile.INIWriteValue(iniParameterPath, "SavePath", "AlarmSavePath", AlarmSavePath);
                        break;
                    default:
                        break;
                }
            }
        }
        private void SaveCSVfileRecord(TestRecord tr)
        {
            string filepath = TestRecordSavePath + "\\" + GetBanci() + ".csv";
            if (!Directory.Exists(TestRecordSavePath))
            {
                Directory.CreateDirectory(TestRecordSavePath);
            }
            try
            {

                if (!File.Exists(filepath))
                {
                    string[] heads = { "Time", "Barcode", "Result", "Cycle", "Index" };
                    Csvfile.savetocsv(filepath, heads);
                }
                string[] conte = { tr.TestTime, tr.Barcode, tr.TestResult, tr.TestCycleTime, tr.Index };
                Csvfile.savetocsv(filepath, conte);
            }
            catch (Exception ex)
            {
                Msg = messagePrint.AddMessage("写入CSV文件失败");
                Log.Default.Error("写入CSV文件失败", ex.Message);
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
        private void SaveCSVfileAlarm(string str)
        {
            if (DateTime.Now.Hour < 8)
            {
                if (AlarmLastDateNameStr != DateTime.Now.AddDays(-1).ToLongDateString())
                {
                    AlarmLastDateNameStr = DateTime.Now.AddDays(-1).ToLongDateString();
                    Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastDateNameStr", AlarmLastDateNameStr);
                }
            }
            else
            {
                if (AlarmLastDateNameStr != DateTime.Now.ToLongDateString())
                {
                    AlarmLastDateNameStr = DateTime.Now.ToLongDateString();
                    Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastDateNameStr", AlarmLastDateNameStr);
                }
            }
            string Bancistr = DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20 ? "白班" : "夜班";
            string filepath = AlarmSavePath + "\\Alarm" + AlarmLastDateNameStr + Bancistr + ".csv";
            if (!Directory.Exists(AlarmSavePath))
            {
                Directory.CreateDirectory(AlarmSavePath);
            }
            try
            {
                if (!File.Exists(filepath))
                {
                    string[] heads = { "DateTime", "Contant" };
                    Csvfile.savetocsv(filepath, heads);
                }
                string[] conte = { System.DateTime.Now.ToString(), str };
                Csvfile.savetocsv(filepath, conte);
            }
            catch (Exception ex)
            {
                Msg = messagePrint.AddMessage("写入CSV文件失败");
                Log.Default.Error("写入CSV文件失败", ex.Message);
            }
        }
       
        private void SaveScanBarcodetoCSV(string bar)
        {
            if (!Directory.Exists(TestRecordSavePath + @"\Barcode\" + GetBanci()))
            {
                Directory.CreateDirectory(TestRecordSavePath + @"\Barcode\" + GetBanci());
            }
            if (Directory.Exists(TestRecordSavePath + @"\Barcode\" + GetBanci()))
            {
                string filepath = TestRecordSavePath + @"\Barcode\" + GetBanci() + @"\Scan" + GetBanciShort().Replace("/", "") + ".csv";
                try
                {
                    if (!File.Exists(filepath))
                    {
                        string[] heads = { "DateTime", "ScanBarcode" };
                        Csvfile.savetocsv(filepath, heads);
                    }
                    string[] conte = { System.DateTime.Now.ToString(), bar };
                    Csvfile.savetocsv(filepath, conte);
                }
                catch (Exception ex)
                {
                    Msg = messagePrint.AddMessage("写入CSV文件失败");
                    Log.Default.Error("写入CSV文件失败", ex.Message);
                }
            }

        }
        //private void addAlarm(string almstr)
        //{
        //    AlarmRecord alarmRecord = new AlarmRecord();
        //    alarmRecord.AlarmTime = System.DateTime.Now.ToString();
        //    alarmRecord.AlarmString = almstr;
        //    lock (this)
        //    {
        //        myAlarmRecordQueue.Enqueue(alarmRecord);
        //    }



        //}
        private void ShowAlarmTextGrid(string str)
        {
            AlarmTextString = str;
            //string ss = str.Replace("\n", "");
            //Inifile.INIWriteValue(iniFClient, "Alarm", "Name", ss);
            AlarmTextGridShow = "Visible";
        }
        public async void LoginAction()
        {
            List<string> r;
            if (isLogin == false)
            {

                r = await mydialog.showlogin();
                if (r[0] == LoginUserName && r[1] == LoginPassword)
                {
                    isLogin = !isLogin;
                }

            }
            else
            {
                isLogin = !isLogin;
            }


            if (isLogin == true)
            {
                LoginButtonString = "登出";
            }
            else
            {
                LoginButtonString = "登录";
            }
        }
        public async void XQTActionFunction(object p)
        {
            string s = p.ToString();
            switch (s)
            {
                case "1":
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("XQTAction;1");
                    }
                    break;
                case "2":
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("XQTAction;2");
                    }
                    break;
                case "3":
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("XQTAction;3");
                    }
                    break;
                case "4":
                    if (epsonRC90.TestSendStatus && IsTestersClean && AllowCleanActionCommand)
                    {
                        await epsonRC90.TestSentNet.SendAsync("TestersCleanAction");
                        AllowCleanActionCommand = false;
                    }
                    break;
                case "5":
                    if (epsonRC90.TestSendStatus && IsTestersSample && AllowSampleTestCommand)
                    {
                        await epsonRC90.TestSentNet.SendAsync("GONOGOAction;" + SampleNgitemsNum.ToString());
                        AllowSampleTestCommand = false;
                        SampleWindowCloseEnable = false;
                        SampleWaitTimeShow = "Collapsed";
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                SampleDisplayArray[i, j] = "";
                            }
                        }
                    }
                    break;
                case "6":
                    if (epsonRC90.TestSendStatus && IsTestersSample)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SamRetest");
                        SampleRetestButtonVisibility = "Collapsed";
                    }
                    AlarmTextGridShow = "Collapsed";
                    if (epsonRC90.CtrlStatus)
                    {
                        SampleWaitTimeShow = "Collapsed";
                        await epsonRC90.CtrlNet.SendAsync("$continue");

                        SampleRetestButtonVisibility = "Collapsed";

                    }
                    break;
                case "7":
                    //alarmRecord.Clear();
                    ClearAlarmRecord();
                    break;
                default:
                    break;
            }
        }
        private void ClearAlarmRecord()
        {
            foreach (var item in alarmTableItemsList)
            {
                item.ReleaseFail = 0;
                item.SuckFail = 0;
                //item.测试机超时 = 0;
                //item.连续NG = 0;
            }
            WriteAlarmRecord();


            Msg = messagePrint.AddMessage("清空报警数据");

        }
        private void SaveLastSamplTimetoIni()
        {
            try
            {
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wDay", lastchuiqi.wDay.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wDayOfWeek", lastchuiqi.wDayOfWeek.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wHour", lastchuiqi.wHour.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wMilliseconds", lastchuiqi.wMilliseconds.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wMinute", lastchuiqi.wMinute.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wMonth", lastchuiqi.wMonth.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wSecond", lastchuiqi.wSecond.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "wYear", lastchuiqi.wYear.ToString());

                //lastSample

                Inifile.INIWriteValue(iniParameterPath, "Sample", "wDay", lastSample.wDay.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wDayOfWeek", lastSample.wDayOfWeek.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wHour", lastSample.wHour.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wMilliseconds", lastSample.wMilliseconds.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wMinute", lastSample.wMinute.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wMonth", lastSample.wMonth.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wSecond", lastSample.wSecond.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "wYear", lastSample.wYear.ToString());

            }
            catch (Exception ex)
            {

                Log.Default.Error("SaveLastSamplTimetoIni", ex);
            }
        }
        public void ReadTwinCatDatafromIni()
        {
            try
            {
                ReleasePositionX1.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionX1", "224.3008"));
                ReleasePositionY1.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionY1", "320.7936"));
                ReleasePositionX2.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionX2", "224.2896"));
                ReleasePositionY2.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionY2", "0.2528"));
                ReleasePositionX3.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionX3", "25.6064"));
                ReleasePositionY3.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "ReleasePositionY3", "319.9712"));
                PickPositionX.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "PickPositionX", "368.448"));
                PickPositionY.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "PickPositionY", "509.976"));
                WaitPositionX.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "WaitPositionX", "28.9152"));
                WaitPositionY.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "XY", "WaitPositionY", "509.4416"));
                FPosition1.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition1", "466.234"));
                FPosition2.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition2", "565.634"));
                FPosition3.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition3", "293.882"));
                FPosition4.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition4", "12.91"));
                FPosition5.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition5", "12.91"));
                FPosition6.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition6", "260.402"));
                FPosition7.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition7", "170.004"));
                FPosition8.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "F", "FPosition8", "170.004"));
                TPosition1.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "T", "TPosition1", "-28.4904"));
                TPosition2.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "T", "TPosition2", "-303.9456"));
                TPosition3.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "T", "TPosition3", "-565.848"));
                TPosition4.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "T", "TPosition4", "-565.848"));
                TPosition5.Value = double.Parse(Inifile.INIGetStringValue(TwincatParameterPath, "T", "TPosition5", "-1136.144"));

                


                Calc_Start.Value = true;
                SaveButton.Value = true;
                Msg = messagePrint.AddMessage("载入轴控参数完成");
            }
            catch (Exception ex)
            {

                Msg = messagePrint.AddMessage("载入轴控参数失败");
            }
        }
        public void SaveTwincatDataAction()
        {
            try
            {
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionX1", ReleasePositionX1.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionY1", ReleasePositionY1.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionX2", ReleasePositionX2.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionY2", ReleasePositionY2.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionX3", ReleasePositionX3.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "ReleasePositionY3", ReleasePositionY3.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "PickPositionX", PickPositionX.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "PickPositionY", PickPositionY.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "WaitPositionX", WaitPositionX.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "XY", "WaitPositionY", WaitPositionY.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition1", FPosition1.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition2", FPosition2.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition3", FPosition3.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition4", FPosition4.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition5", FPosition5.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition6", FPosition6.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition7", FPosition7.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "F", "FPosition8", FPosition8.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "T", "TPosition1", TPosition1.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "T", "TPosition2", TPosition2.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "T", "TPosition3", TPosition3.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "T", "TPosition4", TPosition4.Value.ToString());
                Inifile.INIWriteValue(TwincatParameterPath, "T", "TPosition5", TPosition5.Value.ToString());

                

                //TPosition1
                //FPosition1
                //PickPositionX
                //WaitPositionX
                SaveButton.Value = true;
                Msg = messagePrint.AddMessage("保存轴控参数完成");
            }
            catch
            {

                Msg = messagePrint.AddMessage("保存轴控参数失败");
            }
        }
        public void ScanAction()
        {
            Scan.GetBarCode(ScanActionCallback);
        }
        public void ScanActionCallback(string str)
        {
            BarcodeDisplay = str;
        }
        /// <summary>
        /// 样本录入用户登录
        /// </summary>
        public async void SamCheckinLoadAction()
        {
            if (samCheckinLoadAction(Barsamuser_Uname))
            {
                SamCheckinIsEnabled = true;
                await mydialog.showmessage("录入用户登录 成功");
            }
            else
            {
                SamCheckinIsEnabled = false;
                await mydialog.showmessage("录入用户登录 失败");

            }
        }
        public async void SamCheckinAction()
        {
            if (samCheckinAction())
            {
                await mydialog.showmessage("样本数据录入 成功");
            }
            else
            {
                await mydialog.showmessage("样本数据录入 失败");
            }
        }
        public async void SampleHaveUpdateAction(object p)
        {
            switch (p.ToString())
            {
                case "1":
                    SampleHave1 = !SampleHave1;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;1;" + SampleHave1.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave1", SampleHave1.ToString());
                    break;
                case "2":
                    SampleHave2 = !SampleHave2;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;2;" + SampleHave2.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave2", SampleHave2.ToString());
                    break;
                case "3":
                    SampleHave3 = !SampleHave3;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;3;" + SampleHave3.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave3", SampleHave3.ToString());
                    break;
                case "4":
                    SampleHave4 = !SampleHave4;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;4;" + SampleHave4.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave4", SampleHave4.ToString());
                    break;
                case "5":
                    SampleHave5 = !SampleHave5;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;5;" + SampleHave5.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave5", SampleHave5.ToString());
                    break;
                case "6":
                    SampleHave6 = !SampleHave6;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;6;" + SampleHave6.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave6", SampleHave6.ToString());
                    break;
                case "7":
                    SampleHave7 = !SampleHave7;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;7;" + SampleHave7.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave7", SampleHave7.ToString());
                    break;
                case "8":
                    SampleHave8 = !SampleHave8;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;8;" + SampleHave8.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave8", SampleHave8.ToString());
                    break;
                case "9":
                    SampleHave9 = !SampleHave9;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;9;" + SampleHave9.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave9", SampleHave9.ToString());
                    break;
                case "10":
                    SampleHave10 = !SampleHave10;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;10;" + SampleHave10.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave10", SampleHave10.ToString());
                    break;
                case "11":
                    SampleHave11 = !SampleHave11;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;11;" + SampleHave11.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave11", SampleHave11.ToString());
                    break;
                case "12":
                    SampleHave12 = !SampleHave12;
                    if (epsonRC90.TestSendStatus)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SampleHave;12;" + SampleHave12.ToString());
                    }
                    Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave12", SampleHave12.ToString());
                    break;
                default:
                    break;
            }
        }
        private void SaveLimitSwStatusAction(string str)
        {
            //if (!Directory.Exists(LimitSwStatusRecord))
            //{
            //    Directory.CreateDirectory(LimitSwStatusRecord);
            //}
            if (str != "")
            {
                string[] conte = { DateTime.Now.ToString(), str };
                Csvfile.savetocsv(LimitSwStatusRecord, conte);
            }
        }
        private void SaveSampleRecordLocal(string str)
        {
            string filepath = "";
            //TestRecordSavePath
            if (!Directory.Exists(TestRecordSavePath + @"\" + GetBanci()))
            {
                Directory.CreateDirectory(TestRecordSavePath + @"\" + GetBanci());
            }

            if (str != "")
            {
                filepath = TestRecordSavePath + @"\" + GetBanci() + @"\" + (DateTime.Now.ToShortDateString()).Replace("/", "") + (DateTime.Now.ToShortTimeString()).Replace(":", "") + str + ".csv";
            }
            else
            {
                filepath = TestRecordSavePath + @"\" + GetBanci() + @"\" + (DateTime.Now.ToShortDateString()).Replace("/", "") + (DateTime.Now.ToShortTimeString()).Replace(":", "") + ".csv";
            }
            if (SampleDt.Rows.Count > 0)
            {
                Csvfile.dt2csv(SampleDt, filepath, "SampleTest", "PARTNUM,SITEM,BARCODE,NGITEM,TRES,MNO,CDATE,CTIME,SR01,FL02,FL03");
                if (str != "")
                {
                    System.Windows.MessageBox.Show("样本记录已保存");
                }
                else
                {
                    SampleDt.Rows.Clear();
                }

            }
        }
        private string[] PassStatusProcess(double f)
        {
            string[] strs = new string[2];
            if (f > PassMid)
            {
                strs[0] = "良率" + f.ToString() + "% 优秀";
                strs[1] = "Blue";
            }
            else
            {
                if (f > PassLowLimit)
                {
                    strs[0] = "良率" + f.ToString() + "% 正常";
                    strs[1] = "Green";
                }
                else
                {
                    if (f == 0)
                    {
                        strs[0] = "良率" + f.ToString() + "% 未知";
                        strs[1] = "Black";
                    }
                    else
                    {
                        strs[0] = "良率" + f.ToString() + "% 异常";
                        strs[1] = "Red";
                    }

                }
            }
            return strs;
        }
        private async void SampleCount_down()
        {
            Stopwatch sw = new Stopwatch();
            SampleWaitTime = 30;
            Func<Task> startTask = () =>
            {
                return Task.Run(() =>
                {
                    sw.Start();
                    while (sw.Elapsed.TotalSeconds <= 30 && !EStop)
                    {
                        System.Threading.Thread.Sleep(100);
                        SampleWaitTime = Math.Round(30 - sw.Elapsed.TotalSeconds, 1);
                    }
                });
            };
            await Task.Run(startTask);
            //await Task.Delay(10);
        }
        #region 数据库
        private void setLocalTime(string strDateTime)
        {
            DateTimeUtility.SYSTEMTIME st = new DateTimeUtility.SYSTEMTIME();
            DateTime dt = Convert.ToDateTime(strDateTime);
            st.FromDateTime(dt);
            DateTimeUtility.SetLocalTime(ref st);
        }
        private void ConnectDBTest()
        {
            try
            {
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    string dbtime = oraDB.sfc_getServerDateTime();
                    setLocalTime(dbtime);
                    //Msg = messagePrint.AddMessage("获取数据库时间： " + dbtime);

                    IsDBConnect = true;
                }
                else
                {
                    Msg = messagePrint.AddMessage("数据库未连接");

                    IsDBConnect = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                Msg = messagePrint.AddMessage("获取数据库时间失败");
                IsDBConnect = false;
            }
        }
        public void SQLGetBarcode(object p)
        {
            switch (p.ToString())
            {
                case "1":
                    Barsaminfo_Barcode = BarcodeDisplay;
                    break;
                case "2":
                    DBSearch_Barcode = BarcodeDisplay;
                    break;
                default:
                    break;
            }
        }
        public void SearchAction()
        {
            try
            {
                if (DBSearch_Barcode.Length > 10)
                {
                    LookforDt(DBSearch_Barcode.Replace(" ", ""), BarsamTableIndex);
                }
            }
            catch
            {


            }

        }
        private void SelectSampleResultfromDt()
        {
            string[] arrField = new string[2];
            string[] arrValue = new string[2];
            try
            {
                string tablename = "FLUKE_DATA";
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    foreach (DataRow item in SampleDt.Rows)
                    {
                        arrField[0] = "BARCODE";
                        arrValue[0] = (string)item["BARCODE"];
                        arrField[1] = "FL04";
                        arrValue[1] = (string)item["SR01"];
                        DataSet s = oraDB.selectSQLwithOrder(tablename.ToUpper(), arrField, arrValue);
                        SinglDt = s.Tables[0];
                        if (SinglDt.Rows.Count == 0)
                        {
                            Msg = messagePrint.AddMessage("未查询到 " + (string)item["BARCODE"] + "," + (string)item["SR01"] + " 信息");
                            item["TRES"] = "NoRecord";
                        }
                        else
                        {
                            item["TRES"] = (string)SinglDt.Rows[0]["FL01"];
                            item["FL02"] = (string)SinglDt.Rows[0]["FL02"];
                            item["FL03"] = (string)SinglDt.Rows[0]["FL03"];
                            string mydate = (string)SinglDt.Rows[0]["FL02"];
                            string mytime = (string)SinglDt.Rows[0]["FL03"];
                            try
                            {
                                DateTime mydatetime = DateTime.ParseExact(mydate + mytime, "yyyyMMddHHmmss",
           System.Globalization.CultureInfo.InvariantCulture);
                                if (DateTime.Now.DayOfYear == mydatetime.DayOfYear)
                                {
                                    if ((DateTime.Now.Hour - mydatetime.Hour) * 60 + DateTime.Now.Minute - mydatetime.Minute < 30 && (DateTime.Now.Hour - mydatetime.Hour) * 60 + DateTime.Now.Minute - mydatetime.Minute >= 0)
                                    {
                                        item["TRES"] = (string)SinglDt.Rows[0]["FL01"];
                                    }
                                    else
                                    {
                                        item["TRES"] = "NotNew";
                                    }
                                }
                                else
                                {
                                    if (DateTime.Now.DayOfYear == mydatetime.DayOfYear + 1)
                                    {
                                        if ((24 + DateTime.Now.Hour - mydatetime.Hour) * 60 + DateTime.Now.Minute - mydatetime.Minute < 30 && (24 + DateTime.Now.Hour - mydatetime.Hour) * 60 + DateTime.Now.Minute - mydatetime.Minute >= 0)
                                        {
                                            item["TRES"] = (string)SinglDt.Rows[0]["FL01"];
                                        }
                                        else
                                        {
                                            item["TRES"] = "NotNew";
                                        }
                                    }
                                    else
                                    {
                                        item["TRES"] = "NotNew";
                                    }
                                }
                            }
                            catch
                            {

                            }

                        }
                    }
                }
                else
                {
                    IsDBConnect = true;
                    Msg = messagePrint.AddMessage("数据库连接失败");
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                Log.Default.Error("SelectSampleResultfromDt", ex.Message);
            }

        }
        private bool LookforDt(string barcode, ushort index)
        {
            bool r = false;
            string[] arrField = new string[1];
            string[] arrValue = new string[1];
            try
            {
                string tablename = BarsamTableNames[index];
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    arrField[0] = "BARCODE";
                    arrValue[0] = barcode;
                    DataSet s = oraDB.selectSQL(tablename.ToUpper(), arrField, arrValue);
                    SinglDt = s.Tables[0];
                    if (SinglDt.Rows.Count == 0)
                    {
                        Msg = messagePrint.AddMessage("未查询到 " + barcode + " 信息");
                        r = false;

                    }
                    else
                    {
                        Msg = messagePrint.AddMessage("查询到 " + barcode + " 信息");
                        r = true;
                    }


                }
                else
                {
                    IsDBConnect = true;
                    Msg = messagePrint.AddMessage("数据库连接失败");

                    r = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                r = false;
                Log.Default.Error("LookforDt", ex.Message);
            }
            return r;
        }
        private bool samCheckinLoadAction(string user)
        {
            bool r = false;
            string[] arrField = new string[1];
            string[] arrValue = new string[1];
            try
            {
                string tablename = "BARSAMUSER";
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    arrField[0] = "UNAME";
                    arrValue[0] = user.ToUpper();
                    DataSet s = oraDB.selectSQL(tablename.ToUpper(), arrField, arrValue);
                    DataTable singlDt = s.Tables[0];
                    if (singlDt.Rows.Count == 0)
                    {
                        Msg = messagePrint.AddMessage("未查询到 " + user + " 信息");
                        r = false;

                    }
                    else
                    {
                        Msg = messagePrint.AddMessage("查询到 " + user + " 信息");
                        if ((string)singlDt.Rows[0]["PSW"] == Barsamuser_Psw)
                        {
                            Msg = messagePrint.AddMessage("用户 " + user + " 登录成功");
                            SinglDt = singlDt;
                            r = true;
                        }
                        else
                        {
                            Msg = messagePrint.AddMessage("用户 " + user + " 登录失败");
                            r = false;
                        }
                    }


                }
                else
                {
                    IsDBConnect = true;
                    Msg = messagePrint.AddMessage("数据库连接失败");

                    r = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                r = false;
                Log.Default.Error("samCheckinLoadAction", ex.Message);
            }
            return r;
        }
        private bool samUpdateAction1()
        {
            bool r = false;
            try
            {
                X758SamCheckinData x758SamCheckinData = new X758SamCheckinData();
                x758SamCheckinData.Partnum = Barsaminfo_Partnum.ToUpper();
                x758SamCheckinData.Barcode = Barsaminfo_Barcode.ToUpper();
                x758SamCheckinData.Stnum = Barsaminfo_Stnum;
                x758SamCheckinData.Unum = Barsaminfo_Unum;
                x758SamCheckinData.Ngitem = SamNgItemsTableNames[SamNgItemsTableIndex].ToUpper();
                string tablename = "BARSAMINFO";
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    string[,] arrFieldAndNewValue = { { "PARTNUM", x758SamCheckinData.Partnum }, { "SITEM", "FLUKE" }, { "STNUM", x758SamCheckinData.Stnum.ToString() }, { "UNUM", x758SamCheckinData.Unum.ToString() }, { "NGITEM", x758SamCheckinData.Ngitem } };
                    string[,] arrFieldAndOldValue = { { "BARCODE", x758SamCheckinData.Barcode } };
                    oraDB.updateSQL1(tablename.ToUpper(), arrFieldAndNewValue, arrFieldAndOldValue);
                    Msg = messagePrint.AddMessage("数据更新完成");
                    r = true;
                }
                else
                {
                    IsDBConnect = false;
                    Msg = messagePrint.AddMessage("数据库连接失败");
                    r = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                r = false;
                Log.Default.Error("samUpdateAction1", ex.Message);
            }
            return r;
        }
        private bool samInsertAction1()
        {
            bool r = false;
            try
            {
                X758SamCheckinData x758SamCheckinData = new X758SamCheckinData();
                x758SamCheckinData.Partnum = Barsaminfo_Partnum.ToUpper();
                x758SamCheckinData.Barcode = Barsaminfo_Barcode.ToUpper();
                x758SamCheckinData.Stnum = Barsaminfo_Stnum;
                x758SamCheckinData.Unum = Barsaminfo_Unum;
                x758SamCheckinData.Ngitem = SamNgItemsTableNames[SamNgItemsTableIndex].ToUpper();
                string tablename = "BARSAMINFO";
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    string[] arrFieldAndNewValue = { "PARTNUM", "BARCODE", "SITEM", "STNUM", "UNUM", "NGITEM" };
                    string[] arrFieldAndOldValue = { x758SamCheckinData.Partnum, x758SamCheckinData.Barcode, "FLUKE", x758SamCheckinData.Stnum.ToString(), x758SamCheckinData.Unum.ToString(), x758SamCheckinData.Ngitem };
                    oraDB.insertSQL1(tablename.ToUpper(), arrFieldAndNewValue, arrFieldAndOldValue);
                    Msg = messagePrint.AddMessage("数据插入完成");
                    r = true;
                }
                else
                {
                    IsDBConnect = false;
                    Msg = messagePrint.AddMessage("数据库连接失败");
                    r = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                r = false;
                Log.Default.Error("samUpdateAction1", ex.Message);
            }
            return r;
        }
        private bool samInsertAction2(X758SampleResultData x758SampleResultData)
        {
            bool r = false;
            try
            {
                //if (ngitem.Length > 20)
                //{
                //    ngitem = ngitem.Substring(0, 19);
                //}
                //if (tresult.Length > 20)
                //{
                //    tresult = tresult.Substring(0, 19);
                //}

                //X758SampleResultData x758SampleResultData = new X758SampleResultData();
                //x758SampleResultData.PARTNUM = Barsamrec_Partnum.ToUpper();
                //x758SampleResultData.SITEM = "FLUKE";
                //x758SampleResultData.BARCODE = bar.ToUpper();
                //x758SampleResultData.NGITEM = ngitem.ToUpper();
                //x758SampleResultData.TRES = tresult.ToUpper();
                //x758SampleResultData.MNO = mno.ToUpper();
                //x758SampleResultData.CDATE = (DateTime.Now.ToShortDateString()).Replace("/", "");
                //x758SampleResultData.CTIME = (DateTime.Now.ToShortTimeString()).Replace(":", "");
                //x758SampleResultData.SR01 = id;
                if (x758SampleResultData.TRES.Length > 20)
                {
                    x758SampleResultData.TRES = x758SampleResultData.TRES.Substring(0, 19);
                }
                string tablename = "BARSAMREC";
                OraDB oraDB = new OraDB(SQL_ora_server, SQL_ora_user, SQL_ora_pwd);
                if (oraDB.isConnect())
                {
                    IsDBConnect = true;
                    string[] arrFieldAndNewValue = { "PARTNUM", "SITEM", "BARCODE", "NGITEM", "TRES", "MNO", "CDATE", "CTIME", "SR01" };
                    string[] arrFieldAndOldValue = { x758SampleResultData.PARTNUM, x758SampleResultData.SITEM, x758SampleResultData.BARCODE, x758SampleResultData.NGITEM, x758SampleResultData.TRES, x758SampleResultData.MNO, x758SampleResultData.CDATE, x758SampleResultData.CTIME, x758SampleResultData.SR01 };
                    oraDB.insertSQL1(tablename.ToUpper(), arrFieldAndNewValue, arrFieldAndOldValue);
                    Msg = messagePrint.AddMessage("数据插入完成");
                    r = true;
                }
                else
                {
                    IsDBConnect = false;
                    Msg = messagePrint.AddMessage("数据库连接失败");
                    r = false;
                }
                oraDB.disconnect();
            }
            catch (Exception ex)
            {
                r = false;
                Log.Default.Error("samInsertAction2", ex.Message);
            }
            return r;
        }
        private bool samCheckinAction()
        {
            bool r = false;
            try
            {
                //Barsaminfo_Barcode
                if (LookforDt(Barsaminfo_Barcode, 0))
                {
                    //查询到条码信息。执行更新操作
                    r = samUpdateAction1();
                }
                else
                {
                    //未查询到条码信息。
                    if (Barsaminfo_Barcode.Length > 10)
                    {
                        //执行插入操作
                        r = samInsertAction1();
                    }
                    else
                    {
                        r = false;
                    }
                }
            }
            catch
            {

            }
            isCheckinSuccessed = r;
            isCheckined = true;
            return r;
        }
        private async Task<bool> WaitCheckinProcess()
        {
            bool r = false;
            isCheckined = false;
            isCheckinSuccessed = false;
            while (!isCheckined)
            {
                await Task.Delay(100);
            }
            r = isCheckinSuccessed;
            return r;
        }
        //private async Task WaitSampleAlarmIsNeedCheckinProcess()
        //{


        //    SampleAlarm_IsNeedCheckin_finish = false;
        //    while (!SampleAlarm_IsNeedCheckin_finish)
        //    {
        //        await Task.Delay(100);
        //    }


        //}
        #endregion
        #endregion
        #region BECKHOFF
        public void TwincatOperateAction(object p)
        {
            try
            {
                switch (p.ToString())
                {
                    case "1":
                        if ((bool)SuckFailedFlag.Value)
                        {
                            SuckAlarmRst.Value = true;
                            RobotPauseCompleteFlag = true;
                        }
                        break;
                    case "2":
                        if ((bool)XYRDYtoDebug.Value)
                        {
                            XYDebugCMD.Value = true;
                        }


                        break;
                    case "3":
                        if ((bool)XYInDebug.Value)
                        {
                            XYDebugComplete.Value = true;
                        }


                        break;
                    case "4":
                        if ((bool)FRDYtoDebug.Value)
                        {
                            FDebugCMD.Value = true;
                        }


                        break;
                    case "5":
                        if ((bool)FInDebug.Value)
                        {
                            FDebugComplete.Value = true;
                        }


                        break;
                    case "6":
                        if ((bool)TRDYtoDebug.Value)
                        {
                            TDebugCMD.Value = true;
                        }


                        break;
                    case "7":
                        if ((bool)TInDebug.Value)
                        {
                            TDebugComplete.Value = true;
                        }


                        break;

                   
                    default:
                        break;
                }
            }
            catch
            {


            }
        }
        public void ServoResetAction(object p)
        {
            try
            {
                switch (p.ToString())
                {
                    case "1":
                        ServoRst1.Value = true;
                        break;
                    case "2":
                        ServoRst2.Value = true;
                        break;
                    case "3":
                        ServoRst3.Value = true;
                        break;
                    case "4":
                        ServoRst4.Value = true;
                        break;
                    
                    default:
                        break;
                }
            }
            catch
            {


            }

        }
        public void ServoONAction(object p)
        {
            try
            {
                switch (p.ToString())
                {
                    case "1":
                        ServoSVN1.Value = !(bool)ServoSVN1.Value;
                        break;
                    case "2":
                        ServoSVN2.Value = !(bool)ServoSVN2.Value;
                        break;
                    case "3":
                        ServoSVN3.Value = !(bool)ServoSVN3.Value;
                        break;
                    case "4":
                        ServoSVN4.Value = !(bool)ServoSVN4.Value;
                        break;
                    
                    default:
                        break;
                }
            }
            catch
            {


            }

        }
        public void ServoHomeAction(object p)
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "1":
                            EF104.Value = true;
                            break;
                        case "2":
                            EF114.Value = true;
                            break;
                        //case "3":
                        //    ServoSVN3.Value = !(bool)ServoSVN3.Value;
                        //    break;
                        //case "4":
                        //    ServoSVN4.Value = !(bool)ServoSVN4.Value;
                        //break;
                        default:
                            break;
                    }
                }
                if ((bool)FInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "3":
                            F204.Value = true;
                            break;
                        default:
                            break;
                    }
                }
                if ((bool)TInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "4":
                            T204.Value = true;
                            break;
                        default:
                            break;
                    }
                }
                
            }
            catch
            {


            }


        }
        public void JogActionX_Plus()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF100.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionX_Minus()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF101.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionX_Stop()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF100.Value = false;
                    EF101.Value = false;
                }
            }
            catch
            {


            }
        }
        public void JogActionY_Plus()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF110.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionY_Minus()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF111.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionY_Stop()
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    EF110.Value = false;
                    EF111.Value = false;
                }
            }
            catch
            {


            }
        }
        
        private void ServoPTPXY()
        {
            DebugXTargetPositon.Value = DebugTargetX;
            DebugYTargetPositon.Value = DebugTargetY;
            EF102.Value = true;
            EF112.Value = true;

        }
        
        public void JogActionF_Plus()
        {
            try
            {
                if ((bool)FInDebug.Value)
                {
                    F200.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionF_Minus()
        {
            try
            {
                if ((bool)FInDebug.Value)
                {
                    F201.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionF_Stop()
        {
            try
            {
                if ((bool)FInDebug.Value)
                {
                    F200.Value = false;
                    F201.Value = false;
                }
            }
            catch
            {


            }
        }
        private void ServoPTPF()
        {
            DebugFTargetPositon.Value = DebugTargetF;

            F202.Value = true;


        }

        public void JogActionT_Plus()
        {
            try
            {
                if ((bool)TInDebug.Value)
                {
                    T200.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionT_Minus()
        {
            try
            {
                if ((bool)TInDebug.Value)
                {
                    T201.Value = true;
                }
            }
            catch
            {


            }
        }
        public void JogActionT_Stop()
        {
            try
            {
                if ((bool)TInDebug.Value)
                {
                    T200.Value = false;
                    T201.Value = false;
                }
            }
            catch
            {


            }
        }
        private void ServoPTPT()
        {
            DebugTTargetPositon.Value = DebugTargetT;

            T202.Value = true;


        }

        public void MovetoPointAction(object p)
        {
            try
            {
                if ((bool)XYInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "1":
                            DebugTargetX = (double)ReleasePositionX1.Value;
                            DebugTargetY = (double)ReleasePositionY1.Value;
                            ServoPTPXY();
                            break;
                        case "2":
                            DebugTargetX = (double)ReleasePositionX2.Value;
                            DebugTargetY = (double)ReleasePositionY2.Value;
                            ServoPTPXY();
                            break;
                        case "3":
                            DebugTargetX = (double)ReleasePositionX3.Value;
                            DebugTargetY = (double)ReleasePositionY3.Value;
                            ServoPTPXY();
                            break;
                        case "4":
                            DebugTargetX = (double)PickPositionX.Value;
                            DebugTargetY = (double)PickPositionY.Value;
                            ServoPTPXY();
                            break;
                        case "5":
                            DebugTargetX = (double)WaitPositionX.Value;
                            DebugTargetY = (double)WaitPositionY.Value;
                            ServoPTPXY();
                            break;
                        default:
                            break;
                    }
                }
                if ((bool)FInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "6":
                            DebugTargetF = (double)FPosition1.Value;
                            ServoPTPF();
                            break;
                        case "7":
                            DebugTargetF = (double)FPosition2.Value;
                            ServoPTPF();
                            break;
                        case "8":
                            DebugTargetF = (double)FPosition3.Value;
                            ServoPTPF();
                            break;
                        case "9":
                            DebugTargetF = (double)FPosition4.Value;
                            ServoPTPF();
                            break;
                        case "10":
                            DebugTargetF = (double)FPosition5.Value;
                            ServoPTPF();
                            break;
                        case "11":
                            DebugTargetF = (double)FPosition6.Value;
                            ServoPTPF();
                            break;
                        case "12":
                            DebugTargetF = (double)FPosition7.Value;
                            ServoPTPF();
                            break;
                        case "24":
                            DebugTargetF = (double)FPosition8.Value;
                            ServoPTPF();
                            break;
                        default:
                            break;
                    }
                }

               
                if ((bool)TInDebug.Value)
                {
                    switch (p.ToString())
                    {
                        case "13":
                            DebugTargetT = (double)TPosition1.Value;
                            ServoPTPT();
                            break;
                        case "14":
                            DebugTargetT = (double)TPosition2.Value;
                            ServoPTPT();
                            break;
                        case "15":
                            DebugTargetT = (double)TPosition3.Value;
                            ServoPTPT();
                            break;
                        case "16":
                            DebugTargetT = (double)TPosition4.Value;
                            ServoPTPT();
                            break;
                        case "17":
                            DebugTargetT = (double)TPosition5.Value;
                            ServoPTPT();
                            break;

                        default:
                            break;
                    }
                }
            }
            catch
            {


            }
        }
        public void GetCoord(object p)
        {
            try
            {
                switch (p.ToString())
                {
                    case "1":
                        ReleasePositionX1.Value = (double)XPos.Value;
                        ReleasePositionY1.Value = (double)YPos.Value;
                        Calc_Start.Value = true;
                        break;
                    case "2":
                        ReleasePositionX2.Value = (double)XPos.Value;
                        ReleasePositionY2.Value = (double)YPos.Value;
                        Calc_Start.Value = true;
                        break;
                    case "3":
                        ReleasePositionX3.Value = (double)XPos.Value;
                        ReleasePositionY3.Value = (double)YPos.Value;
                        Calc_Start.Value = true;
                        break;
                    case "4":
                        PickPositionX.Value = (double)XPos.Value;
                        PickPositionY.Value = (double)YPos.Value;
                        //Calc_Start.Value = true;
                        break;
                    case "5":
                        WaitPositionX.Value = (double)XPos.Value;
                        WaitPositionY.Value = (double)YPos.Value;
                        //Calc_Start.Value = true;
                        break;
                    case "6":
                        FPosition1.Value = (double)FPos.Value;
                        break;
                    case "7":
                        FPosition2.Value = (double)FPos.Value;
                        break;
                    case "8":
                        FPosition3.Value = (double)FPos.Value;
                        break;
                    case "9":
                        FPosition4.Value = (double)FPos.Value;
                        break;
                    case "10":
                        FPosition5.Value = (double)FPos.Value;
                        break;
                    case "11":
                        FPosition6.Value = (double)FPos.Value;
                        break;
                    case "12":
                        FPosition7.Value = (double)FPos.Value;
                        break;
                    case "24":
                        FPosition8.Value = (double)FPos.Value;
                        break;
                    case "13":
                        TPosition1.Value = (double)TPos.Value;
                        break;
                    case "14":
                        TPosition2.Value = (double)TPos.Value;
                        break;
                    case "15":
                        TPosition3.Value = (double)TPos.Value;
                        break;
                    case "16":
                        TPosition4.Value = (double)TPos.Value;
                        break;
                    case "17":
                        TPosition5.Value = (double)TPos.Value;
                        break;

                    
                    default:
                        break;
                }
            }
            catch
            {


            }
        }
        public delegate void TwinCatProcessedDelegate(string s);
        public async void FMoveProcessStart(TwinCatProcessedDelegate callback, string s)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    FCmdIndex.Value = ushort.Parse(s);
                    await Task.Delay(100);
                    FMoveCMD.Value = true;
                    FMoveCompleted.Value = false;

                    while (!(bool)FMoveCompleted.Value)
                    {
                        await Task.Delay(100);
                        if (EStop)
                        {
                            break;
                        }
                    }
                    if (!EStop)
                    {
                        callback("FMOVE;" + s);
                    }

                }
                );
            };
            await startTask();
        }
        public delegate void PLCUnLoadProcessedDelegate();
        public async void PLCUnLoadProcessStart(PLCUnLoadProcessedDelegate callback)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {

                    //while (!XinjiePLC.readM(420))
                    while (true)
                    {
                        await Task.Delay(100);
                        if (EStop)
                        {
                            break;
                        }
                    }
                    if (!EStop)
                    {
                        callback();
                    }

                }
                );
            };
            await Task.Delay(1000);
            await startTask();
        }
        public async void TMoveProcessStart(TwinCatProcessedDelegate callback, string s)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    TCmdIndex.Value = ushort.Parse(s);
                    await Task.Delay(100);
                    TMoveCMD.Value = true;
                    TMoveCompleted.Value = false;

                    while (!(bool)TMoveCompleted.Value)
                    {
                        await Task.Delay(100);
                        if (EStop)
                        {
                            break;
                        }
                    }
                    if (!EStop)
                    {
                        callback("TMOVE;" + s);
                    }

                }
                );
            };
            await startTask();
        }
        public async void ULoadProcessStart(TwinCatProcessedDelegate callback)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    TUnloadCMD.Value = true;
                    TUnloadCompleted.Value = false;

                    while (!(bool)TUnloadCompleted.Value)
                    {
                        await Task.Delay(100);
                        if (EStop)
                        {
                            break;
                        }
                    }
                    if (!EStop)
                    {
                        callback("ULOAD");
                    }

                }
                );
            };
            await startTask();
        }
        public async void ResetCMDProcessStart(TwinCatProcessedDelegate callback)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    ResetCMD.Value = true;
                    ReadTwinCatDatafromIni();

                    while (!(bool)ResetCMDComplete.Value)
                    {
                        await Task.Delay(100);
                        if (EStop)
                        {
                            break;
                        }
                    }
                    if (!EStop)
                    {
                        callback("ResetCMD");
                    }

                }
                );
            };
            await startTask();
        }
        public async void TwinCatProcessStartCallback(string str)
        {
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync(str);
            }
        }
        #endregion
        #region 事件相应函数
        private void EPSONCommTwincatEventProcess(string str)
        {
            string[] strs = str.Split(',');
            switch (strs[0])
            {
                case "FMOVE":
                    FMoveProcessStart(TwinCatProcessStartCallback, strs[1]);
                    break;
                case "TMOVE":
                    TMoveProcessStart(TwinCatProcessStartCallback, strs[1]);
                    break;
                case "ULOAD":
                    ULoadProcessStart(TwinCatProcessStartCallback);
                    break;
                case "ResetCMD":
                    ResetCMDProcessStart(TwinCatProcessStartCallback);
                    break;
                default:
                    break;
            }
        }
        private void EPSONSampleResultProcess(string str)
        {
            //CmdSend$ = "SampleResult," + Str$(i + 1) + "," + Str$(k + 1) + "," + SampleResult$
         
            string[] strs = str.Split(',');
           
            int i = 0, j = 0;

            try
            {
                i = int.Parse(strs[1]) - 1; j = int.Parse(strs[2]) - 1;
                if (strs[3] == "True")
                {
                    SampleDisplayArray[i, j] = "ok";
                }
                else
                {
                    SampleDisplayArray[i, j] = "NG";
                }
            }
            catch
            {

               
            }























            //switch (strs[2])
            //{
            //    case "OK":
            //        ngitem = SampleNgitem1;
            //        j = 0;
            //        break;
            //    case "NG":
            //        ngitem = SampleNgitem2;
            //        j = 1;
            //        break;
            //    case "NG1":
            //        ngitem = SampleNgitem3;
            //        j = 2;
            //        break;
            //    case "NG2":
            //        ngitem = SampleNgitem4;
            //        j = 3;
            //        break;
            //    case "NG3":
            //        ngitem = SampleNgitem5;
            //        j = 4;
            //        break;
            //    case "NG4":
            //        ngitem = SampleNgitem6;
            //        j = 5;
            //        break;
            //    case "NG5":
            //        ngitem = SampleNgitem7;
            //        j = 6;
            //        break;
            //    case "NG6":
            //        ngitem = SampleNgitem8;
            //        j = 7;
            //        break;
            //    case "NG7":
            //        ngitem = SampleNgitem9;
            //        j = 8;
            //        break;
            //    case "NG8":
            //        ngitem = SampleNgitem10;
            //        j = 9;
            //        break;
            //    default:

            //        break;
            //}
            //switch (strs[3])
            //{
            //    case "OK":
            //        tresult = SampleNgitem1;
            //        break;
            //    case "NG":
            //        tresult = SampleNgitem2;
            //        break;
            //    case "NG1":
            //        tresult = SampleNgitem3;
            //        break;
            //    case "NG2":
            //        tresult = SampleNgitem4;
            //        break;
            //    case "NG3":
            //        tresult = SampleNgitem5;
            //        break;
            //    case "NG4":
            //        tresult = SampleNgitem6;
            //        break;
            //    case "NG5":
            //        tresult = SampleNgitem7;
            //        break;
            //    case "NG6":
            //        tresult = SampleNgitem8;
            //        break;
            //    case "NG7":
            //        tresult = SampleNgitem9;
            //        break;
            //    case "NG8":
            //        tresult = SampleNgitem10;
            //        break;
            //    default:

            //        break;
            //}
            //string bordid = "";
            //switch (strs[1])
            //{
            //    case "1":
            //        bordid = Barsamrec_ID1;
            //        i = 0;
            //        break;
            //    case "2":
            //        bordid = Barsamrec_ID2;
            //        i = 1;
            //        break;
            //    case "3":
            //        bordid = Barsamrec_ID3;
            //        i = 2;
            //        break;
            //    case "4":
            //        bordid = Barsamrec_ID4;
            //        i = 3;
            //        break;
            //    default:
            //        break;
            //}
            //string mno = Barsamrec_Mno + "Flex" + strs[1];
            ////samInsertAction2(bar, ngitem, tresult, mno);


            //DataRow dr = SampleDt.NewRow();
            //dr["PARTNUM"] = Barsamrec_Partnum.ToUpper();
            //dr["SITEM"] = "FLUKE";
            //dr["BARCODE"] = bar.ToUpper();
            //dr["NGITEM"] = ngitem;
            //dr["TRES"] = tresult;
            //dr["MNO"] = mno.ToUpper();
            //dr["CDATE"] = DateTime.Now.ToString("yyyyMMdd");
            //dr["CTIME"] = DateTime.Now.ToString("HHmmss");
            //dr["SR01"] = bordid.ToUpper();
            //dr["FL02"] = DateTime.Now.ToString("yyyyMMdd");
            //dr["FL03"] = DateTime.Now.ToString("HHmmss");


            //SampleDt.Rows.Add(dr);
            //if (ngitem == tresult)
            //{
            //    SampleDisplayArray[i, j] = "ok";
            //}
            //else
            //{
            //    SampleDisplayArray[i, j] = tresult;
            //}

        }
        private async void EPSONSelectSampleResultfromDtProcess(string str)
        {
            ushort i = 0, j = 0;
            SelectSampleResultfromDt();
            foreach (DataRow item in SampleDt.Rows)
            {
                X758SampleResultData x758SampleResultData = new X758SampleResultData();
                x758SampleResultData.PARTNUM = (string)item["PARTNUM"];
                x758SampleResultData.SITEM = (string)item["SITEM"];
                x758SampleResultData.BARCODE = (string)item["BARCODE"];
                x758SampleResultData.NGITEM = (string)item["NGITEM"];
                x758SampleResultData.TRES = (string)item["TRES"];
                x758SampleResultData.MNO = (string)item["MNO"];
                x758SampleResultData.CDATE = (string)item["CDATE"];
                x758SampleResultData.CTIME = (string)item["CTIME"];
                x758SampleResultData.SR01 = (string)item["SR01"];
                //插入数据库
                samInsertAction2(x758SampleResultData);

                if ((string)item["TRES"] != (string)item["NGITEM"])
                {
                    await Task.Delay(100);
                    string NgItem = "Error";
                    if ((string)item["NGITEM"] == SampleNgitem1)
                    {
                        NgItem = "OK";
                        j = 0;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem2)
                    {
                        NgItem = "NG";
                        j = 1;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem3)
                    {
                        NgItem = "NG1";
                        j = 2;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem4)
                    {
                        NgItem = "NG2";
                        j = 3;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem5)
                    {
                        NgItem = "NG3";
                        j = 4;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem6)
                    {
                        NgItem = "NG4";
                        j = 5;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem7)
                    {
                        NgItem = "NG5";
                        j = 6;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem8)
                    {
                        NgItem = "NG6";
                        j = 7;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem9)
                    {
                        NgItem = "NG7";
                        j = 8;
                    }
                    if ((string)item["NGITEM"] == SampleNgitem10)
                    {
                        NgItem = "NG8";
                        j = 9;
                    }
                    ushort FlexNum = 0;
                    if ((string)item["MNO"] == (Barsamrec_Mno + "Flex").ToUpper() + "1")
                    {
                        FlexNum = 1;
                        i = 0;
                    }
                    if ((string)item["MNO"] == (Barsamrec_Mno + "Flex").ToUpper() + "2")
                    {
                        FlexNum = 2;
                        i = 1;
                    }
                    if ((string)item["MNO"] == (Barsamrec_Mno + "Flex").ToUpper() + "3")
                    {
                        FlexNum = 3;
                        i = 2;
                    }
                    if ((string)item["MNO"] == (Barsamrec_Mno + "Flex").ToUpper() + "4")
                    {
                        FlexNum = 4;
                        i = 3;
                    }
                    SampleDisplayArray[i, j] = (string)item["TRES"];
                    if (epsonRC90.TestSendStatus && FlexNum > 0)
                    {
                        await epsonRC90.TestSentNet.SendAsync("SelectSampleResultfromDt;" + FlexNum.ToString() + ";" + NgItem);
                    }
                }
            }
            await Task.Delay(100);
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync("SelectSampleResultfromDtFinish");
            }
            //保存样本数据到本地
            SaveSampleRecordLocal("");
        }
        //private void EPSONSampleHaveProcess(string str)
        //{
        //    string[] strs = str.Split(',');
        //    try
        //    {
        //        switch (strs[2])
        //        {
        //            case "0":
        //                SampleHave1 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave1", SampleHave1.ToString());
        //                break;
        //            case "1":
        //                SampleHave2 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave2", SampleHave2.ToString());
        //                break;
        //            case "2":
        //                SampleHave3 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave3", SampleHave3.ToString());
        //                break;
        //            case "3":
        //                SampleHave4 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave4", SampleHave4.ToString());
        //                break;
        //            case "4":
        //                SampleHave5 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave5", SampleHave5.ToString());
        //                break;
        //            case "5":
        //                SampleHave6 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave6", SampleHave6.ToString());
        //                break;
        //            case "6":
        //                SampleHave7 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave7", SampleHave7.ToString());
        //                break;
        //            case "7":
        //                SampleHave8 = bool.Parse(strs[1]);
        //                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleHave8", SampleHave8.ToString());
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch
        //    {


        //    }



        //}
        private async void EPSONEPSONGRRTimesAskProcess(string str)
        {
            if (epsonRC90.TestSendStatus)
            {
                await epsonRC90.TestSentNet.SendAsync("GRRTimesAsk;" + PcsGrrNeedNum.ToString() + ";" + PcsGrrNeedCount.ToString());
            }
        }
        private void ModelPrintEventProcess(string str)
        {
            Msg = messagePrint.AddMessage(str);
            if (DangbanFirstProduct != GetBanci())
            {
                if (str.Contains("ScanWithNum"))
                {
                    DangbanFirstProduct = GetBanci();
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "DangbanFirstProduct", DangbanFirstProduct);
                    Msg = messagePrint.AddMessage(DangbanFirstProduct + " 开班第1片");
                }
            }
            switch (str)
            {
                case "MsgRev: 请确认，不得取走上料盘产品":
                    ShowAlarmTextGrid("请确认，\n不得取走上料盘产品！");
                    RobotRestarted = true;
                    break;
                case "MsgRev: 样本盘，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                    }
                    ShowAlarmTextGrid("样本盘，吸取失败");
                    //addAlarm("测试机1，吸取失败");
                    break;
                case "MsgRev: 测试机1，样本 吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                    }
                    ShowAlarmTextGrid("测试机1，样本 吸取失败\n请将产品放回原位！");
                    break;
                case "MsgRev: 测试机2，样本 吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                    }
                    ShowAlarmTextGrid("测试机2，样本 吸取失败\n请将产品放回原位！");
                    break;
                case "MsgRev: 测试机3，样本 吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                    }
                    ShowAlarmTextGrid("测试机3，样本 吸取失败\n请将产品放回原位！");
                    break;
                case "MsgRev: 测试机4，样本 吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                    }
                    ShowAlarmTextGrid("测试机4，样本 吸取失败\n请将产品放回原位！");
                    break;
                case "MsgRev: 测试机1，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        alarmTableItemsList[0].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();

                        //SaveCSVfileAlarm("测试机1，吸取失败");
                        SaveCSVfileAlarm("Tester1 Suck Fail");
                    }
                    ShowAlarmTextGrid("测试机1，吸取失败\n请将产品取走，防止叠料！");
                    WriteAlarmCSV_Robot("000");
                    AlarmDisplayShow();
                    //addAlarm("测试机1，吸取失败");
                    break;
                case "MsgRev: 测试机2，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        alarmTableItemsList[1].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                        //SaveCSVfileAlarm("测试机2，吸取失败");
                        SaveCSVfileAlarm("Tester2 Suck Fail");
                    }
                    ShowAlarmTextGrid("测试机2，吸取失败\n请将产品取走，防止叠料！");
                    WriteAlarmCSV_Robot("001");
                    AlarmDisplayShow();
                    //addAlarm("测试机2，吸取失败");
                    break;
                case "MsgRev: 测试机3，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        alarmTableItemsList[2].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                        //SaveCSVfileAlarm("测试机3，吸取失败");
                        SaveCSVfileAlarm("Tester3 Suck Fail");
                    }
                    ShowAlarmTextGrid("测试机3，吸取失败\n请将产品取走，防止叠料！");
                    WriteAlarmCSV_Robot("002");
                    AlarmDisplayShow();
                    //addAlarm("测试机3，吸取失败");
                    break;
                case "MsgRev: 测试机4，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        alarmTableItemsList[3].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                        //SaveCSVfileAlarm("测试机4，吸取失败");
                        SaveCSVfileAlarm("Tester4 Suck Fail");
                    }
                    ShowAlarmTextGrid("测试机4，吸取失败\n请将产品取走，防止叠料！");
                    WriteAlarmCSV_Robot("004");
                    AlarmDisplayShow();
                    //addAlarm("测试机4，吸取失败");
                    break;
                case "MsgRev: 测试机1，吸取失败1":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机1，吸取失败\n请将产品取走，防止叠料！");
                    //addAlarm("测试机1，吸取失败");
                    break;
                case "MsgRev: 测试机2，吸取失败1":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机2，吸取失败\n请将产品取走，防止叠料！");
                    break;
                case "MsgRev: 测试机3，吸取失败1":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机3，吸取失败\n请将产品取走，防止叠料！");
                    break;
                case "MsgRev: 测试机4，吸取失败1":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机4，吸取失败\n请将产品取走，防止叠料！");
                    break;
                case "MsgRev: 测试机1，吸取失败2":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机1，吸取失败\n请将产品放回原位，重新吸取！");
                    //addAlarm("测试机1，吸取失败");
                    break;
                case "MsgRev: 测试机2，吸取失败2":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机2，吸取失败\n请将产品放回原位，重新吸取！");
                    break;
                case "MsgRev: 测试机3，吸取失败2":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机3，吸取失败\n请将产品放回原位，重新吸取！");
                    break;
                case "MsgRev: 测试机4，吸取失败2":
                    lastAlarmString = str;
                    ShowAlarmTextGrid("测试机4，吸取失败\n请将产品放回原位，重新吸取！");
                    break;
                case "MsgRev: 上料盘1，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘1，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position1 Suck Fail");
                        alarmTableItemsList[4].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘1，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("004");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘2，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘2，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position2 Suck Fail");
                        alarmTableItemsList[5].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘2，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("005");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘3，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘3，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position3 Suck Fail");
                        alarmTableItemsList[6].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘3，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("006");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘4，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘4，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position4 Suck Fail");
                        alarmTableItemsList[7].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘4，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("007");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘5，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘5，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position5 Suck Fail");
                        alarmTableItemsList[8].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘5，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("008");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘6，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘6，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position6 Suck Fail");
                        alarmTableItemsList[9].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘6，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("009");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘7，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘6，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position7 Suck Fail");
                        alarmTableItemsList[10].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘7，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("010");
                    //addAlarm("上料盘，吸取失败");
                    break;
                case "MsgRev: 上料盘8，吸取失败":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;
                        //SaveCSVfileAlarm("上料盘6，吸取失败");
                        SaveCSVfileAlarm("FPC AdjustPanel Position8 Suck Fail");
                        alarmTableItemsList[11].SuckFail += 1;
                        TotalAlarmNum++;
                        WriteAlarmRecord();
                    }
                    ShowAlarmTextGrid("上料盘8，吸取失败\n请将产品放回原位");
                    WriteAlarmCSV_Robot("011");
                    //addAlarm("上料盘，吸取失败");
                    break;
                //case "MsgRev: 蚀刻不良":
                //    ShowAlarmTextGrid("蚀刻不良");
                //    break;
                //case "MsgRev: 扫码不良":
                //    ShowAlarmTextGrid("扫码不良");
                //    break;
                case "MsgRev: 测试机1，测试超时":
                    ShowAlarmTextGrid("测试机1，测试超时");
                    WriteAlarmCSV_Robot("012");
                    //addAlarm("测试机1，测试超时");
                    //alarmTableItemsList[0].测试机超时 += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机1，测试超时");
                    break;
                case "MsgRev: 测试机2，测试超时":
                    ShowAlarmTextGrid("测试机2，测试超时");
                    WriteAlarmCSV_Robot("013");
                    //addAlarm("测试机2，测试超时");
                    //alarmTableItemsList[1].测试机超时 += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机2，测试超时");
                    break;
                case "MsgRev: 测试机3，测试超时":
                    ShowAlarmTextGrid("测试机3，测试超时");
                    WriteAlarmCSV_Robot("014");
                    //addAlarm("测试机3，测试超时");
                    //alarmTableItemsList[2].测试机超时 += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机3，测试超时");
                    break;
                case "MsgRev: 测试机4，测试超时":
                    ShowAlarmTextGrid("测试机4，测试超时");
                    WriteAlarmCSV_Robot("015");
                    //addAlarm("测试机4，测试超时");
                    //alarmTableItemsList[3].测试机超时 += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机4，测试超时");
                    break;
                case "MsgRev: 测试机1，连续NG":
                    ShowAlarmTextGrid("测试机1，连续NG");
                    WriteAlarmCSV_Robot("016");
                    //addAlarm("测试机1，连续NG");
                    //alarmTableItemsList[0].连续NG += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机1，连续NG");
                    break;
                case "MsgRev: 测试机2，连续NG":
                    ShowAlarmTextGrid("测试机2，连续NG");
                    WriteAlarmCSV_Robot("017");
                    //addAlarm("测试机2，连续NG");
                    //alarmTableItemsList[1].连续NG += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机2，连续NG");
                    break;
                case "MsgRev: 测试机3，连续NG":
                    ShowAlarmTextGrid("测试机3，连续NG");
                    WriteAlarmCSV_Robot("018");
                    //addAlarm("测试机3，连续NG");
                    //alarmTableItemsList[2].连续NG += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机3，连续NG");
                    break;
                case "MsgRev: 测试机4，连续NG":
                    ShowAlarmTextGrid("测试机4，连续NG");
                    WriteAlarmCSV_Robot("019");
                    //addAlarm("测试机4，连续NG");
                    //alarmTableItemsList[3].连续NG += 1;
                    //WriteAlarmRecord();
                    //SaveCSVfileAlarm("测试机4，连续NG");
                    break;
                case "MsgRev: 黑色盘满，换盘":
                    ShowAlarmTextGrid("黑色盘满，换盘");
                    break;
                case "MsgRev: 红色盘满，换盘":
                    ShowAlarmTextGrid("红色盘满，换盘");
                    break;
                case "MsgRev: 测试机1，上传软体异常":
                    ShowAlarmTextGrid("测试机1，上传软体异常");
                    WriteAlarmCSV_Robot("020");
                    break;
                case "MsgRev: 测试机2，上传软体异常":
                    ShowAlarmTextGrid("测试机2，上传软体异常");
                    WriteAlarmCSV_Robot("021");
                    break;
                case "MsgRev: 测试机3，上传软体异常":
                    ShowAlarmTextGrid("测试机3，上传软体异常");
                    WriteAlarmCSV_Robot("022");
                    break;
                case "MsgRev: 测试机4，上传软体异常":
                    ShowAlarmTextGrid("测试机4，上传软体异常");
                    WriteAlarmCSV_Robot("023");
                    break;
                case "MsgRev: 测试机1，良率异常":
                    ShowAlarmTextGrid("测试机1，良率超下限\n请联系工程师处理");
                    WriteAlarmCSV_Robot("024");
                    AdminButtonVisibility = "Visible";
                    break;
                case "MsgRev: 测试机2，良率异常":
                    ShowAlarmTextGrid("测试机2，良率超下限\n请联系工程师处理");
                    WriteAlarmCSV_Robot("025");
                    AdminButtonVisibility = "Visible";
                    break;
                case "MsgRev: 测试机3，良率异常":
                    ShowAlarmTextGrid("测试机3，良率超下限\n请联系工程师处理");
                    WriteAlarmCSV_Robot("026");
                    AdminButtonVisibility = "Visible";
                    break;
                case "MsgRev: 测试机4，良率异常":
                    ShowAlarmTextGrid("测试机4，良率超下限\n请联系工程师处理");
                    WriteAlarmCSV_Robot("027");
                    AdminButtonVisibility = "Visible";
                    break;
                case "MsgRev: 产品记录异常":
                    ShowAlarmTextGrid("比对INI记录异常\n请从吸嘴取下该产品");
                    WriteAlarmCSV_Robot("028");
                    break;
                case "MsgRev: 条码查询记录异常":
                    ShowAlarmTextGrid("扫码，对比条码异常\n请从吸嘴取下该产品");
                    break;
                case "MsgRev: 存在掉料":
                    ShowAlarmTextGrid("存在掉料\n请找回产品");
                    WriteAlarmCSV_Robot("029");
                    break;
                //case "MsgRev: 单穴测试，一次完成":
                //    SingleTestTimes++;
                //    break;
                case "MsgRev: 测试工位1，产品没放好":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;

                        if (!Testerwith4item.IsInSampleMode)
                        {
                            alarmTableItemsList[0].ReleaseFail += 1;
                            TotalAlarmNum++;
                            WriteAlarmRecord();

                            SaveCSVfileAlarm("Tester1 Release FPC Fail");
                        }
                    }
                    ShowAlarmTextGrid("测试工位1，产品没放好\n请将产品放回原位");
                    //addAlarm("测试工位1，产品没放好");
                    break;
                case "MsgRev: 测试工位2，产品没放好":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;

                        if (!Testerwith4item.IsInSampleMode)
                        {
                            alarmTableItemsList[1].ReleaseFail += 1;
                            TotalAlarmNum++;
                            WriteAlarmRecord();
                            //SaveCSVfileAlarm("测试工位2，产品没放好");
                            SaveCSVfileAlarm("Tester2 Release FPC Fail");
                        }
                    }
                    ShowAlarmTextGrid("测试工位2，产品没放好\n请将产品放回原位");
                    //addAlarm("测试工位2，产品没放好");
                    break;
                case "MsgRev: 测试工位3，产品没放好":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;

                        if (!Testerwith4item.IsInSampleMode)
                        {
                            alarmTableItemsList[2].ReleaseFail += 1;
                            TotalAlarmNum++;
                            WriteAlarmRecord();
                            //SaveCSVfileAlarm("测试工位3，产品没放好");
                            SaveCSVfileAlarm("Tester3 Release FPC Fail");
                        }
                    }
                    ShowAlarmTextGrid("测试工位3，产品没放好\n请将产品放回原位");
                    //addAlarm("测试工位3，产品没放好");
                    break;
                case "MsgRev: 测试工位4，产品没放好":
                    if (lastAlarmString != str)
                    {
                        lastAlarmString = str;

                        if (!Testerwith4item.IsInSampleMode)
                        {
                            alarmTableItemsList[3].ReleaseFail += 1;
                            TotalAlarmNum++;
                            WriteAlarmRecord();
                            //SaveCSVfileAlarm("测试工位4，产品没放好");
                            SaveCSVfileAlarm("Tester4 Release FPC Fail");
                        }
                    }
                    ShowAlarmTextGrid("测试工位4，产品没放好\n请将产品放回原位");
                    //addAlarm("测试工位4，产品没放好");
                    break;
                //case "MsgRev: 测试工位1，B爪手掉料":
                //    ShowAlarmTextGrid("测试工位1，B爪手掉料");
                //    break;
                //case "MsgRev: 测试工位2，B爪手掉料":
                //    ShowAlarmTextGrid("测试工位2，B爪手掉料");
                //    break;
                //case "MsgRev: 测试工位3，B爪手掉料":
                //    ShowAlarmTextGrid("测试工位3，B爪手掉料");
                //    break;
                //case "MsgRev: 测试工位4，B爪手掉料":
                //    ShowAlarmTextGrid("测试工位4，B爪手掉料");
                //    break;
                case "MsgRev: A爪手掉料":
                    ShowAlarmTextGrid("A爪手掉料");
                    WriteAlarmCSV_Robot("030");
                    //addAlarm("A爪手掉料");
                    SaveCSVfileAlarm("A GrabHand lose FPC");

                    AlarmDisplayShow();
                    break;
                case "MsgRev: B爪手掉料":
                    ShowAlarmTextGrid("B爪手掉料");
                    WriteAlarmCSV_Robot("031");
                    //addAlarm("B爪手掉料");
                    SaveCSVfileAlarm("B GrabHand lose FPC");
                    AlarmDisplayShow();
                    break;
                case "MsgRev: 清洁操作，结束":
                    DateTimeUtility.GetLocalTime(ref lastchuiqi);
                    LastChuiqiTimeStr = lastchuiqi.ToDateTime().ToString();
                    SaveLastSamplTimetoIni();
                    AllowCleanActionCommand = true;
                    break;
                case "MsgRev: 样本测试，开始":
                    //Testerwith4item.IsInSampleMode = true;
                    SIMTester.IsInSampleMode = true;
                    //SampleWindowCloseEnable = false;
                    //AllowSampleTestCommand = false;

                    break;
                //case "MsgRev: 排料完成":
                    //LiaoCountIN = liaoCountIN;
                    //LiaoCountOut = liaoCountOUT;
                    //LiaoDelta = (int)liaoCountIN - (int)liaoCountOUT;
                    //Inifile.INIWriteValue(iniParameterPath, "DiaoLiao", "LiaoCountIN", LiaoCountIN.ToString());
                    //Inifile.INIWriteValue(iniParameterPath, "DiaoLiao", "LiaoCountOut", LiaoCountOut.ToString());
                    //Inifile.INIWriteValue(iniParameterPath, "DiaoLiao", "LiaoDelta", LiaoDelta.ToString());
                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("BARCODE", typeof(string));
                    //foreach (QuiLiaoBarcode item in QueLiaoWorkList)
                    //{
                    //    QueLiaoTable1.Add(item);
                    //    DataRow dr = dt.NewRow();
                    //    dr["BARCODE"] = item.条码;
                    //    dt.Rows.Add(dr);
                        
                    //}
                    //if (File.Exists("D:\\queliaobarcode.csv"))
                    //{
                    //    File.Delete("D:\\queliaobarcode.csv");
                    //}
                    //if (dt.Rows.Count > 0)
                    //{
                    //    Csvfile.dt2csv(dt, "D:\\queliaobarcode.csv", "条码", "BARCODE");
                    //}
                    //QueLiaoWorkList.Clear();
                    //liaoCountIN = 0;
                    //liaoCountOUT = 0;
                    //ShowDiaoLiaoWindow = !ShowDiaoLiaoWindow;
                    //break;

                //case "MsgRev: 延时30秒，等待查询样本测试结果":
                //    SampleWaitTimeShow = "Visible";
                //    SampleCount_down();
                    //break;
                case "MsgRev: 样本测试，结束":
                    //DateTimeUtility.GetLocalTime(ref lastSample);
                    //LastSampleTestTimeStr = lastSample.ToDateTime().ToString();
                    //SaveLastSamplTimetoIni();
                    //AllowSampleTestCommand = true;
                    //if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 19)
                    //{
                    //    LastSampleHour = DateTime.Now.DayOfYear * 24 + 7;
                    //}
                    //else
                    //{
                    //    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 7)
                    //    {
                    //        LastSampleHour = (DateTime.Now.DayOfYear - 1) * 24 + 19;
                    //    }
                    //    else
                    //    {
                    //        LastSampleHour = DateTime.Now.DayOfYear * 24 + 19;
                    //    }
                    //}
                    //LastSampleHour = DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour;
                    //Inifile.INIWriteValue(iniParameterPath, "Sample", "LastSampleHour", LastSampleHour.ToString());
                    //Testerwith4item.IsInSampleMode = false;
                    SIMTester.IsInSampleMode = false;
                    LastSampleTestFinishTime = System.DateTime.Now.ToString();
                    Inifile.INIWriteValue(iniParameterPath, "System", "LastSampleTestFinishTime", LastSampleTestFinishTime);
                    SampleWindowCloseEnable = true;
                    break;
                case "MsgRev: 样本测试结果，NG":
                    //SampleRetestButtonVisibility = "Visible";
                    ShowAlarmTextGrid("样本测试结果，NG");
                    //addAlarm("样本测试错误");
                    //SaveCSVfileAlarm("样本测试错误");
                    //DateTimeUtility.GetLocalTime(ref lastSample);
                    //LastSampleTestTimeStr = lastSample.ToDateTime().ToString();
                    //SaveLastSamplTimetoIni();
                    //AllowSampleTestCommand = true;
                    //SaveSampleRecordLocal();
                    //Testerwith4item.IsInSampleMode = false;
                    break;
                case "MsgRev: 样本盘缺料":
                    ShowAlarmTextGrid("样本盘缺料");
                    //addAlarm("样本盘缺料");
                    //SaveCSVfileAlarm("样本盘缺料");
                    break;
                case "MsgRev: 测试机有料，请清空":
                    ShowAlarmTextGrid("测试机有料，请清空");
                    break;
                case "TestRevFlex: Start,1,A":
                    if (ZhiJu1ZuoBupin1 != "")
                    {
                        ZhiJu1ZuoDangqian1++;
                    }
                    if (ZhiJu1ZuoBupin2 != "")
                    {
                        ZhiJu1ZuoDangqian2++;
                    }
                    if (ZhiJu1ZuoBupin3 != "")
                    {
                        ZhiJu1ZuoDangqian3++;
                    }
                    if (ZhiJu1ZuoBupin4 != "")
                    {
                        ZhiJu1ZuoDangqian4++;
                    }
                    if (ZhiJu1ZuoBupin5 != "")
                    {
                        ZhiJu1ZuoDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,1,B":
                    if (ZhiJu1ZuoBupin1 != "")
                    {
                        ZhiJu1ZuoDangqian1++;
                    }
                    if (ZhiJu1ZuoBupin2 != "")
                    {
                        ZhiJu1ZuoDangqian2++;
                    }
                    if (ZhiJu1ZuoBupin3 != "")
                    {
                        ZhiJu1ZuoDangqian3++;
                    }
                    if (ZhiJu1ZuoBupin4 != "")
                    {
                        ZhiJu1ZuoDangqian4++;
                    }
                    if (ZhiJu1ZuoBupin5 != "")
                    {
                        ZhiJu1ZuoDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,2,A":
                    if (ZhiJu1YouBupin1 != "")
                    {
                        ZhiJu1YouDangqian1++;
                    }
                    if (ZhiJu1YouBupin2 != "")
                    {
                        ZhiJu1YouDangqian2++;
                    }
                    if (ZhiJu1YouBupin3 != "")
                    {
                        ZhiJu1YouDangqian3++;
                    }
                    if (ZhiJu1YouBupin4 != "")
                    {
                        ZhiJu1YouDangqian4++;
                    }
                    if (ZhiJu1YouBupin5 != "")
                    {
                        ZhiJu1YouDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,2,B":
                    if (ZhiJu1YouBupin1 != "")
                    {
                        ZhiJu1YouDangqian1++;
                    }
                    if (ZhiJu1YouBupin2 != "")
                    {
                        ZhiJu1YouDangqian2++;
                    }
                    if (ZhiJu1YouBupin3 != "")
                    {
                        ZhiJu1YouDangqian3++;
                    }
                    if (ZhiJu1YouBupin4 != "")
                    {
                        ZhiJu1YouDangqian4++;
                    }
                    if (ZhiJu1YouBupin5 != "")
                    {
                        ZhiJu1YouDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,3,A":
                    if (ZhiJu2ZuoBupin1 != "")
                    {
                        ZhiJu2ZuoDangqian1++;
                    }
                    if (ZhiJu2ZuoBupin2 != "")
                    {
                        ZhiJu2ZuoDangqian2++;
                    }
                    if (ZhiJu2ZuoBupin3 != "")
                    {
                        ZhiJu2ZuoDangqian3++;
                    }
                    if (ZhiJu2ZuoBupin4 != "")
                    {
                        ZhiJu2ZuoDangqian4++;
                    }
                    if (ZhiJu2ZuoBupin5 != "")
                    {
                        ZhiJu2ZuoDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,3,B":
                    if (ZhiJu2ZuoBupin1 != "")
                    {
                        ZhiJu2ZuoDangqian1++;
                    }
                    if (ZhiJu2ZuoBupin2 != "")
                    {
                        ZhiJu2ZuoDangqian2++;
                    }
                    if (ZhiJu2ZuoBupin3 != "")
                    {
                        ZhiJu2ZuoDangqian3++;
                    }
                    if (ZhiJu2ZuoBupin4 != "")
                    {
                        ZhiJu2ZuoDangqian4++;
                    }
                    if (ZhiJu2ZuoBupin5 != "")
                    {
                        ZhiJu2ZuoDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,4,A":

                    if (ZhiJu2YouBupin1 != "")
                    {
                        ZhiJu2YouDangqian1++;
                    }
                    if (ZhiJu2YouBupin2 != "")
                    {
                        ZhiJu2YouDangqian2++;
                    }
                    if (ZhiJu2YouBupin3 != "")
                    {
                        ZhiJu2YouDangqian3++;
                    }
                    if (ZhiJu2YouBupin4 != "")
                    {
                        ZhiJu2YouDangqian4++;
                    }
                    if (ZhiJu2YouBupin5 != "")
                    {
                        ZhiJu2YouDangqian5++;
                    }
                    break;
                case "TestRevFlex: Start,4,B":
                    if (ZhiJu2YouBupin1 != "")
                    {
                        ZhiJu2YouDangqian1++;
                    }
                    if (ZhiJu2YouBupin2 != "")
                    {
                        ZhiJu2YouDangqian2++;
                    }
                    if (ZhiJu2YouBupin3 != "")
                    {
                        ZhiJu2YouDangqian3++;
                    }
                    if (ZhiJu2YouBupin4 != "")
                    {
                        ZhiJu2YouDangqian4++;
                    }
                    if (ZhiJu2YouBupin5 != "")
                    {
                        ZhiJu2YouDangqian5++;
                    }
                    break;
                default:
                    break;
            }
        }
        private void EpsonStatusUpdateProcess(string str)
        {
            EpsonStatusAuto = str[2] == '1';
            EpsonStatusWarning = str[3] == '1';
            EpsonStatusSError = str[4] == '1';
            EpsonStatusSafeGuard = str[5] == '1';
            EpsonStatusEStop = str[6] == '1';
            EpsonStatusError = str[7] == '1';
            EpsonStatusPaused = str[8] == '1';
            EpsonStatusRunning = str[9] == '1';
            EpsonStatusReady = str[10] == '1';
        }
        private void ScanUpdateProcess(string bar, HImage img)
        {
            hImageScan = img;
            BarcodeDisplay = bar;
        }
        private void ScanP3UpdateProcess(string bar, HImage img, HObject hObject)
        {
            //ObservableCollection<HObject> objectList = new ObservableCollection<HObject>();
            hImageScan = img;
            BarcodeDisplay = bar;
            //objectList.Add(hObject);
            //hObjectListScan = objectList;
        }
        private void ScanP3Update1Process(string bar)
        {
            BarcodeDisplay = bar;
            if (bar != "Error")
            {
                QuiLiaoBarcode barc = new QuiLiaoBarcode();
                barc.条码 = bar;
                QueLiaoWorkList.Add(barc);
            }
            SaveScanBarcodetoCSV(bar);
        }
        
        private void StartUpdateProcess(int index)
        {
            TestRecord tr = new TestRecord(DateTime.Now.ToString(), epsonRC90.sIMTester[index / 4].TesterBracode[index % 4], epsonRC90.sIMTester[index / 4].testResult[index % 4].ToString(), epsonRC90.sIMTester[index / 4].TestSpan[index % 4].ToString() + " s", (index + 1).ToString());
            lock (this)
            {
                myTestRecordQueue.Enqueue(tr);
            }
            //testRecord.Add(tr);
            SaveCSVfileRecord(tr);
            Msg = messagePrint.AddMessage("测试机 " + (index + 1).ToString() + " 测试完成");
        }
        private async void EPSONDBSearchEventProcess(string pickstr)
        {
            try
            {
                string NgItem = "Error";
                switch (pickstr)
                {
                    case "A":
                        Barsaminfo_Barcode = epsonRC90.PickBracodeA_1;
                        DBSearch_Barcode = epsonRC90.PickBracodeA_1;
                        if (LookforDt(DBSearch_Barcode, 0))
                        {
                            //NgItem = (string)SinglDt.Rows[0]["NGITEM"];
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem1)
                            {
                                NgItem = "OK";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem2)
                            {
                                NgItem = "NG";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem3)
                            {
                                NgItem = "NG1";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem4)
                            {
                                NgItem = "NG2";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem5)
                            {
                                NgItem = "NG3";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem6)
                            {
                                NgItem = "NG4";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem7)
                            {
                                NgItem = "NG5";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem8)
                            {
                                NgItem = "NG6";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem9)
                            {
                                NgItem = "NG7";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem10)
                            {
                                NgItem = "NG8";
                            }
                            //switch ((string)SinglDt.Rows[0]["NGITEM"])
                            //{
                            //    case "PASS":
                            //        NgItem = "OK";
                            //        break;
                            //    case "X758FlexOpened":
                            //        NgItem = "NG";
                            //        break;
                            //    case "PixelOpenShortTest_OOS":
                            //        NgItem = "NG1";
                            //        break;
                            //    case "PowerTest_OOS":
                            //        NgItem = "NG2";
                            //        break;
                            //    case "NG3":
                            //        NgItem = "NG3";
                            //        break;
                            //    case "NG4":
                            //        NgItem = "NG4";
                            //        break;
                            //    case "NG5":
                            //        NgItem = "NG5";
                            //        break;
                            //    case "NG6":
                            //        NgItem = "NG6";
                            //        break;
                            //    case "NG7":
                            //        NgItem = "NG7";
                            //        break;
                            //    case "NG8":
                            //        NgItem = "NG8";
                            //        break;
                            //    default:
                            //        NgItem = "Error";
                            //        break;
                            //}
                            if (epsonRC90.TestSendStatus)
                            {
                                await epsonRC90.TestSentNet.SendAsync("SamDBSearch;A;" + NgItem);
                            }

                        }
                        else
                        {
                            NgItem = "Error";
                            if (epsonRC90.TestSendStatus)
                            {
                                await epsonRC90.TestSentNet.SendAsync("SamDBSearch;A;" + NgItem);
                            }
                            //bool r = await mydialog.showconfirm("样本数据库查询 失败。是否录入样本");
                            //SampleAlarm_IsNeedCheckin = true;
                            //await WaitSampleAlarmIsNeedCheckinProcess();
                            //if (NeedCheckin)
                            //{
                            //    //等待录入操作
                            //    bool rr = await WaitCheckinProcess();
                            //    if (rr)
                            //    {
                            //        NgItem = SamNgItemsTableNames[SamNgItemsTableIndex];
                            //        if (epsonRC90.TestSendStatus)
                            //        {
                            //            await epsonRC90.TestSentNet.SendAsync("SamDBSearch;A;" + NgItem);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        NgItem = "Error";
                            //        if (epsonRC90.TestSendStatus)
                            //        {
                            //            await epsonRC90.TestSentNet.SendAsync("SamDBSearch;A;" + NgItem);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    NgItem = "Error";
                            //    if (epsonRC90.TestSendStatus)
                            //    {
                            //        await epsonRC90.TestSentNet.SendAsync("SamDBSearch;A;" + NgItem);
                            //    }
                            //}
                        }
                        break;
                    case "B":
                        Barsaminfo_Barcode = epsonRC90.PickBracodeB_1;
                        DBSearch_Barcode = epsonRC90.PickBracodeB_1;
                        if (LookforDt(DBSearch_Barcode, 0))
                        {
                            //NgItem = (string)SinglDt.Rows[0]["NGITEM"];
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem1)
                            {
                                NgItem = "OK";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem2)
                            {
                                NgItem = "NG";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem3)
                            {
                                NgItem = "NG1";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem4)
                            {
                                NgItem = "NG2";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem5)
                            {
                                NgItem = "NG3";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem6)
                            {
                                NgItem = "NG4";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem7)
                            {
                                NgItem = "NG5";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem8)
                            {
                                NgItem = "NG6";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem9)
                            {
                                NgItem = "NG7";
                            }
                            if ((string)SinglDt.Rows[0]["NGITEM"] == SampleNgitem10)
                            {
                                NgItem = "NG8";
                            }
                            //switch ((string)SinglDt.Rows[0]["NGITEM"])
                            //{
                            //    case "PASS":
                            //        NgItem = "OK";
                            //        break;
                            //    case "X758FlexOpened":
                            //        NgItem = "NG";
                            //        break;
                            //    case "PixelOpenShortTest_OOS":
                            //        NgItem = "NG1";
                            //        break;
                            //    case "PowerTest_OOS":
                            //        NgItem = "NG2";                             
                            //        break;
                            //    case "NG3":
                            //        NgItem = "NG3";
                            //        break;
                            //    case "NG4":
                            //        NgItem = "NG4";
                            //        break;
                            //    case "NG5":
                            //        NgItem = "NG5";
                            //        break;
                            //    case "NG6":
                            //        NgItem = "NG6";
                            //        break;
                            //    case "NG7":
                            //        NgItem = "NG7";
                            //        break;
                            //    case "NG8":
                            //        NgItem = "NG8";
                            //        break;
                            //    default:
                            //        NgItem = "Error";
                            //        break;
                            //}
                            if (epsonRC90.TestSendStatus)
                            {
                                await epsonRC90.TestSentNet.SendAsync("SamDBSearch;B;" + NgItem);
                            }

                        }
                        else
                        {
                            NgItem = "Error";
                            if (epsonRC90.TestSendStatus)
                            {
                                await epsonRC90.TestSentNet.SendAsync("SamDBSearch;B;" + NgItem);
                            }
                            //bool r = await mydialog.showconfirm("样本数据库查询 失败。是否录入样本");
                            //SampleAlarm_IsNeedCheckin = true;
                            //await WaitSampleAlarmIsNeedCheckinProcess();
                            //if (NeedCheckin)
                            //{
                            //    //等待录入操作
                            //    bool rr = await WaitCheckinProcess();
                            //    if (rr)
                            //    {
                            //        NgItem = SamNgItemsTableNames[SamNgItemsTableIndex];
                            //        if (epsonRC90.TestSendStatus)
                            //        {
                            //            await epsonRC90.TestSentNet.SendAsync("SamDBSearch;B;" + NgItem);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        NgItem = "Error";
                            //        if (epsonRC90.TestSendStatus)
                            //        {
                            //            await epsonRC90.TestSentNet.SendAsync("SamDBSearch;B;" + NgItem);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    NgItem = "Error";
                            //    if (epsonRC90.TestSendStatus)
                            //    {
                            //        await epsonRC90.TestSentNet.SendAsync("SamDBSearch;B;" + NgItem);
                            //    }
                            //}
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Default.Error("EPSONDBSearchEventProcess", ex.Message);
            }

        }
        public void SaveSampleResultManual()
        {
            //保存样本数据到本地
            SaveSampleRecordLocal("Manual");
        }
        #endregion
        #region 视觉
        #region Halcon
        public void cameraHcInit()
        {
            string filename = System.IO.Path.GetFileName(HcVisionScriptFileName);
            string fullfilename = System.Environment.CurrentDirectory + @"\" + filename;
            if (!(File.Exists(fullfilename)))
            {
                File.Copy(HcVisionScriptFileName, fullfilename);
            }
            else
            {
                FileInfo fileinfo1 = new FileInfo(HcVisionScriptFileName);
                FileInfo fileinfo2 = new FileInfo(fullfilename);
                TimeSpan ts = fileinfo1.LastWriteTime - fileinfo2.LastWriteTime;
                if (ts.TotalMilliseconds > 0)
                {
                    File.Copy(HcVisionScriptFileName, fullfilename, true);
                }
            }
            hdevEngine.initialengine(System.IO.Path.GetFileNameWithoutExtension(fullfilename));
            hdevEngine.loadengine();
            try
            {
                if (!Directory.Exists(@"E:\images"))
                {
                    Directory.CreateDirectory(@"E:\images");
                }
                string[] imagefilenames = Directory.GetFiles(@"E:\images");
                if (imagefilenames.Length >= 200)
                {
                    for (int i = 0; i < imagefilenames.Length; i++)
                    {
                        File.Delete(imagefilenames[i]);
                    }
                    Msg = messagePrint.AddMessage("清理照片");
                }
            }
            catch (Exception ex)
            {

                Log.Default.Error(@"CreateDirectory E:\images", ex.Message);
            }

        }
        public void CameraHcInspect()
        {
            Async.RunFuncAsync(cameraHcInspect, null);
        }
        public void cameraHcInspect()
        {
            try
            {
                ObservableCollection<HObject> objectList = new ObservableCollection<HObject>();
                //FindFill1 = FindFill2 = FindFill3 = FindFill4 = FindFill5 = FindFill6 = FindFill7 = FindFill8 = false;
                hdevEngine.inspectengine();
                hImage = hdevEngine.getImage("Image");
                var fill1 = hdevEngine.getmeasurements("Fill");
                for (int i = 0; i < 80; i++)
                {
                    _fill[i] = fill1.IArr[i] == 0;
                }
                //FindFill1 = fill1.ToString() == "1";
                //FindFill2 = fill2.ToString() == "1";
                //FindFill3 = fill3.ToString() == "1";
                //FindFill4 = fill4.ToString() == "1";
                //FindFill5 = fill5.ToString() == "1";
                //FindFill6 = fill6.ToString() == "1";
                //FindFill7 = fill7.ToString() == "1";
                //FindFill8 = fill8.ToString() == "1";
                objectList.Add(hdevEngine.getRegion("RegionUnion"));
                hObjectList = objectList;
            }
            catch 
            { }
            
        }

        #endregion
        #region Scan
        //public void scanCameraInit()
        //{
        //    string filename = System.IO.Path.GetFileName(ScanVisionScriptFileName);
        //    string fullfilename = System.Environment.CurrentDirectory + @"\" + filename;
        //    if (!(File.Exists(fullfilename)))
        //    {
        //        File.Copy(ScanVisionScriptFileName, fullfilename);
        //    }
        //    else
        //    {
        //        FileInfo fileinfo1 = new FileInfo(ScanVisionScriptFileName);
        //        FileInfo fileinfo2 = new FileInfo(fullfilename);
        //        TimeSpan ts = fileinfo1.LastWriteTime - fileinfo2.LastWriteTime;
        //        if (ts.TotalMilliseconds > 0)
        //        {
        //            File.Copy(ScanVisionScriptFileName, fullfilename, true);
        //        }
        //    }
        //    hdevScanEngine.initialengine(System.IO.Path.GetFileNameWithoutExtension(fullfilename));
        //    hdevScanEngine.loadengine();
        //}
        //public void ScanCameraInspect()
        //{
        //    Async.RunFuncAsync(epsonRC90.scanCameraInspect, null);
        //}
        //public void scanCameraInspect()
        //{
        //    hdevScanEngine.inspectengine();
        //    hImageScan = hdevScanEngine.getImage("Image");
        //    var aa = hdevScanEngine.getmeasurements("DecodedDataStrings");
        //    BarcodeDisplay = aa.ToString();
        //}

        #endregion
        #endregion
        #region 读写操作
        private bool ReadParameter()
        {
            try
            {
                LastSampleTestFinishTime = Inifile.INIGetStringValue(iniParameterPath, "System", "LastSampleTestFinishTime", "2018/1/31 11:25:28");
                SampleTestTimeSpan = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "System", "SampleTestTimeSpan", "6"));
                LastCleanAlarmDatetime = Inifile.INIGetStringValue(iniParameterPath, "LastCleanAlarm", "LastCleanAlarmDatetime", "2018年1月17日Night");
                //isDiaoLiaoStopFlag = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "DiaoLiao", "isDiaoLiaoStopFlag", "False"));
                isDiaoLiaoStopFlag = false;
                LiaoCountIN = uint.Parse(Inifile.INIGetStringValue(iniParameterPath, "DiaoLiao", "LiaoCountIN", "0"));
                LiaoCountOut = uint.Parse(Inifile.INIGetStringValue(iniParameterPath, "DiaoLiao", "LiaoCountOut", "0"));
                LiaoDelta = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "DiaoLiao", "LiaoDelta", "0"));
                Downtime = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Downtime", "0"));
                DowntimeDisp = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "DowntimeDisp", "0"));
                Jigdowntime = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Jigdowntime", "0"));
                JigdowntimeDisp = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "JigdowntimeDisp", "0"));
                runtime = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "runtime", "0"));
                totaltime = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "totaltime", "0"));
                Waitforinput = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Waitforinput", "0"));
                WaitforinputDisp = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "WaitforinputDisp", "0"));
                Waitfortray = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Waitfortray", "0"));
                WaitfortrayDisp = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "WaitfortrayDisp", "0"));
                Waitfortake = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Waitfortake", "0"));
                WaitfortakeDisp = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Alarm", "WaitfortakeDisp", "0"));

                //ZhiJu1ZuoBupin1 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin1", "");
                //ZhiJu1ZuoBupin2 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin2", "");
                //ZhiJu1ZuoBupin3 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin3", "");
                //ZhiJu1ZuoBupin4 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin4", "");
                //ZhiJu1ZuoBupin5 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin5", "");

                //ZhiJu1ZuoDangqian1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian1", "0"));
                //ZhiJu1ZuoDangqian2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian2", "0"));
                //ZhiJu1ZuoDangqian3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian3", "0"));
                //ZhiJu1ZuoDangqian4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian4", "0"));
                //ZhiJu1ZuoDangqian5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian5", "0"));

                //ZhiJu1ZuoShouMing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing1", "0"));
                //ZhiJu1ZuoShouMing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing2", "0"));
                //ZhiJu1ZuoShouMing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing3", "0"));
                //ZhiJu1ZuoShouMing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing4", "0"));
                //ZhiJu1ZuoShouMing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing5", "0"));

                //ZhiJu1ZuoYujing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing1", "0"));
                //ZhiJu1ZuoYujing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing2", "0"));
                //ZhiJu1ZuoYujing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing3", "0"));
                //ZhiJu1ZuoYujing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing4", "0"));
                //ZhiJu1ZuoYujing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing5", "0"));

                //ZhiJu1YouBupin1 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin1", "");
                //ZhiJu1YouBupin2 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin2", "");
                //ZhiJu1YouBupin3 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin3", "");
                //ZhiJu1YouBupin4 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin4", "");
                //ZhiJu1YouBupin5 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin5", "");

                //ZhiJu1YouDangqian1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian1", "0"));
                //ZhiJu1YouDangqian2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian2", "0"));
                //ZhiJu1YouDangqian3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian3", "0"));
                //ZhiJu1YouDangqian4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian4", "0"));
                //ZhiJu1YouDangqian5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian5", "0"));

                //ZhiJu1YouShouMing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing1", "0"));
                //ZhiJu1YouShouMing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing2", "0"));
                //ZhiJu1YouShouMing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing3", "0"));
                //ZhiJu1YouShouMing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing4", "0"));
                //ZhiJu1YouShouMing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing5", "0"));

                //ZhiJu1YouYujing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing1", "0"));
                //ZhiJu1YouYujing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing2", "0"));
                //ZhiJu1YouYujing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing3", "0"));
                //ZhiJu1YouYujing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing4", "0"));
                //ZhiJu1YouYujing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing5", "0"));

                //ZhiJu2ZuoBupin1 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin1", "");
                //ZhiJu2ZuoBupin2 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin2", "");
                //ZhiJu2ZuoBupin3 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin3", "");
                //ZhiJu2ZuoBupin4 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin4", "");
                //ZhiJu2ZuoBupin5 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin5", "");

                //ZhiJu2ZuoDangqian1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian1", "0"));
                //ZhiJu2ZuoDangqian2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian2", "0"));
                //ZhiJu2ZuoDangqian3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian3", "0"));
                //ZhiJu2ZuoDangqian4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian4", "0"));
                //ZhiJu2ZuoDangqian5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian5", "0"));

                //ZhiJu2ZuoShouMing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing1", "0"));
                //ZhiJu2ZuoShouMing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing2", "0"));
                //ZhiJu2ZuoShouMing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing3", "0"));
                //ZhiJu2ZuoShouMing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing4", "0"));
                //ZhiJu2ZuoShouMing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing5", "0"));

                //ZhiJu2ZuoYujing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing1", "0"));
                //ZhiJu2ZuoYujing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing2", "0"));
                //ZhiJu2ZuoYujing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing3", "0"));
                //ZhiJu2ZuoYujing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing4", "0"));
                //ZhiJu2ZuoYujing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing5", "0"));

                //ZhiJu2YouBupin1 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin1", "");
                //ZhiJu2YouBupin2 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin2", "");
                //ZhiJu2YouBupin3 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin3", "");
                //ZhiJu2YouBupin4 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin4", "");
                //ZhiJu2YouBupin5 = Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin5", "");

                //ZhiJu2YouDangqian1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian1", "0"));
                //ZhiJu2YouDangqian2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian2", "0"));
                //ZhiJu2YouDangqian3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian3", "0"));
                //ZhiJu2YouDangqian4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian4", "0"));
                //ZhiJu2YouDangqian5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian5", "0"));

                //ZhiJu2YouShouMing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing1", "0"));
                //ZhiJu2YouShouMing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing2", "0"));
                //ZhiJu2YouShouMing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing3", "0"));
                //ZhiJu2YouShouMing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing4", "0"));
                //ZhiJu2YouShouMing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing5", "0"));

                //ZhiJu2YouYujing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing1", "0"));
                //ZhiJu2YouYujing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing2", "0"));
                //ZhiJu2YouYujing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing3", "0"));
                //ZhiJu2YouYujing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing4", "0"));
                //ZhiJu2YouYujing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing5", "0"));

                //JiTaiDangqian1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian1", "0"));
                //JiTaiDangqian2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian2", "0"));
                //JiTaiDangqian3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian3", "0"));
                //JiTaiDangqian4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian4", "0"));
                //JiTaiDangqian5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian5", "0"));
                //JiTaiDangqian6 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiDangqian6", "0"));

                //JiTaiShouMing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing1", "0"));
                //JiTaiShouMing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing2", "0"));
                //JiTaiShouMing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing3", "0"));
                //JiTaiShouMing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing4", "0"));
                //JiTaiShouMing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing5", "0"));
                //JiTaiShouMing6 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiShouMing6", "0"));

                //JiTaiYujing1 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing1", "0"));
                //JiTaiYujing2 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing2", "0"));
                //JiTaiYujing3 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing3", "0"));
                //JiTaiYujing4 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing4", "0"));
                //JiTaiYujing5 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing5", "0"));
                //JiTaiYujing6 = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "HaoCai", "JiTaiYujing6", "0"));

                SerialPortCom = Inifile.INIGetStringValue(iniParameterPath, "SerialPort", "Com", "COM1");
                EpsonIp = Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonIp", "192.168.1.2");
                EpsonTestSendPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestSendPort", "2000"));
                EpsonTestSendFlexPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestSendFlexPort", "2004"));
                EpsonTestReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestReceivePort", "2001"));
                EpsonTestReceiveFlexPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonTestReceiveFlexPort", "2005"));
                EpsonMsgReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonMsgReceivePort", "2002"));
                EpsonIOReceivePort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonIOReceivePort", "2007"));
                EpsonRemoteControlPort = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Epson", "EpsonRemoteControlPort", "5000"));
                VisionScriptFileName = Inifile.INIGetStringValue(iniParameterPath, "Camera", "VisionScriptFileName", @"C:\test.vbai");
                HcVisionScriptFileName = Inifile.INIGetStringValue(iniParameterPath, "Camera", "HcVisionScriptFileName", @"C:\test.hdev");
                ScanVisionScriptFileName = Inifile.INIGetStringValue(iniParameterPath, "Camera", "ScanVisionScriptFileName", @"C:\test.hdev");
                ScanVisionScriptFileNameP3 = Inifile.INIGetStringValue(iniParameterPath, "Camera", "ScanVisionScriptFileNameP3", @"C:\test.hdev");
                TestPcIPA = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcIPA", "192.168.1.101");
                TestPcIPB = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcIPB", "192.168.1.102");
                TestPcRemotePortA = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcRemotePortA", "8000"));
                TestPcRemotePortB = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcRemotePortB", "8000"));
                TestPcPathA = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcPathA", "/Users/zdt/Desktop/UIExplore_1.2.17_Flex.app");
                TestPcPathB = Inifile.INIGetStringValue(iniParameterPath, "Mac", "TestPcPathB", "/Users/zdt/Desktop/UIExplore_1.2.17_Flex.app");
                TestCheckedAL = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedAL", "True"));
                TestCheckedAR = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedAR", "True"));
                TestCheckedBL = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedBL", "True"));
                TestCheckedBR = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "TestCheckedBR", "True"));
                
                TestRecordSavePath = Inifile.INIGetStringValue(iniParameterPath, "SavePath", "TestRecordSavePath", "C:\\");
                AlarmSavePath = Inifile.INIGetStringValue(iniParameterPath, "SavePath", "AlarmSavePath", "C:\\");
                //NGContinueNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Tester", "NGContinueNum", "4"));
                NGContinueNum = 3;

                NGOverlayNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "NGOverlay", "NGOverlayNum", "4"));
                BarcodeItemNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "BarcodeItem", "BarcodeItemNum", "3"));
                BarcodeMode = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "BarcodeMode", "BarcodeMode", "True"));
                //AABReTest = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "ReTest", "AABReTest", "False"));
                AABReTest = false;

                //IsTestersClean = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "IsTestersClean", "False"));
                IsTestersClean = false;
                IsTestersSample = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "IsTestersSample", "False"));
                //IsTestersSample = false;
                //Inifile.INIWriteValue(iniParameterPath, "CheckScan", "isScanCheckFlag", isScanCheckFlag.ToString());
                //isScanCheckFlag = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "CheckScan", "isScanCheckFlag", "False"));
                isScanCheckFlag = false;
                //IsReleaseFailContinue = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "ReleaseFail", "IsReleaseFailContinue", "False"));
                IsReleaseFailContinue = true;
                lastchuiqi.wDay = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wDay", "13"));
                lastchuiqi.wDayOfWeek = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wDayOfWeek", "0"));
                lastchuiqi.wHour = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wHour", "17"));
                lastchuiqi.wMilliseconds = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wMilliseconds", "273"));
                lastchuiqi.wMinute = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wMinute", "5"));
                lastchuiqi.wMonth = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wMonth", "11"));
                lastchuiqi.wSecond = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wSecond", "55"));
                lastchuiqi.wYear = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wYear", "2016"));
                LastChuiqiTimeStr = lastchuiqi.ToDateTime().ToString();

                lastSample.wDay = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wDay", "13"));
                lastSample.wDayOfWeek = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wDayOfWeek", "0"));
                lastSample.wHour = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wHour", "17"));
                lastSample.wMilliseconds = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Chuiqi", "wMilliseconds", "273"));
                lastSample.wMinute = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wMinute", "5"));
                lastSample.wMonth = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wMonth", "11"));
                lastSample.wSecond = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wSecond", "55"));
                lastSample.wYear = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "wYear", "2016"));
                LastSampleTestTimeStr = lastSample.ToDateTime().ToString();

                SQL_ora_server = Inifile.INIGetStringValue(iniParameterPath, "Oracle", "Server", "zdtdb");
                SQL_ora_user = Inifile.INIGetStringValue(iniParameterPath, "Oracle", "User", "ictdata");
                SQL_ora_pwd = Inifile.INIGetStringValue(iniParameterPath, "Oracle", "Passwold", "ictdata*168");

                SampleHave1 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave1", "False"));
                SampleHave2 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave2", "False"));
                SampleHave3 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave3", "False"));
                SampleHave4 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave4", "False"));
                SampleHave5 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave5", "False"));
                SampleHave6 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave6", "False"));
                SampleHave7 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave7", "False"));
                SampleHave8 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave8", "False"));
                SampleHave9 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave9", "False"));
                SampleHave10 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave10", "False"));
                SampleHave11 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave11", "False"));
                SampleHave12 = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleHave12", "False"));

                Barsaminfo_Partnum = Barsamrec_Partnum = Inifile.INIGetStringValue(iniParameterPath, "Sample", "PARTNUM", "CA9");
                Barsamrec_Mno = Inifile.INIGetStringValue(iniParameterPath, "Sample", "MNO", "L1");
                Barsamrec_ID1 = Inifile.INIGetStringValue(iniParameterPath, "Sample", "MNO1", "764099");
                Barsamrec_ID2 = Inifile.INIGetStringValue(iniParameterPath, "Sample", "MNO2", "764099");
                Barsamrec_ID3 = Inifile.INIGetStringValue(iniParameterPath, "Sample", "MNO3", "764099");
                Barsamrec_ID4 = Inifile.INIGetStringValue(iniParameterPath, "Sample", "MNO4", "764099");

                SampleTimeElapse = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleTimeElapse", "2"));
                //SampleNgitemsNum
                SampleNgitemsNum = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "SampleNgitemsNum", "2"));

                LastSampleHour = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "Sample", "LastSampleHour", "-1"));

                PcsGrrNeedNum = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "GRR", "PcsGrrNeedNum", "4"));
                PcsGrrNeedCount = ushort.Parse(Inifile.INIGetStringValue(iniParameterPath, "GRR", "PcsGrrNeedCount", "4"));
                //SampleNgitem1
                SampleNgitem1 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem1", "PASS");
                SampleNgitem2 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem2", "X758FlexOpened");
                SampleNgitem3 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem3", "PixelOpenShortTest_OOS");
                SampleNgitem4 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem4", "PowerTest_OOS");
                SampleNgitem5 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem5", "NG3");
                SampleNgitem6 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem6", "NG4");
                SampleNgitem7 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem7", "NG5");
                SampleNgitem8 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem8", "NG6");
                SampleNgitem9 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem9", "NG7");
                SampleNgitem10 = Inifile.INIGetStringValue(iniParameterPath, "SampleNgitems", "SampleNgitem10", "NG8");

                //PassMid = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassMid", "98"));
                PassMid = 98;
                //PassLowLimit = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassLowLimit", "94"));
                PassLowLimit = 95;
                //PassLowLimitStop = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassLowLimitStop", "85"));
                PassLowLimitStop = 95;
                //PassLowLimitStopNum = int.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "PassLowLimitStopNum", "100"));
                PassLowLimitStopNum = 100;
                //IsPassLowLimitStop = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "PassYield", "IsPassLowLimitStop", "False"));
                IsPassLowLimitStop = true;

                //FlexTestTimeout = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "FlexTest", "FlexTestTimeout", "100"));
                FlexTestTimeout = 100;
                FlexTestNomalTime = double.Parse(Inifile.INIGetStringValue(iniParameterPath, "FlexTest", "FlexTestNomalTime", "50"));
                //IsCheckUploadStatus = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "Upload", "IsCheckUploadStatus", "False"));
                //IsCheckINI = bool.Parse(Inifile.INIGetStringValue(iniParameterPath, "CheckINI", "IsCheckINI", "False"));
                IsCheckUploadStatus = false;
                IsCheckINI = true;
                //IsCheckUploadStatus = true;
                //var adminstr = Inifile.INIGetStringValue(iniAdminControl, "Admin", "AdminControl", "False");
                //if (adminstr == "True" || adminstr == "False")
                //{
                //    AdminControl = bool.Parse(adminstr);
                //}
                AdminControl = true;
                waitforinput = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Summary", "waitforinput", "0"));
                inputtimes = int.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Summary", "inputtimes", "0"));
                downtime = double.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Summary", "downtime", "0"));

                run_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "run_min", "0"));
                work_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "work_min", "0"));
                waittake_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "waittake_min", "0"));
                waittray_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "waittray_min", "0"));
                waitinput_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "waitinput_min", "0"));
                jigdown_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "jigdown_min", "0"));
                down_min = double.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "down_min", "0"));
                DangbanFirstProduct = Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "DangbanFirstProduct", "null");

                liaoinput = uint.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "liaoinput", "0"));
                liaooutput = uint.Parse(Inifile.INIGetStringValue(iniTimeCalcPath, "Summary", "liaooutput", "0"));

                UPH = uint.Parse(Inifile.INIGetStringValue(iniParameterPath, "System", "UPH", "250"));
                return true;
            }
            catch (Exception ex)
            {
                //Log.Default.Error("ReadParameter", ex);
                System.Windows.MessageBox.Show(ex.Message, "ReadParameter");
                return false;
            }
        }
        private bool WriteParameter()
        {
            try
            {

                //Inifile.INIWriteValue(iniParameterPath, "System", "LastSampleTestFinishTime", LastSampleTestFinishTime);
                Inifile.INIWriteValue(iniParameterPath, "System", "SampleTestTimeSpan", SampleTestTimeSpan.ToString());
                Inifile.INIWriteValue(iniParameterPath, "DiaoLiao", "isDiaoLiaoStopFlag", isDiaoLiaoStopFlag.ToString());
                Inifile.INIWriteValue(iniParameterPath, "SerialPort", "Com", SerialPortCom);
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonIp", EpsonIp);
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonTestSendPort", EpsonTestSendPort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonTestSendFlexPort", EpsonTestSendFlexPort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonTestReceivePort", EpsonTestReceivePort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonTestReceiveFlexPort", EpsonTestReceiveFlexPort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonMsgReceivePort", EpsonMsgReceivePort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonIOReceivePort", EpsonIOReceivePort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Epson", "EpsonRemoteControlPort", EpsonRemoteControlPort.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcIPA", TestPcIPA);
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcIPB", TestPcIPB);
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcRemotePortA", TestPcRemotePortA.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcRemotePortB", TestPcRemotePortB.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcPathA", TestPcPathA);
                Inifile.INIWriteValue(iniParameterPath, "Mac", "TestPcPathB", TestPcPathB);
                Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedAL", TestCheckedAL.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedAR", TestCheckedAR.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedBL", TestCheckedBL.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Tester", "TestCheckedBR", TestCheckedBR.ToString());

                //NGContinueNum NGOverlayNum
                Inifile.INIWriteValue(iniParameterPath, "Tester", "NGContinueNum", NGContinueNum.ToString());
                Inifile.INIWriteValue(iniParameterPath, "NGOverlay", "NGOverlayNum", NGOverlayNum.ToString());
                Inifile.INIWriteValue(iniParameterPath, "BarcodeItem", "BarcodeItemNum", BarcodeItemNum.ToString());
                //Inifile.INIWriteValue(iniParameterPath, "Barcode", "PickBracodeA", PickBracodeA);
                //Inifile.INIWriteValue(iniParameterPath, "Barcode", "TesterBracodeAL", TesterBracodeAL);
                //Inifile.INIWriteValue(iniParameterPath, "Barcode", "TesterBracodeAR", TesterBracodeAR);
                //Inifile.INIWriteValue(iniParameterPath, "Barcode", "TesterBracodeBL", TesterBracodeBL);
                //Inifile.INIWriteValue(iniParameterPath, "Barcode", "TesterBracodeBR", TesterBracodeBR);
                Inifile.INIWriteValue(iniParameterPath, "BarcodeMode", "BarcodeMode", BarcodeMode.ToString());
                Inifile.INIWriteValue(iniParameterPath, "ReTest", "AABReTest", AABReTest.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Chuiqi", "IsTestersClean", IsTestersClean.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Sample", "IsTestersSample", IsTestersSample.ToString());
                //IsReleaseFailContinue
                Inifile.INIWriteValue(iniParameterPath, "ReleaseFail", "IsReleaseFailContinue", IsReleaseFailContinue.ToString());
                Inifile.INIWriteValue(iniParameterPath, "CheckScan", "isScanCheckFlag", isScanCheckFlag.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Oracle", "Server", SQL_ora_server);
                Inifile.INIWriteValue(iniParameterPath, "Oracle", "User", SQL_ora_user);
                Inifile.INIWriteValue(iniParameterPath, "Oracle", "Passwold", SQL_ora_pwd);

                Inifile.INIWriteValue(iniParameterPath, "Sample", "PARTNUM", Barsamrec_Partnum);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "MNO", Barsamrec_Mno);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "MNO1", Barsamrec_ID1);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "MNO2", Barsamrec_ID2);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "MNO3", Barsamrec_ID3);
                Inifile.INIWriteValue(iniParameterPath, "Sample", "MNO4", Barsamrec_ID4);

                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleTimeElapse", SampleTimeElapse.ToString());

                Inifile.INIWriteValue(iniParameterPath, "Sample", "SampleNgitemsNum", SampleNgitemsNum.ToString());
                Inifile.INIWriteValue(iniParameterPath, "GRR", "PcsGrrNeedNum", PcsGrrNeedNum.ToString());
                Inifile.INIWriteValue(iniParameterPath, "GRR", "PcsGrrNeedCount", PcsGrrNeedCount.ToString());
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem1", SampleNgitem1);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem2", SampleNgitem2);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem3", SampleNgitem3);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem4", SampleNgitem4);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem5", SampleNgitem5);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem6", SampleNgitem6);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem7", SampleNgitem7);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem8", SampleNgitem8);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem9", SampleNgitem9);
                Inifile.INIWriteValue(iniParameterPath, "SampleNgitems", "SampleNgitem10", SampleNgitem10);

                Inifile.INIWriteValue(iniParameterPath, "PassYield", "PassMid", PassMid.ToString());
                Inifile.INIWriteValue(iniParameterPath, "PassYield", "PassLowLimit", PassLowLimit.ToString());
                Inifile.INIWriteValue(iniParameterPath, "PassYield", "PassLowLimitStop", PassLowLimitStop.ToString());
                Inifile.INIWriteValue(iniParameterPath, "PassYield", "PassLowLimitStopNum", PassLowLimitStopNum.ToString());
                Inifile.INIWriteValue(iniParameterPath, "PassYield", "IsPassLowLimitStop", IsPassLowLimitStop.ToString());
                Inifile.INIWriteValue(iniParameterPath, "FlexTest", "FlexTestTimeout", FlexTestTimeout.ToString());
                Inifile.INIWriteValue(iniParameterPath, "FlexTest", "FlexTestNomalTime", FlexTestNomalTime.ToString());

                Inifile.INIWriteValue(iniParameterPath, "Upload", "IsCheckUploadStatus", IsCheckUploadStatus.ToString());
                Inifile.INIWriteValue(iniParameterPath, "CheckINI", "IsCheckINI", IsCheckINI.ToString());

                Inifile.INIWriteValue(iniParameterPath, "System", "UPH", UPH.ToString());

                return true;
            }
            catch (Exception ex)
            {
                Log.Default.Error("WriteParameter", ex);
                return false;
            }
        }
        private void ReadAlarmRecord()
        {
            //iniAlarmRecordPath
            try
            {
                AlarmLastDayofYear = int.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "AlarmLastDayofYear", "0"));
                AlarmLastDateNameStr = Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "AlarmLastDateNameStr", "2017年5月5日");
                AlarmLastClearHourofYear = AlarmLastDayofYear = int.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "AlarmLastClearHourofYear", "0"));
                TotalAlarmNum = int.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "TotalAlarmNum", "0"));

                alarmTableItemsList[0].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station1", "SuckFail", "100"));
                alarmTableItemsList[0].ReleaseFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station1", "ReleaseFail", "0"));
                //alarmTableItemsList[0].测试机超时 = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴1", "测试机超时", "0"));
                //alarmTableItemsList[0].连续NG = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴1", "连续NG", "0"));

                alarmTableItemsList[1].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station2", "SuckFail", "0"));
                alarmTableItemsList[1].ReleaseFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station2", "ReleaseFail", "0"));
                //alarmTableItemsList[1].测试机超时 = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴2", "测试机超时", "0"));
                //alarmTableItemsList[1].连续NG = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴2", "连续NG", "0"));

                alarmTableItemsList[2].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station3", "SuckFail", "0"));
                alarmTableItemsList[2].ReleaseFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station3", "ReleaseFail", "0"));
                //alarmTableItemsList[2].测试机超时 = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴3", "测试机超时", "0"));
                //alarmTableItemsList[2].连续NG = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴3", "连续NG", "0"));

                alarmTableItemsList[3].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station4", "SuckFail", "0"));
                alarmTableItemsList[3].ReleaseFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Station4", "ReleaseFail", "0"));
                //alarmTableItemsList[3].测试机超时 = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴4", "测试机超时", "0"));
                //alarmTableItemsList[3].连续NG = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "测试机穴4", "连续NG", "0"));

                alarmTableItemsList[4].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition1", "SuckFail", "0"));
                alarmTableItemsList[5].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition2", "SuckFail", "0"));
                alarmTableItemsList[6].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition3", "SuckFail", "0"));
                alarmTableItemsList[7].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition4", "SuckFail", "0"));
                alarmTableItemsList[8].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition5", "SuckFail", "0"));
                alarmTableItemsList[9].SuckFail = ushort.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "LoadPanelPosition6", "SuckFail", "0"));


            }
            catch (Exception ex)
            {
                Log.Default.Error("ReadAlarmRecord", ex);
            }

        }
        private void WriteAlarmRecord()
        {
            try
            {
                Inifile.INIWriteValue(iniAlarmRecordPath, "Station1", "SuckFail", alarmTableItemsList[0].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Station1", "ReleaseFail", alarmTableItemsList[0].ReleaseFail.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴1", "测试机超时", alarmTableItemsList[0].测试机超时.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴1", "连续NG", alarmTableItemsList[0].连续NG.ToString());

                Inifile.INIWriteValue(iniAlarmRecordPath, "Station2", "SuckFail", alarmTableItemsList[1].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Station2", "ReleaseFail", alarmTableItemsList[1].ReleaseFail.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴2", "测试机超时", alarmTableItemsList[1].测试机超时.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴2", "连续NG", alarmTableItemsList[1].连续NG.ToString());

                Inifile.INIWriteValue(iniAlarmRecordPath, "Station3", "SuckFail", alarmTableItemsList[2].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Station3", "ReleaseFail", alarmTableItemsList[2].ReleaseFail.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴3", "测试机超时", alarmTableItemsList[2].测试机超时.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴3", "连续NG", alarmTableItemsList[2].连续NG.ToString());

                Inifile.INIWriteValue(iniAlarmRecordPath, "Station4", "SuckFail", alarmTableItemsList[3].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Station4", "ReleaseFail", alarmTableItemsList[3].ReleaseFail.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴4", "测试机超时", alarmTableItemsList[3].测试机超时.ToString());
                //Inifile.INIWriteValue(iniAlarmRecordPath, "测试机穴4", "连续NG", alarmTableItemsList[3].连续NG.ToString());

                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition1", "SuckFail", alarmTableItemsList[4].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition2", "SuckFail", alarmTableItemsList[5].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition3", "SuckFail", alarmTableItemsList[6].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition4", "SuckFail", alarmTableItemsList[7].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition5", "SuckFail", alarmTableItemsList[8].SuckFail.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "LoadPanelPosition6", "SuckFail", alarmTableItemsList[9].SuckFail.ToString());

                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "TotalAlarmNum", TotalAlarmNum.ToString());
            }
            catch (Exception ex)
            {
                Log.Default.Error("WriteAlarmRecord", ex);
            }
        }
        #endregion
        #region FunctionTest
        public delegate void FuncTProcessedDelegate();
        public async void FuncTStart(FuncTProcessedDelegate callback)
        {
            Func<Task> startTask = () =>
            {
                return Task.Run(async () =>
                {
                    if (fti > 7)
                    {
                        fti = 1;
                    }
                    FCmdIndex.Value = fti++;
                    FMoveCMD.Value = true;
                    FMoveCompleted.Value = false;
                    while (!(bool)FMoveCompleted.Value)
                    {
                        await Task.Delay(100);
                    }
                    callback();
                }
                );
            };
            await startTask();
        }
        public void FunctionTest()
        {
            //DataRow dr = TestRecodeDT.NewRow();
            //dr["Time"] = DateTime.Now.ToString();
            //dr["Barcode"] = "123";
            //dr["Result"] = TestResult.Pass.ToString();
            //dr["Cycle"] = 50.2;
            //dr["Index"] = 3;
            //TestRecodeDT.Rows.Add(dr);
            //epsonRC90.tester[1].Start(epsonRC90.StartProcess);
            //ShowAlarmTextGrid("测试机2，吸取失败");
            //TestRecord tr = new TestRecord(DateTime.Now.ToString(), "bar", "f", "11.1 s", "1");
            //SaveCSVfileRecord(tr);
            //FuncTStart(FuncPrint);
            //SampleDisplayArray[0,0] = (aaa++).ToString();
            //ShowSampleTestWindow = !ShowSampleTestWindow;
            //await Task.Delay(10000);
            //QuitSampleTest = !QuitSampleTest;
            //SampleWaitTimeShow = "Visible";
            //SampleCount_down();
            //QuiLiaoBarcode bar = new QuiLiaoBarcode();
            //bar.条码 = "1231234123";
            //QueLiaoTable.Add(bar);
            //ShowDiaoLiaoWindow = !ShowDiaoLiaoWindow;
            //AlarmDisplayShow();
        }
        private void AlarmDisplayShow()
        {
            ChoseAlarmLockDisplay();
            MenuIsEnabled = false;
        }
        public void FuncPrint()
        {
            Msg = messagePrint.AddMessage((fti - 1).ToString() + " 完成");
        }
        #endregion
        #region UI更新
        private async void UpdateUI()
        {
            //string _AlarmStr = "";
            //bool TwincatNeedAlarm = false;
            bool _SuckFailedFlag_flag = false;
            while (true)
            {
                await Task.Delay(200);
                epsonRC90.DiaoLiaoStatus = QueLiaoTable1.Count == 0 || !isDiaoLiaoStopFlag;
                TestSendPortStatus = epsonRC90.TestSendStatus;
                TestRevPortStatus = epsonRC90.TestReceiveStatus;
                MsgRevPortStatus = epsonRC90.MsgReceiveStatus;
                IORevPortStatus = epsonRC90.IOReceiveStatus;
                CtrlPortStatus = epsonRC90.CtrlStatus;
                TestSendFlexPortStatus = epsonRC90.TestSendFlexStatus;
                TestRevFlexPortStatus = epsonRC90.TestReceiveFlexStatus;
                IsTCPConnect = TestSendPortStatus & TestRevPortStatus & TestSendFlexPortStatus & TestRevFlexPortStatus & MsgRevPortStatus & CtrlPortStatus;

                SampleItemsStatus0 = SampleDisplayArray[0, 0];
                SampleItemsStatus1 = SampleDisplayArray[0, 1];
                SampleItemsStatus2 = SampleDisplayArray[0, 2];
                SampleItemsStatus3 = SampleDisplayArray[0, 3];
                SampleItemsStatus4 = SampleDisplayArray[0, 4];
                SampleItemsStatus5 = SampleDisplayArray[0, 5];
                SampleItemsStatus6 = SampleDisplayArray[0, 6];
                SampleItemsStatus7 = SampleDisplayArray[0, 7];
                SampleItemsStatus8 = SampleDisplayArray[0, 8];
                SampleItemsStatus9 = SampleDisplayArray[0, 9];

                SampleItemsStatus10 = SampleDisplayArray[1, 0];
                SampleItemsStatus11 = SampleDisplayArray[1, 1];
                SampleItemsStatus12 = SampleDisplayArray[1, 2];
                SampleItemsStatus13 = SampleDisplayArray[1, 3];
                SampleItemsStatus14 = SampleDisplayArray[1, 4];
                SampleItemsStatus15 = SampleDisplayArray[1, 5];
                SampleItemsStatus16 = SampleDisplayArray[1, 6];
                SampleItemsStatus17 = SampleDisplayArray[1, 7];
                SampleItemsStatus18 = SampleDisplayArray[1, 8];
                SampleItemsStatus19 = SampleDisplayArray[1, 9];

                SampleItemsStatus20 = SampleDisplayArray[2, 0];
                SampleItemsStatus21 = SampleDisplayArray[2, 1];
                SampleItemsStatus22 = SampleDisplayArray[2, 2];
                SampleItemsStatus23 = SampleDisplayArray[2, 3];
                SampleItemsStatus24 = SampleDisplayArray[2, 4];
                SampleItemsStatus25 = SampleDisplayArray[2, 5];
                SampleItemsStatus26 = SampleDisplayArray[2, 6];
                SampleItemsStatus27 = SampleDisplayArray[2, 7];
                SampleItemsStatus28 = SampleDisplayArray[2, 8];
                SampleItemsStatus29 = SampleDisplayArray[2, 9];

                SampleItemsStatus30 = SampleDisplayArray[3, 0];
                SampleItemsStatus31 = SampleDisplayArray[3, 1];
                SampleItemsStatus32 = SampleDisplayArray[3, 2];
                SampleItemsStatus33 = SampleDisplayArray[3, 3];
                SampleItemsStatus34 = SampleDisplayArray[3, 4];
                SampleItemsStatus35 = SampleDisplayArray[3, 5];
                SampleItemsStatus36 = SampleDisplayArray[3, 6];
                SampleItemsStatus37 = SampleDisplayArray[3, 7];
                SampleItemsStatus38 = SampleDisplayArray[3, 8];
                SampleItemsStatus39 = SampleDisplayArray[3, 9];

                try
                {
                    YieldNowNum1 = PassLowLimitStopNum + epsonRC90.AdminAddNum[0];
                    YieldNowNum2 = PassLowLimitStopNum + epsonRC90.AdminAddNum[1];
                    YieldNowNum3 = PassLowLimitStopNum + epsonRC90.AdminAddNum[2];
                    YieldNowNum4 = PassLowLimitStopNum + epsonRC90.AdminAddNum[3];

                    TestTime4 = epsonRC90.sIMTester[1].TestSpan[0];
                    TestCount4 = epsonRC90.sIMTester[1].TestCount[0];
                    PassCount4 = epsonRC90.sIMTester[1].PassCount[0];
                    FailCount4 = epsonRC90.sIMTester[1].FailCount[0];
                    Yield4 = epsonRC90.sIMTester[1].Yield[0];

                    TestTime5 = epsonRC90.sIMTester[1].TestSpan[1];
                    TestCount5 = epsonRC90.sIMTester[1].TestCount[1];
                    PassCount5 = epsonRC90.sIMTester[1].PassCount[1];
                    FailCount5 = epsonRC90.sIMTester[1].FailCount[1];
                    Yield5 = epsonRC90.sIMTester[1].Yield[1];

                    TestTime6 = epsonRC90.sIMTester[1].TestSpan[2];
                    TestCount6 = epsonRC90.sIMTester[1].TestCount[2];
                    PassCount6 = epsonRC90.sIMTester[1].PassCount[2];
                    FailCount6 = epsonRC90.sIMTester[1].FailCount[2];
                    Yield6 = epsonRC90.sIMTester[1].Yield[2];

                    TestTime7 = epsonRC90.sIMTester[1].TestSpan[3];
                    TestCount7 = epsonRC90.sIMTester[1].TestCount[3];
                    PassCount7 = epsonRC90.sIMTester[1].PassCount[3];
                    FailCount7 = epsonRC90.sIMTester[1].FailCount[3];
                    Yield7 = epsonRC90.sIMTester[1].Yield[3];

                    TestTime0 = epsonRC90.sIMTester[0].TestSpan[0];
                    //TestIdle0 = epsonRC90.testerwith4item[0].TestIdle[0];
                    //TestCycle0 = epsonRC90.testerwith4item[0].TestCycle[0];
                    TestCount0 = epsonRC90.sIMTester[0].TestCount[0];
                    PassCount0 = epsonRC90.sIMTester[0].PassCount[0];
                    FailCount0 = epsonRC90.sIMTester[0].FailCount[0];
                    Yield0 = epsonRC90.sIMTester[0].Yield[0];
                    TesterBracodeAL_1 = epsonRC90.sIMTester[0].TesterBracode[0];
                    TesterBracodeAL_2 = epsonRC90.sIMTester[0].TesterBracode[1];

                    TestTime1 = epsonRC90.sIMTester[0].TestSpan[1];
                    //TestIdle1 = epsonRC90.testerwith4item[0].TestIdle[1];
                    //TestCycle1 = epsonRC90.testerwith4item[0].TestCycle[1];
                    TestCount1 = epsonRC90.sIMTester[0].TestCount[1];
                    PassCount1 = epsonRC90.sIMTester[0].PassCount[1];
                    FailCount1 = epsonRC90.sIMTester[0].FailCount[1];
                    Yield1 = epsonRC90.sIMTester[0].Yield[1];
                    TesterBracodeAR_1 = epsonRC90.sIMTester[0].TesterBracode[2];
                    TesterBracodeAR_2 = epsonRC90.sIMTester[0].TesterBracode[3];

                    TestTime2 = epsonRC90.sIMTester[0].TestSpan[2];
                    //TestIdle2 = epsonRC90.testerwith4item[1].TestIdle[0];
                    //TestCycle2 = epsonRC90.testerwith4item[1].TestCycle[0];
                    TestCount2 = epsonRC90.sIMTester[0].TestCount[2];
                    PassCount2 = epsonRC90.sIMTester[0].PassCount[2];
                    FailCount2 = epsonRC90.sIMTester[0].FailCount[2];
                    Yield2 = epsonRC90.sIMTester[0].Yield[0];
                    TesterBracodeBL_1 = epsonRC90.sIMTester[1].TesterBracode[0];
                    TesterBracodeBL_2 = epsonRC90.sIMTester[1].TesterBracode[1];

                    TestTime3 = epsonRC90.sIMTester[0].TestSpan[3];
                    //TestIdle3 = epsonRC90.testerwith4item[1].TestIdle[1];
                    //TestCycle3 = epsonRC90.testerwith4item[1].TestCycle[1];
                    TestCount3 = epsonRC90.sIMTester[0].TestCount[3];
                    PassCount3 = epsonRC90.sIMTester[0].PassCount[3];
                    FailCount3 = epsonRC90.sIMTester[0].FailCount[3];
                    Yield3 = epsonRC90.sIMTester[0].Yield[3];
                    TesterBracodeBR_1 = epsonRC90.sIMTester[1].TesterBracode[2];
                    TesterBracodeBR_2 = epsonRC90.sIMTester[1].TesterBracode[3];

                    //TestCycleAve = Math.Round((TestCycle0 + TestCycle1 + TestCycle2 + TestCycle3) / 4, 2);

                    //TestCount0_Nomal = epsonRC90.testerwith4item[0].TestCount_Nomal[0];
                    //PassCount0_Nomal = epsonRC90.testerwith4item[0].PassCount_Nomal[0];
                    //FailCount0_Nomal = epsonRC90.testerwith4item[0].FailCount_Nomal[0];
                    //Yield0_Nomal = epsonRC90.testerwith4item[0].Yield_Nomal[0];

                    //TestCount1_Nomal = epsonRC90.testerwith4item[0].TestCount_Nomal[1];
                    //PassCount1_Nomal = epsonRC90.testerwith4item[0].PassCount_Nomal[1];
                    //FailCount1_Nomal = epsonRC90.testerwith4item[0].FailCount_Nomal[1];
                    //Yield1_Nomal = epsonRC90.testerwith4item[0].Yield_Nomal[1];

                    //TestCount2_Nomal = epsonRC90.testerwith4item[1].TestCount_Nomal[0];
                    //PassCount2_Nomal = epsonRC90.testerwith4item[1].PassCount_Nomal[0];
                    //FailCount2_Nomal = epsonRC90.testerwith4item[1].FailCount_Nomal[0];
                    //Yield2_Nomal = epsonRC90.testerwith4item[1].Yield_Nomal[0];

                    //TestCount3_Nomal = epsonRC90.testerwith4item[1].TestCount_Nomal[1];
                    //PassCount3_Nomal = epsonRC90.testerwith4item[1].PassCount_Nomal[1];
                    //FailCount3_Nomal = epsonRC90.testerwith4item[1].FailCount_Nomal[1];
                    //Yield3_Nomal = epsonRC90.testerwith4item[1].Yield_Nomal[1];

                    TesterResult0 = epsonRC90.sIMTester[0].testResult[0].ToString();
                    switch (TesterResult0)
                    {
                        case "Ng":
                            TesterStatusBackGround0 = "Red";
                            TesterStatusForeground0 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround0 = "Green";
                            TesterStatusForeground0 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround0 = "Wheat";
                            TesterStatusForeground0 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround0 = "Wheat";
                            TesterStatusForeground0 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult1 = epsonRC90.sIMTester[0].testResult[1].ToString();
                    switch (TesterResult1)
                    {
                        case "Ng":
                            TesterStatusBackGround1 = "Red";
                            TesterStatusForeground1 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround1 = "Green";
                            TesterStatusForeground1 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround1 = "Wheat";
                            TesterStatusForeground1 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround1 = "Wheat";
                            TesterStatusForeground1 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult2 = epsonRC90.sIMTester[0].testResult[2].ToString();
                    switch (TesterResult2)
                    {
                        case "Ng":
                            TesterStatusBackGround2 = "Red";
                            TesterStatusForeground2 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround2 = "Green";
                            TesterStatusForeground2 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround2 = "Wheat";
                            TesterStatusForeground2 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround2 = "Wheat";
                            TesterStatusForeground2 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult3 = epsonRC90.sIMTester[0].testResult[3].ToString();
                    switch (TesterResult3)
                    {
                        case "Ng":
                            TesterStatusBackGround3 = "Red";
                            TesterStatusForeground3 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround3 = "Green";
                            TesterStatusForeground3 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround3 = "Wheat";
                            TesterStatusForeground3 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround3 = "Wheat";
                            TesterStatusForeground3 = "Maroon";
                            break;
                        default:
                            break;
                    }

                    TesterResult4 = epsonRC90.sIMTester[1].testResult[0].ToString();
                    switch (TesterResult4)
                    {
                        case "Ng":
                            TesterStatusBackGround4 = "Red";
                            TesterStatusForeground4 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround4 = "Green";
                            TesterStatusForeground4 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround4 = "Wheat";
                            TesterStatusForeground4 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround4 = "Wheat";
                            TesterStatusForeground4 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult5 = epsonRC90.sIMTester[1].testResult[1].ToString();
                    switch (TesterResult5)
                    {
                        case "Ng":
                            TesterStatusBackGround5 = "Red";
                            TesterStatusForeground5 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround5 = "Green";
                            TesterStatusForeground5 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround5 = "Wheat";
                            TesterStatusForeground5 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround5 = "Wheat";
                            TesterStatusForeground5 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult6 = epsonRC90.sIMTester[1].testResult[2].ToString();
                    switch (TesterResult6)
                    {
                        case "Ng":
                            TesterStatusBackGround6 = "Red";
                            TesterStatusForeground6 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround6 = "Green";
                            TesterStatusForeground6 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround6 = "Wheat";
                            TesterStatusForeground6 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround6 = "Wheat";
                            TesterStatusForeground6 = "Maroon";
                            break;
                        default:
                            break;
                    }
                    TesterResult7 = epsonRC90.sIMTester[1].testResult[3].ToString();
                    switch (TesterResult7)
                    {
                        case "Ng":
                            TesterStatusBackGround7 = "Red";
                            TesterStatusForeground7 = "White";
                            break;
                        case "Pass":
                            TesterStatusBackGround7 = "Green";
                            TesterStatusForeground7 = "White";
                            break;
                        case "Unknow":
                            TesterStatusBackGround7 = "Wheat";
                            TesterStatusForeground7 = "Yellow";
                            break;
                        case "TimeOut":
                            TesterStatusBackGround7 = "Wheat";
                            TesterStatusForeground7 = "Maroon";
                            break;
                        default:
                            break;
                    }
                }
                catch
                {


                }


                PickBracodeA_1 = epsonRC90.PickBracodeA_1;
                PickBracodeA_2 = epsonRC90.PickBracodeA_2;
                PickBracodeB_1 = epsonRC90.PickBracodeB_1;
                PickBracodeB_2 = epsonRC90.PickBracodeB_2;


                try
                {
                    ServoHomed1 = (bool)XRDY.Value;
                    ServoHomed2 = (bool)YRDY.Value;
                    ServoHomed3 = (bool)FRDY.Value;
                    ServoHomed4 = (bool)TRDY.Value;
                    
                    _SuckFailedFlag = (bool)SuckFailedFlag.Value;
                    if (_SuckFailedFlag_flag != _SuckFailedFlag)
                    {
                        _SuckFailedFlag_flag = _SuckFailedFlag;
                        if (_SuckFailedFlag_flag)
                        {
                            WriteAlarmCSV_Robot("034");
                        }
                    }
                    //if (_AlarmStr != (string)AlarmStr.Value)
                    //{
                    //    _AlarmStr = (string)AlarmStr.Value;
                    //    if (_AlarmStr.Length > 0)
                    //    {
                    //        Msg = messagePrint.AddMessage(_AlarmStr);
                    //    }
                    //}
                    _XYInDebug = (bool)XYInDebug.Value;
                    
                    _FInDebug = (bool)FInDebug.Value;
                    _TInDebug = (bool)TInDebug.Value;


                    _XYRDYtoDebug = (bool)XYRDYtoDebug.Value;
                    
                    _FRDYtoDebug = (bool)FRDYtoDebug.Value;
                    _TRDYtoDebug = (bool)TRDYtoDebug.Value;
                }
                catch
                {


                }

            }
        }
        private async void DispatcherTimerTickUpdateUi(Object sender, EventArgs e)
        {

            PLCMessageVisibility = "Collapsed";
            PLCMessage = "";
            if (XinJieOut != null)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (XinJieOut[50 + i])
                    {
                        switch (i)
                        {
                            case 0:
                                PLCMessage = "上料满盘缺料";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 1:
                                PLCMessage = "上料空盘满";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 2:
                                PLCMessage = "下料满盘满";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 3:
                                PLCMessage = "下料空盘缺";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 4:
                                PLCMessage = "上料吸空盘失败";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 5:
                                PLCMessage = "下料吸空盘失败";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 6:
                                PLCMessage = "上料空盘轴未准备好";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 7:
                                PLCMessage = "下料蓝盘轴未准备好";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 8:
                                PLCMessage = "上料无杆气缸置位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 9:
                                PLCMessage = "上料无杆气缸复位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 10:
                                PLCMessage = "上料上下气缸复位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 11:
                                PLCMessage = "下料无杆气缸置位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 12:
                                PLCMessage = "下料无杆气缸复位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 13:
                                PLCMessage = "下料上下气缸复位超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 14:
                                PLCMessage = "上料满盘电机上升超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 15:
                                PLCMessage = "上料满盘电机下降超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 16:
                                PLCMessage = "上料空盘电机上升超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 17:
                                PLCMessage = "上料空盘电机下降超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 18:
                                PLCMessage = "下料满盘电机上升超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 19:
                                PLCMessage = "下料空盘电机下降超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 20:
                                PLCMessage = "下料满盘电机上升超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 21:
                                PLCMessage = "下料空盘电机下降超时";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 22:
                                PLCMessage = "下料XY吸取失败报警";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 23:
                                PLCMessage = "下料XY未准备好报警";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 46:
                                PLCMessage = "测试机被屏蔽";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 47:
                                PLCMessage = "测试机良率超下限";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 24:
                                PLCMessage = "机械手暂停报警";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 34:
                                PLCMessage = "上料满盘未准备好";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 35:
                                PLCMessage = "上料盘漏吸料报警";
                                PLCMessageVisibility = "Visible";
                                break;
                            case 32:
                                PLCMessage = "测试机被屏蔽";
                                PLCMessageVisibility = "Visible";
                                break;
                            default:
                                break;
                        }
                        
                        break;
                    }

                }
            }
            



            jigdown_flag = !TestCheckedAL || !TestCheckedBL || epsonRC90.sIMTester[0].testResult[0] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[1] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[2] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[3] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[0] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[1] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[2] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[3] == TestResult.TimeOut;            
            if (++tick_secend >= 6)
            {
                tick_secend = 0;
                work_flag = DangbanFirstProduct == GetBanci();
                if (work_flag && !EpsonStatusPaused && !waitforinputflag && !Testerwith4item.IsInSampleMode)
                {
                    run_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "run_min", run_min.ToString("F2"));
                }
                if (work_flag)
                {
                    work_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "work_min", work_min.ToString("F2"));
                }
                if (System.DateTime.Now.Hour >= 20)
                {
                    world_min = (System.DateTime.Now - System.DateTime.Parse(System.DateTime.Now.ToShortDateString() + "  20:00:00")).TotalMinutes;
                }
                else
                {
                    if (System.DateTime.Now.Hour >= 8 && System.DateTime.Now.Hour < 20)
                    {
                        world_min = (System.DateTime.Now - System.DateTime.Parse(System.DateTime.Now.ToShortDateString() + "  8:00:00")).TotalMinutes;
                    }
                    else
                    {
                        world_min = (System.DateTime.Now - System.DateTime.Parse(System.DateTime.Now.AddDays(-1).ToShortDateString() + "  20:00:00")).TotalMinutes;
                    }
                }
                Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "world_min", world_min.ToString("F2"));
                if (down_flag)
                {
                    down_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "down_min", down_min.ToString("F2"));
                }
                if (jigdown_flag)
                {
                    jigdown_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "jigdown_min", jigdown_min.ToString("F2"));
                }
                if (waitinput_flag)
                {
                    waitinput_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "waitinput_min", waitinput_min.ToString("F2"));
                }
                if (waittray_flag)
                {
                    waittray_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "waittray_min", waittray_min.ToString("F2"));
                }
                if (waittake_flag)
                {
                    waittake_min += 0.1;
                    Inifile.INIWriteValue(iniTimeCalcPath, "Summary", "waittake_min", waittake_min.ToString("F2"));
                }
                if (run_min == 0 || UPH == 0)
                    AchievingRate = 100;
                else
                    AchievingRate = Math.Round(liaooutput / ((double)UPH / 60 * run_min) * 100, 2);
                if (work_min == 0)
                {
                    ProperRate = 0;
                    ProperRate_AutoMation = 0;
                    ProperRate_Jig = 0;
                }                    
                else
                {
                    ProperRate = Math.Round((1 - (down_min + jigdown_min) / work_min) * 100, 2);
                    ProperRate_AutoMation = Math.Round((1 - down_min / work_min) * 100, 2);
                    ProperRate_Jig = Math.Round((1 - jigdown_min / work_min) * 100, 2);
                }
                    
                //if (AlarmTextGridShow != "Visible")
                //{
                //    Inifile.INIWriteValue(iniFClient, "Alarm", "Name", "NULL");
                //}
                Write及时雨();
            }

            var yue = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            //LoginPassword
            var password1 = yue + day;
            string passwordstr = "";

            //Write及时雨();
            //if (WaitPcsSecend++ > 60)
            //{
            //    WaitPcsSecend = 0;
            //    if (WaitPcsFlag)
            //    {
            //        waitforinput += 0.0167;
            //        Inifile.INIWriteValue(iniAlarmRecordPath, "Summary", "waitforinput", waitforinput.ToString());
            //    }
            //    //EpsonStatusPaused
            //    if (EpsonStatusPaused)
            //    {
            //        downtime += 0.0167;
            //        Inifile.INIWriteValue(iniAlarmRecordPath, "Summary", "downtime", downtime.ToString());
            //    }

            //}

            if (IsPLCConnect)
            {
                M20027 = XinJieOut[27] ? "Visible" : "Collapsed";
                M20028 = XinJieOut[28] ? "Visible" : "Collapsed";
                M20029 = XinJieOut[29] ? "Visible" : "Collapsed";
                M20030 = XinJieOut[30] ? "Visible" : "Collapsed";
            }

            for (int i = 0; i < 4 - password1.ToString().Length; i++)
            {
                passwordstr += "0";
            }
            LoginPassword = passwordstr + password1.ToString();
            if (UpdateSeverTimes++ > 10)
            {
                UpdateSeverTimes = 0;
                try
                {
                    ConnectDBTest();
                }
                catch
                {


                }
            }

            if (SampleHave1)
            {
                SampleData1 = "Green";
            }
            else
            {
                SampleData1 = "Red";
            }
            if (SampleHave2)
            {
                SampleData2 = "Green";
            }
            else
            {
                SampleData2 = "Red";
            }
            if (SampleHave3)
            {
                SampleData3 = "Green";
            }
            else
            {
                SampleData3 = "Red";
            }
            if (SampleHave4)
            {
                SampleData4 = "Green";
            }
            else
            {
                SampleData4 = "Red";
            }
            if (SampleHave5)
            {
                SampleData5 = "Green";
            }
            else
            {
                SampleData5 = "Red";
            }
            if (SampleHave6)
            {
                SampleData6 = "Green";
            }
            else
            {
                SampleData6 = "Red";
            }
            if (SampleHave7)
            {
                SampleData7 = "Green";
            }
            else
            {
                SampleData7 = "Red";
            }
            if (SampleHave8)
            {
                SampleData8 = "Green";
            }
            else
            {
                SampleData8 = "Red";
            }
            if (SampleHave9)
            {
                SampleData9 = "Green";
            }
            else
            {
                SampleData9 = "Red";
            }
            if (SampleHave10)
            {
                SampleData10 = "Green";
            }
            else
            {
                SampleData10 = "Red";
            }
            if (SampleHave11)
            {
                SampleData11 = "Green";
            }
            else
            {
                SampleData11 = "Red";
            }
            if (SampleHave12)
            {
                SampleData12 = "Green";
            }
            else
            {
                SampleData12 = "Red";
            }

            //if ((DateTime.Now.DayOfYear - AlarmLastDayofYear)*24 + DateTime.Now.Hour > 24)
            //{
            //    Alarm_allowClean = true;
            //    ClearAlarmRecord();              
            //}
            //else
            //{
            //    if (Alarm_allowClean && (DateTime.Now.Hour == 8 || DateTime.Now.Hour == 20))
            //    {
            //        Alarm_allowClean = false;
            //        ClearAlarmRecord();
            //    }
            //    else
            //    {
            //        if (DateTime.Now.Hour != 8 && DateTime.Now.Hour != 20)
            //        {
            //            Alarm_allowClean = true;
            //        }
            //    }
            //}
            if (AlarmLastClearHourofYear > DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour)
            {
                AlarmLastClearHourofYear = 0;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastClearHourofYear", AlarmLastClearHourofYear.ToString());
            }
            isIn8or20 = DateTime.Now.Hour == 8 || DateTime.Now.Hour == 20;
            if (isIn8or20 != _isIn8or20)
            {
                if (isIn8or20)
                {
                    if (AlarmLastClearHourofYear == DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour)
                    {
                        Alarm_allowClean = bool.Parse(Inifile.INIGetStringValue(iniAlarmRecordPath, "Alarm", "Alarm_allowClean", "False"));
                        if (Alarm_allowClean)
                        {
                            AutoClean();
                            Alarm_allowClean = false;
                            Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Alarm_allowClean", Alarm_allowClean.ToString());
                            AlarmLastClearHourofYear = DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour;
                            Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastClearHourofYear", AlarmLastClearHourofYear.ToString());
                        }
                    }
                    else
                    {
                        AutoClean();
                        Alarm_allowClean = true;
                        Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Alarm_allowClean", Alarm_allowClean.ToString());
                        AlarmLastClearHourofYear = DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour;
                        Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastClearHourofYear", AlarmLastClearHourofYear.ToString());
                    }
                }
                else
                {
                    Alarm_allowClean = true;
                    Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Alarm_allowClean", Alarm_allowClean.ToString());
                }
                _isIn8or20 = isIn8or20;
            }
            if (DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour - AlarmLastClearHourofYear > 12)
            {
                AutoClean();
                Alarm_allowClean = true;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Alarm_allowClean", Alarm_allowClean.ToString());
                if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                {
                    AlarmLastClearHourofYear = DateTime.Now.DayOfYear * 24 + 8;
                }
                else
                {
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 8)
                    {
                        AlarmLastClearHourofYear = (DateTime.Now.DayOfYear - 1) * 24 + 20;
                    }
                    else
                    {
                        AlarmLastClearHourofYear = DateTime.Now.DayOfYear * 24 + 20;
                    }
                }
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "AlarmLastClearHourofYear", AlarmLastClearHourofYear.ToString());
            }

            if (myTestRecordQueue.Count > 0)
            {
                lock (this)
                {
                    foreach (TestRecord item in myTestRecordQueue)
                    {
                        testRecord.Add(item);
                    }
                    myTestRecordQueue.Clear();
                }
            }
            QueLiaoTable.Clear();
            foreach (QuiLiaoBarcode item in QueLiaoTable1)
            {
                QueLiaoTable.Add(item);
            }

            alarmTableItems.Clear();
            foreach (var item in alarmTableItemsList)
            {
                alarmTableItems.Add(item);
            }

            if (SampleDt.Rows.Count > 0)
            {
                X758SampleResultDataTableItems.Clear();
                foreach (DataRow item in SampleDt.Rows)
                {
                    X758SampleResultData x758SampleResultData = new X758SampleResultData();
                    x758SampleResultData.PARTNUM = (string)item["PARTNUM"];
                    x758SampleResultData.SITEM = (string)item["SITEM"];
                    x758SampleResultData.BARCODE = (string)item["BARCODE"];
                    x758SampleResultData.NGITEM = (string)item["NGITEM"];
                    x758SampleResultData.TRES = (string)item["TRES"];
                    x758SampleResultData.MNO = (string)item["MNO"];
                    x758SampleResultData.CDATE = (string)item["CDATE"];
                    x758SampleResultData.CTIME = (string)item["CTIME"];
                    x758SampleResultData.SR01 = (string)item["SR01"];
                    x758SampleResultData.FL02 = (string)item["FL02"];
                    x758SampleResultData.FL03 = (string)item["FL03"];
                    X758SampleResultDataTableItems.Add(x758SampleResultData);
                }
            }

            //Text = "{Binding PassStatusDisplay1}" Foreground = "{Binding PassStatusColor1}"
            string[] Yieldstrs1 = PassStatusProcess(Yield0);
            PassStatusDisplay1 = "测试机1" + Yieldstrs1[0];
            PassStatusColor1 = Yieldstrs1[1];

            string[] Yieldstrs2 = PassStatusProcess(Yield1);
            PassStatusDisplay2 = "测试机2" + Yieldstrs2[0];
            PassStatusColor2 = Yieldstrs2[1];

            string[] Yieldstrs3 = PassStatusProcess(Yield2);
            PassStatusDisplay3 = "测试机3" + Yieldstrs3[0];
            PassStatusColor3 = Yieldstrs3[1];

            string[] Yieldstrs4 = PassStatusProcess(Yield3);
            PassStatusDisplay4 = "测试机4" + Yieldstrs4[0];
            PassStatusColor4 = Yieldstrs4[1];

            string[] Yieldstrs5 = PassStatusProcess(Yield4);
            PassStatusDisplay5 = "测试机5" + Yieldstrs5[0];
            PassStatusColor5 = Yieldstrs5[1];

            string[] Yieldstrs6 = PassStatusProcess(Yield5);
            PassStatusDisplay6 = "测试机6" + Yieldstrs6[0];
            PassStatusColor6 = Yieldstrs6[1];

            string[] Yieldstrs7 = PassStatusProcess(Yield6);
            PassStatusDisplay7 = "测试机7" + Yieldstrs7[0];
            PassStatusColor7 = Yieldstrs7[1];

            string[] Yieldstrs8 = PassStatusProcess(Yield7);
            PassStatusDisplay8 = "测试机8" + Yieldstrs8[0];
            PassStatusColor8 = Yieldstrs8[1];

            try
            {
                //if (IsTestersClean && AllowCleanActionCommand)
                //{
                //    DateTimeUtility.SYSTEMTIME ds1 = new DateTimeUtility.SYSTEMTIME();
                //    DateTimeUtility.GetLocalTime(ref ds1);
                //    TimeSpan ts1 = ds1.ToDateTime() - lastchuiqi.ToDateTime();
                //    if (ts1.TotalHours > 2)
                //    {
                //        if (IsTestersClean)
                //        {
                //            if (epsonRC90.TestSendStatus)
                //            {
                //                await epsonRC90.TestSentNet.SendAsync("TestersCleanAction");
                //                AllowCleanActionCommand = false;
                //            }

                //        }
                //    }
                //}

                //if (IsTestersSample && AllowSampleTestCommand)
                //{
                //    DateTimeUtility.SYSTEMTIME ds1 = new DateTimeUtility.SYSTEMTIME();
                //    DateTimeUtility.GetLocalTime(ref ds1);
                //    TimeSpan ts1 = ds1.ToDateTime() - lastSample.ToDateTime();
                //    if (ts1.TotalHours > SampleTimeElapse)
                //    {
                //        if (IsTestersSample)
                //        {
                //            if (epsonRC90.TestSendStatus)
                //            {
                //                await epsonRC90.TestSentNet.SendAsync("GONOGOAction;" + SampleNgitemsNum.ToString());
                //                AllowSampleTestCommand = false;
                //            }

                //        }
                //    }
                //}
                //if (LastSampleHour > DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour)
                //{
                //    LastSampleHour = 0;
                //}
                //if (IsTestersSample)
                //{
                //    if (DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour - LastSampleHour >= 12)
                //    {
                //        SampleTextGridShow = "Visible";
                //        SampleTextString = "需要测样本";
                //    }
                //    else
                //    {
                //        SampleTextGridShow = "Collapsed";
                //    }
                //}
                //else
                //{
                //    SampleTextGridShow = "Collapsed";
                //}

                //if (IsTestersSample && AllowSampleTestCommand)
                //{
                //    if (DateTime.Now.DayOfYear * 24 + DateTime.Now.Hour - LastSampleHour >= 19)
                //    {
                //        if (IsTestersSample)
                //        {
                //            if (epsonRC90.TestSendStatus)
                //            {
                //                await epsonRC90.TestSentNet.SendAsync("GONOGOAction;" + SampleNgitemsNum.ToString());
                //                AllowSampleTestCommand = false;
                //                SampleWindowCloseEnable = false;
                //                SampleWaitTimeShow = "Collapsed";
                //                for (int i = 0; i < 4; i++)
                //                {
                //                    for (int j = 0; j < 10; j++)
                //                    {
                //                        SampleDisplayArray[i, j] = "";
                //                    }
                //                }
                //            }

                //        }
                //    }
                //}
                TimeSpan ts = System.DateTime.Now - Convert.ToDateTime(LastSampleTestFinishTime);
                if (ts.TotalHours > SampleTestTimeSpan - 1)
                {
                    SampleTextGridShow = "Visible";
                    SampleTextString = "需要测样本";
                }
                else
                {
                    SampleTextGridShow = "Collapsed";
                }
                if (EpsonStatusReady)
                {
                    RobotRestarted = false;
                }
                if (RobotRestarted && IsTestersSample && AllowSampleTestCommand && ts.TotalHours > SampleTestTimeSpan)
                {
                    XQTActionFunction(5);
                }
            }
            catch (Exception ex)
            {
                //Log.Default.Error("DateTimeUtility.GetLocalTime(ref ds1)", ex);
            }
            if (downtimeflag)
            {
                Downtime += 0.0167;
                DowntimeDisp = Downtime / 12 * 60 / 100;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "downtime", Downtime.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "DowntimeDisp", DowntimeDisp.ToString());
            }
            if (EpsonStatusRunning)
            {
                runtime += 0.0167;
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "runtime", runtime.ToString());
            }
            if (EpsonStatusAuto)
            {
                totaltime += 0.0167;
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "totaltime", totaltime.ToString());
            }
            if (jigdowntimeflag)
            {
                Jigdowntime += 0.0167;
                JigdowntimeDisp = Jigdowntime / 12 * 60 / 100;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Jigdowntime", Jigdowntime.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "JigdowntimeDisp", JigdowntimeDisp.ToString());
            }
            if (waitforinputflag)
            {
                Waitforinput += 0.0167;
                WaitforinputDisp = Waitforinput / 12 * 60 / 100;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Waitforinput", Waitforinput.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "WaitforinputDisp", WaitforinputDisp.ToString());
            }
            if (waitfortrayflag)
            {
                Waitfortray += 0.0167;
                WaitfortrayDisp = Waitfortray / 12 * 60 / 100;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Waitfortray", Waitfortray.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "WaitfortrayDisp", WaitfortrayDisp.ToString());
            }
            if (waitfortakeflag)
            {
                Waitfortake += 0.0167;
                WaitfortakeDisp = Waitfortake / 12 * 60 / 100;
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "Waitfortake", Waitfortake.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "WaitfortakeDisp", WaitfortakeDisp.ToString());
            }
            DowntimeStr = Downtime.ToString("F2");
            JigdowntimeStr = Jigdowntime.ToString("F2");
            WaitforinputStr = Waitforinput.ToString("F2");
            WaitfortrayStr = Waitfortray.ToString("F2");
            WaitfortakeStr = Waitfortake.ToString("F2");
            if (LastCleanAlarmDatetime != GetBanci())
            {
                LastCleanAlarmDatetime = GetBanci();
                Inifile.INIWriteValue(iniParameterPath, "LastCleanAlarm", "LastCleanAlarmDatetime", LastCleanAlarmDatetime);
                try
                {
                    if (!File.Exists("D:\\mantain.csv"))
                    {
                        string[] heads = { "DateTime", "上料机故障时间", "治具故障时间", "等待时间", "下料等待时间", "无TRAY时间" };
                        Csvfile.savetocsv("D:\\mantain.csv", heads);
                    }
                    string[] conte = { System.DateTime.Now.ToString(), Downtime.ToString(), Jigdowntime.ToString(), Waitforinput.ToString(), Waitfortray.ToString(), Waitfortake.ToString() };
                    Csvfile.savetocsv("D:\\mantain.csv", conte);
                }
                catch (Exception ex)
                {
                    Msg = messagePrint.AddMessage("写入CSV文件失败");
                    Log.Default.Error("写入CSV文件失败", ex.Message);
                }

                Downtime = 0;
                Jigdowntime = 0;
                Waitforinput = 0;
                Waitfortray = 0;
                Waitfortake = 0;
                runtime = 0;
                totaltime = 0;

                run_min = 0;
                work_min = 0;
                down_min = 0;
                jigdown_min = 0;
                waitinput_min = 0;
                waittray_min = 0;
                waittake_min = 0;
                liaooutput = 0;
                liaoinput = 0;

                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "downtime", Downtime.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "jigdowntime", Jigdowntime.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "waitforinput", Waitforinput.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "waitfortray", Waitfortray.ToString());
                Inifile.INIWriteValue(iniAlarmRecordPath, "Alarm", "waitfortake", Waitfortake.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "runtime", runtime.ToString());
                Inifile.INIWriteValue(iniParameterPath, "Alarm", "totaltime", totaltime.ToString());
                if (File.Exists(System.Environment.CurrentDirectory + "\\fault_list.csv"))
                {
                    File.Delete(System.Environment.CurrentDirectory + "\\fault_list.csv");
                }
                string[] heads1 = { "日期", "班别", "Start time", "End time", "故障时间（分）","异常描述" };
                Csvfile.savetocsv(System.Environment.CurrentDirectory + "\\fault_list.csv", heads1);
            }
            //if (SampleAlarm_IsNeedCheckin)
            //{
            //    SampleAlarm_IsNeedCheckin = false;
            //    NeedCheckin = await mydialog.showconfirm("样本数据库查询 失败。是否录入样本");
            //    SampleAlarm_IsNeedCheckin_finish = true;
            //}
        }
        void Write及时雨()
        {
            //Inifile.INIWriteValue(iniFClient, "DataList", "TestCount_1", TestCount0_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "Yield_1", Yield0_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "TestCount_2", TestCount1_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "Yield_2", Yield1_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "TestCount_3", TestCount2_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "Yield_3", Yield2_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "TestCount_4", TestCount3_Nomal.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "Yield_4", Yield3_Nomal.ToString());

            //Inifile.INIWriteValue(iniFClient, "DataList", "Downtime ", down_min.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "Jigdowntime ", jigdown_min.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "Waitforinput", waitinput_min.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "Waitfortray", waittray_min.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "Waitfortake", waittake_min.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "TestCount_Total", (TestCount0_Nomal + TestCount1_Nomal + TestCount2_Nomal + TestCount3_Nomal).ToString());
            //if (TestCount0_Nomal + TestCount1_Nomal + TestCount2_Nomal + TestCount3_Nomal > 0)
            //{
            //    Inifile.INIWriteValue(iniFClient, "DataList", "Yield_Total", ((double)(PassCount0_Nomal + PassCount1_Nomal + PassCount2_Nomal + PassCount3_Nomal) / (TestCount0_Nomal + TestCount1_Nomal + TestCount2_Nomal + TestCount3_Nomal) * 100).ToString("F2"));
            //}
            //else
            //{
            //    Inifile.INIWriteValue(iniFClient, "DataList", "Yield_Total", "0");
            //}
            ////Inifile.INIWriteValue(iniFClient, "DataList", "Input", liaoinput.ToString());
            ////Inifile.INIWriteValue(iniFClient, "DataList", "Output", liaooutput.ToString());
            //Inifile.INIWriteValue(iniFClient, "Alarm", "count", TotalAlarmNum.ToString());
            //Inifile.INIWriteValue(iniFClient, "DataList", "AchievingRate", AchievingRate.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "ProperRate", ProperRate.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "ProperRate_AutoMation", ProperRate_AutoMation.ToString("F2"));
            //Inifile.INIWriteValue(iniFClient, "DataList", "ProperRate_Jig", ProperRate_Jig.ToString("F2"));
        }
        #endregion
        #region 导入导出
        //[Export(MEF.Contracts.ActionMessage)]
        //[ExportMetadata(MEF.Key, "winclose")]
        //public async void WindowClose()
        //{
        //    mydialog.changeaccent("Red");

        //    var r = await mydialog.showconfirm("确定要关闭程序吗？");
        //    if (r)
        //    {
        //        //epsonRC90.TestSentNet.client.Close();
        //        //epsonRC90.TestReceiveNet.client.Close();
        //        //epsonRC90.MsgReceiveNet.client.Close();
        //        //epsonRC90.CtrlNet.client.Close();
        //        System.Windows.Application.Current.Shutdown();
        //    }
        //    else
        //    {
        //        mydialog.changeaccent("Cobalt");
        //    }
        //}
        #endregion
        #region 初始化
        [Initialize]
        public void Run()
        {
            bool zuoxizui = false, youxizui = false, shangliaobf = false, xialiaobf = false, shangliaoxj = false, xialiaoxj = false, shangLiaoFlag = false;
            bool testCheckedAL = true, testCheckedBL = true;
            System.Threading.Thread.Sleep(1000);
            while (true)
            {
                System.Threading.Thread.Sleep(10);

                try
                {
                    //Epson,beckhoff→xinjie
                    //M20200


      
                    XinJieIn[17] = (bool)UnloadTrayCMD.Value;
                    XinJieIn[19] = (bool)PLCPreSuck.Value;

                    XinJieIn[21] = (bool)SuckFailedFlag.Value;
                    XinJieIn[22] = (bool)M1202_1.Value;

                    XinJieIn[2] = epsonRC90.Rc90Out[0];//RollSetOut
                    XinJieIn[3] = epsonRC90.Rc90Out[1];//RollResetout
                    XinJieIn[4] = epsonRC90.Rc90Out[7];//PrePickCMD

                    XinJieIn[38] = EpsonStatusPaused;
                    XinJieIn[39] = epsonRC90.Rc90Out[8];
                    XinJieIn[40] = epsonRC90.Rc90Out[22];
                    XinJieIn[41] = epsonRC90.Rc90Out[23];
                    XinJieIn[42] = epsonRC90.Rc90Out[24];
                    XinJieIn[43] = epsonRC90.Rc90Out[25];
                    XinJieIn[44] = epsonRC90.Rc90Out[26];
                    XinJieIn[45] = epsonRC90.Rc90Out[27];

                    BFO5.Value = epsonRC90.Rc90Out[30];
                    BFO6.Value = epsonRC90.Rc90Out[31];
                    BFO7.Value = epsonRC90.Rc90Out[32];
                    BFO8.Value = epsonRC90.Rc90Out[33];

                    BFO13.Value = XinJieOut[3];



                    double ps = (double)WaitPositionY.Value < (double)PickPositionY.Value ? (double)WaitPositionY.Value : (double)PickPositionY.Value;
                    XinJieIn[18] = (double)YPos.Value > ps - 1 && (bool)XYStared.Value;

                    //xinjie→Epson,beckhoff
                    //M20000


                    //NoPhotoCMD.Value = XinJieOut[25];

                    //epsonRC90.Rc90In[3] = XinJieOut[14] && (bool)WaitCmd1.Value;
                    UnloadTrayFinish.Value = XinJieOut[9];
                    M1202.Value = XinJieOut[10];


                    epsonRC90.Rc90In[2] = XinJieOut[1];//CloseCMD
                    epsonRC90.Rc90In[3] = XinJieOut[2];//AutoDischarge
                    RollReset.Value = epsonRC90.Rc90Out[1];
                    RollSet.Value = epsonRC90.Rc90Out[0];


                    //InputSafedoorFlag.Value = XinJieOut[31];
                    OutputSafedoorFlag.Value = XinJieOut[32];
                    epsonRC90.Rc90In[15] = XinJieOut[31];

                    //if (zuoxizui != XinJieOut[12])
                    //{
                    //    zuoxizui = XinJieOut[12];
                    //    if (zuoxizui)
                    //    {
                    //        JiTaiDangqian1++;
                    //    }
                    //}
                    //if (youxizui != XinJieOut[13])
                    //{
                    //    youxizui = XinJieOut[13];
                    //    if (youxizui)
                    //    {
                    //        JiTaiDangqian2++;
                    //    }
                    //}
                    //bool _shangliaobf = (bool)Suck1.Value || (bool)Suck2.Value || (bool)Suck3.Value || (bool)Suck4.Value || (bool)Suck5.Value || (bool)Suck6.Value || (bool)Suck7.Value || (bool)Suck8.Value;
                    //if (shangliaobf != _shangliaobf)
                    //{
                    //    shangliaobf = _shangliaobf;
                    //    if (shangliaobf)
                    //    {
                    //        JiTaiDangqian3++;
                    //    }
                    //}

                    //if (xialiaobf != (bool)BFO2.Value)
                    //{
                    //    xialiaobf = (bool)BFO2.Value;
                    //    if (xialiaobf)
                    //    {
                    //        JiTaiDangqian5++;
                    //    }
                    //}

                    //if (shangliaoxj != XinJieOut[22])
                    //{
                    //    shangliaoxj = XinJieOut[22];
                    //    if (shangliaoxj)
                    //    {
                    //        JiTaiDangqian4++;
                    //    }
                    //}
                    //if (xialiaoxj != XinJieOut[23])
                    //{
                    //    xialiaoxj = XinJieOut[23];
                    //    if (xialiaoxj)
                    //    {
                    //        JiTaiDangqian6++;
                    //    }
                    //}

                    if (XinJieOut[24])
                    {
                        SafeDoorAlarmVisibility = "Visible";
                    }
                    else
                    {
                        SafeDoorAlarmVisibility = "Collapsed";
                    }




                    //shangLiaoFlag
                    //if (shangLiaoFlag != (bool)ShangLiaoFlag.Value)
                    //{
                    //    shangLiaoFlag = (bool)ShangLiaoFlag.Value;
                    //    if (shangLiaoFlag)
                    //    {
                    //        liaoCountIN += uint.Parse(ShangLiao.Value.ToString());
                    //        liaoinput += uint.Parse(ShangLiao.Value.ToString());
                    //    }
                    //}

                    XinJieIn[5] = epsonRC90.Rc90Out[6];//Discharing

                    epsonRC90.Rc90In[5] = XinJieOut[40];
                    epsonRC90.Rc90In[6] = XinJieOut[41];
                    epsonRC90.Rc90In[7] = XinJieOut[42];
                    epsonRC90.Rc90In[8] = XinJieOut[43];
                    epsonRC90.Rc90In[9] = XinJieOut[44];
                    epsonRC90.Rc90In[10] = XinJieOut[45];
                    epsonRC90.Rc90In[11] = XinJieOut[46];
                    epsonRC90.Rc90In[12] = XinJieOut[47];

                    XinJieIn[47] = AdminButtonVisibility == "Visible";
                    XinJieIn[46] = !TestCheckedAL || !TestCheckedAR;

                    //XinJieIn[48] = (bool)ProductLostAlarmFlag.Value;

                    down_flag = downtimeflag = EpsonStatusSafeGuard || EpsonStatusEStop;
                    jigdowntimeflag = !TestCheckedAL || !TestCheckedBL || epsonRC90.sIMTester[0].testResult[0] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[1] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[2] == TestResult.TimeOut || epsonRC90.sIMTester[0].testResult[3] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[0] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[1] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[2] == TestResult.TimeOut || epsonRC90.sIMTester[1].testResult[3] == TestResult.TimeOut;
                    waitinput_flag = waitforinputflag = XinJieOut[15] || (!EpsonStatusSafeGuard && EpsonStatusPaused);
                    waittray_flag = waitfortrayflag = XinJieOut[17];
                    waittake_flag = waitfortakeflag = XinJieOut[16];

                    if (testCheckedAL != TestCheckedAL)
                    {
                        testCheckedAL = TestCheckedAL;
                        if (!testCheckedAL)
                        {
                            WriteAlarmCSV_Zhiju(0);
                        }
                    }
                    if (testCheckedBL != TestCheckedBL)
                    {
                        testCheckedBL = TestCheckedBL;
                        if (!testCheckedBL)
                        {
                            WriteAlarmCSV_Zhiju(1);
                        }
                    }
                    Thave_1.Value = epsonRC90.Rc90Out[2];
                    Thave_2.Value = epsonRC90.Rc90Out[3];
                }
                catch(Exception ex)
                {
                    System.Threading.Thread.Sleep(1000);

                }
            }
        }
        [Initialize]
        public void WindowLoaded()
        {
            var r = ReadParameter();
            Xinjie = new ThingetPLC();

            if (r)
            {
                Msg = messagePrint.AddMessage("读取参数成功");
            }
            else
            {
                Msg = messagePrint.AddMessage("读取参数失败");
            }
            string filepath = TestRecordSavePath + "\\" + GetBanci() + ".csv";
            DataTable dt = new DataTable();
            DataTable dt1;
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Barcode", typeof(string));
            dt.Columns.Add("Result", typeof(string));
            dt.Columns.Add("Cycle", typeof(string));
            dt.Columns.Add("Index", typeof(string));
            try
            {
                if (File.Exists(filepath))
                {
                    dt1 = Csvfile.csv2dt(filepath, 1, dt);
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt1.Rows)
                        {
                            TestRecord tr = new TestRecord(item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString());
                            lock (this)
                            {
                                myTestRecordQueue.Enqueue(tr);
                            }
                        }
                        Msg = messagePrint.AddMessage("读取测试记录完成");
                    }
                }
                if (File.Exists("D:\\queliaobarcode.csv"))
                {
                    
                    DataTable _dt = new DataTable();
                    _dt.Columns.Add("BARCODE", typeof(string));
                    DataTable _dt1 = Csvfile.csv2dt("D:\\queliaobarcode.csv", 2, _dt);
                    if (_dt1.Rows.Count > 0)
                    {
                        foreach (DataRow item in _dt1.Rows)
                        {
                            QuiLiaoBarcode qb = new QuiLiaoBarcode();
                            qb.条码 = item[0].ToString();
                            QueLiaoTable1.Add(qb);
                        }
                        Msg = messagePrint.AddMessage("读取掉料条码完成");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Default.Error("WindowLoadedcsv2dt", ex.Message);
            }
            cameraHcInit();
            //await Task.Delay(100);
            System.Threading.Thread.Sleep(100);
            //CameraHcInspect();
            Msg = messagePrint.AddMessage("检测相机初始化完成");
            //ConnectDBTest();
            //epsonRC90.scanCameraInit();
            //await Task.Delay(100);
            //ScanCameraInspect();
            //scanCameraInit();
            //Msg = messagePrint.AddMessage("扫码相机初始化完成");
        }
        [Initialize]
        public void L91PLCWork()
        {
            bool photoCMD = false;
            while (Xinjie == null)
            {
                System.Threading.Thread.Sleep(100);
            }

            while (true)
            {
                System.Threading.Thread.Sleep(10);
                if (Xinjie.ReadSM(0))
                {

                    XinJieOut = Xinjie.ReadMultiMCoil(20000);
                    Xinjie.WritMultiMCoil(20300, XinJiePhotoResult);
                    Xinjie.WritMultiMCoil(20200, XinJieIn);
                    IsPLCConnect = true;
                    if (photoCMD != XinJieOut[0])
                    {
                        photoCMD = XinJieOut[0];
                        if (photoCMD)
                        {
                            Msg = messagePrint.AddMessage("PLC触发拍照");
                            XinJieIn[0] = false;
                            Xinjie.WritMultiMCoil(20200, XinJieIn);
                            Async.RunFuncAsync(cameraHcInspect, PLCTakePhoteCallback);
                        }


                    }

                }
                else
                {
                    IsPLCConnect = false;
                    System.Threading.Thread.Sleep(1000);
                    Xinjie.ModbusDisConnect();
                    Xinjie.ModbusInit(SerialPortCom, 19200, System.IO.Ports.Parity.Even, 8, System.IO.Ports.StopBits.One);
                    Xinjie.ModbusConnect();
                }

                






                

            }
        }
        private void PLCUnLoadCallback()
        {
            WaitPLCUnload.Value = false;
        }
        private void PLCTakePhoteCallback()
        {
            for (int i = 0; i < 80; i++)
            {
                XinJiePhotoResult[i] = _fill[i];
            }
            XinJieIn[0] = true;
        }
        #endregion
        #region 耗材
        //A OK,B超预警，C超限定
        public virtual string HaoCaiOK { set; get; } = "A";
        public async void CalcHaoCai()
        {
            int c = 0;
            bool[] flag = new bool[26];
            while (true)
            {
                await Task.Delay(1000);
                c++;
                try
                {
                    if (c >= 60)
                    {
                        SaveHaoCaiParameter();
                        c = 0;
                    }
                    for (int i = 0; i < 26; i++)
                    {
                        flag[i] = false;
                    }
                    if (ZhiJu1ZuoBupin1 != "")
                    {
                        if (ZhiJu1ZuoDangqian1 > ZhiJu1ZuoYujing1)
                        {
                            flag[0] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin1 + "达到预警值";
                        }
                    }
                    if (ZhiJu1ZuoBupin2 != "")
                    {
                        if (ZhiJu1ZuoDangqian2 > ZhiJu1ZuoYujing2)
                        {
                            flag[1] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin2 + "达到预警值";
                        }
                    }
                    if (ZhiJu1ZuoBupin3 != "")
                    {
                        if (ZhiJu1ZuoDangqian3 > ZhiJu1ZuoYujing3)
                        {
                            flag[2] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin3 + "达到预警值";
                        }
                    }
                    if (ZhiJu1ZuoBupin4 != "")
                    {
                        if (ZhiJu1ZuoDangqian4 > ZhiJu1ZuoYujing4)
                        {
                            flag[3] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin4 + "达到预警值";
                        }
                    }
                    if (ZhiJu1ZuoBupin5 != "")
                    {
                        if (ZhiJu1ZuoDangqian5 > ZhiJu1ZuoYujing5)
                        {
                            flag[4] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin5 + "达到预警值";
                        }
                    }

                    if (ZhiJu1YouBupin1 != "")
                    {
                        if (ZhiJu1YouDangqian1 > ZhiJu1YouYujing1)
                        {
                            flag[5] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin1 + "达到预警值";
                        }
                    }
                    if (ZhiJu1YouBupin2 != "")
                    {
                        if (ZhiJu1YouDangqian2 > ZhiJu1YouYujing2)
                        {
                            flag[6] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin2 + "达到预警值";
                        }
                    }
                    if (ZhiJu1YouBupin3 != "")
                    {
                        if (ZhiJu1YouDangqian3 > ZhiJu1YouYujing3)
                        {
                            flag[7] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin3 + "达到预警值";
                        }
                    }
                    if (ZhiJu1YouBupin4 != "")
                    {
                        if (ZhiJu1YouDangqian4 > ZhiJu1YouYujing4)
                        {
                            flag[8] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin4 + "达到预警值";
                        }
                    }
                    if (ZhiJu1YouBupin5 != "")
                    {
                        if (ZhiJu1YouDangqian5 > ZhiJu1YouYujing5)
                        {
                            flag[9] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin5 + "达到预警值";
                        }
                    }

                    if (ZhiJu2ZuoBupin1 != "")
                    {
                        if (ZhiJu2ZuoDangqian1 > ZhiJu2ZuoYujing1)
                        {
                            flag[10] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin1 + "达到预警值";
                        }
                    }
                    if (ZhiJu2ZuoBupin2 != "")
                    {
                        if (ZhiJu2ZuoDangqian2 > ZhiJu2ZuoYujing2)
                        {
                            flag[11] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin2 + "达到预警值";
                        }
                    }
                    if (ZhiJu2ZuoBupin3 != "")
                    {
                        if (ZhiJu2ZuoDangqian3 > ZhiJu2ZuoYujing3)
                        {
                            flag[12] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin3 + "达到预警值";
                        }
                    }
                    if (ZhiJu2ZuoBupin4 != "")
                    {
                        if (ZhiJu2ZuoDangqian4 > ZhiJu2ZuoYujing4)
                        {
                            flag[13] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin4 + "达到预警值";
                        }
                    }
                    if (ZhiJu2ZuoBupin5 != "")
                    {
                        if (ZhiJu2ZuoDangqian5 > ZhiJu2ZuoYujing5)
                        {
                            flag[14] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin5 + "达到预警值";
                        }
                    }

                    if (ZhiJu2YouBupin1 != "")
                    {
                        if (ZhiJu2YouDangqian1 > ZhiJu2YouYujing1)
                        {
                            flag[15] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin1 + "达到预警值";
                        }
                    }
                    if (ZhiJu2YouBupin2 != "")
                    {
                        if (ZhiJu2YouDangqian2 > ZhiJu2YouYujing2)
                        {
                            flag[16] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin2 + "达到预警值";
                        }
                    }
                    if (ZhiJu2YouBupin3 != "")
                    {
                        if (ZhiJu2YouDangqian3 > ZhiJu2YouYujing3)
                        {
                            flag[17] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin3 + "达到预警值";
                        }
                    }
                    if (ZhiJu2YouBupin4 != "")
                    {
                        if (ZhiJu2YouDangqian4 > ZhiJu2YouYujing4)
                        {
                            flag[18] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin4 + "达到预警值";
                        }
                    }
                    if (ZhiJu2YouBupin5 != "")
                    {
                        if (ZhiJu2YouDangqian5 > ZhiJu2YouYujing5)
                        {
                            flag[19] = true;
                            HaoCaiYuJingBackGroudColor = "Orange";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin5 + "达到预警值";
                        }
                    }


                    if (JiTaiDangqian1 > JiTaiYujing1)
                    {
                        flag[20] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "机械手A爪手吸嘴" + "达到预警值";
                    }
                    if (JiTaiDangqian2 > JiTaiYujing2)
                    {
                        flag[21] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "机械手B爪手吸嘴" + "达到预警值";
                    }
                    if (JiTaiDangqian3 > JiTaiYujing3)
                    {
                        flag[22] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "上料产品吸嘴" + "达到预警值";
                    }
                    if (JiTaiDangqian4 > JiTaiYujing4)
                    {
                        flag[23] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "上料空盘吸嘴" + "达到预警值";
                    }
                    if (JiTaiDangqian5 > JiTaiYujing5)
                    {
                        flag[24] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "下料产品吸嘴" + "达到预警值";
                    }
                    if (JiTaiDangqian6 > JiTaiYujing6)
                    {
                        flag[25] = true;
                        HaoCaiYuJingBackGroudColor = "Orange";
                        HaoCaiYuJingString = "下料空盘吸嘴" + "达到预警值";
                    }

                    if (ZhiJu1ZuoBupin1 != "")
                    {
                        if (ZhiJu1ZuoDangqian1 > ZhiJu1ZuoShouMing1)
                        {
                            flag[0] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin1 + "超过寿命";
                        }
                    }
                    if (ZhiJu1ZuoBupin2 != "")
                    {
                        if (ZhiJu1ZuoDangqian2 > ZhiJu1ZuoShouMing2)
                        {
                            flag[1] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin2 + "超过寿命";
                        }
                    }
                    if (ZhiJu1ZuoBupin3 != "")
                    {
                        if (ZhiJu1ZuoDangqian3 > ZhiJu1ZuoShouMing3)
                        {
                            flag[2] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin3 + "超过寿命";
                        }
                    }
                    if (ZhiJu1ZuoBupin4 != "")
                    {
                        if (ZhiJu1ZuoDangqian4 > ZhiJu1ZuoShouMing4)
                        {
                            flag[3] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin4 + "超过寿命";
                        }
                    }
                    if (ZhiJu1ZuoBupin5 != "")
                    {
                        if (ZhiJu1ZuoDangqian5 > ZhiJu1ZuoShouMing5)
                        {
                            flag[4] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1左穴" + ZhiJu1ZuoBupin5 + "超过寿命";
                        }
                    }

                    if (ZhiJu1YouBupin1 != "")
                    {
                        if (ZhiJu1YouDangqian1 > ZhiJu1YouShouMing1)
                        {
                            flag[5] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin1 + "超过寿命";
                        }
                    }
                    if (ZhiJu1YouBupin2 != "")
                    {
                        if (ZhiJu1YouDangqian2 > ZhiJu1YouShouMing2)
                        {
                            flag[6] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin2 + "超过寿命";
                        }
                    }
                    if (ZhiJu1YouBupin3 != "")
                    {
                        if (ZhiJu1YouDangqian3 > ZhiJu1YouShouMing3)
                        {
                            flag[7] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin3 + "超过寿命";
                        }
                    }
                    if (ZhiJu1YouBupin4 != "")
                    {
                        if (ZhiJu1YouDangqian4 > ZhiJu1YouShouMing4)
                        {
                            flag[8] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin4 + "超过寿命";
                        }
                    }
                    if (ZhiJu1YouBupin5 != "")
                    {
                        if (ZhiJu1YouDangqian5 > ZhiJu1YouShouMing5)
                        {
                            flag[9] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具1右穴" + ZhiJu1YouBupin5 + "超过寿命";
                        }
                    }

                    if (ZhiJu2ZuoBupin1 != "")
                    {
                        if (ZhiJu2ZuoDangqian1 > ZhiJu2ZuoShouMing1)
                        {
                            flag[10] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin1 + "超过寿命";
                        }
                    }
                    if (ZhiJu2ZuoBupin2 != "")
                    {
                        if (ZhiJu2ZuoDangqian2 > ZhiJu2ZuoShouMing2)
                        {
                            flag[11] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin2 + "超过寿命";
                        }
                    }
                    if (ZhiJu2ZuoBupin3 != "")
                    {
                        if (ZhiJu2ZuoDangqian3 > ZhiJu2ZuoShouMing3)
                        {
                            flag[12] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin3 + "超过寿命";
                        }
                    }
                    if (ZhiJu2ZuoBupin4 != "")
                    {
                        if (ZhiJu2ZuoDangqian4 > ZhiJu2ZuoShouMing4)
                        {
                            flag[13] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin4 + "超过寿命";
                        }
                    }
                    if (ZhiJu2ZuoBupin5 != "")
                    {
                        if (ZhiJu2ZuoDangqian5 > ZhiJu2ZuoShouMing5)
                        {
                            flag[14] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2左穴" + ZhiJu2ZuoBupin5 + "超过寿命";
                        }
                    }

                    if (ZhiJu2YouBupin1 != "")
                    {
                        if (ZhiJu2YouDangqian1 > ZhiJu2YouShouMing1)
                        {
                            flag[15] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin1 + "超过寿命";
                        }
                    }
                    if (ZhiJu2YouBupin2 != "")
                    {
                        if (ZhiJu2YouDangqian2 > ZhiJu2YouShouMing2)
                        {
                            flag[16] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin2 + "超过寿命";
                        }
                    }
                    if (ZhiJu2YouBupin3 != "")
                    {
                        if (ZhiJu2YouDangqian3 > ZhiJu2YouShouMing3)
                        {
                            flag[17] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin3 + "超过寿命";
                        }
                    }
                    if (ZhiJu2YouBupin4 != "")
                    {
                        if (ZhiJu2YouDangqian4 > ZhiJu2YouShouMing4)
                        {
                            flag[18] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin4 + "超过寿命";
                        }
                    }
                    if (ZhiJu2YouBupin5 != "")
                    {
                        if (ZhiJu2YouDangqian5 > ZhiJu2YouShouMing5)
                        {
                            flag[19] = true;
                            HaoCaiYuJingBackGroudColor = "Red";
                            HaoCaiYuJingString = "治具2右穴" + ZhiJu2YouBupin5 + "超过寿命";
                        }
                    }


                    if (JiTaiDangqian1 > JiTaiShouMing1)
                    {
                        flag[20] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "机械手A爪手吸嘴" + "超过寿命";
                    }
                    if (JiTaiDangqian2 > JiTaiShouMing2)
                    {
                        flag[21] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "机械手B爪手吸嘴" + "超过寿命";
                    }
                    if (JiTaiDangqian3 > JiTaiShouMing3)
                    {
                        flag[22] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "上料产品吸嘴" + "超过寿命";
                    }
                    if (JiTaiDangqian4 > JiTaiShouMing4)
                    {
                        flag[23] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "上料空盘吸嘴" + "超过寿命";
                    }
                    if (JiTaiDangqian5 > JiTaiShouMing5)
                    {
                        flag[24] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "下料产品吸嘴" + "超过寿命";
                    }
                    if (JiTaiDangqian6 > JiTaiShouMing6)
                    {
                        flag[25] = true;
                        HaoCaiYuJingBackGroudColor = "Red";
                        HaoCaiYuJingString = "下料空盘吸嘴" + "超过寿命";
                    }

                    for (int i = 0; i < 26; i++)
                    {
                        if (flag[i])
                        {
                            HaoCaiYuJingGridShow = "Visible";
                            if (HaoCaiYuJingBackGroudColor == "Red")
                            {
                                HaoCaiOK = "C";
                            }
                            else
                            {
                                if (HaoCaiYuJingBackGroudColor == "Orange")
                                {
                                    HaoCaiOK = "B";
                                }
                            }
                            break;
                        }
                        if (i == 25)
                        {
                            if (!flag[25])
                            {
                                HaoCaiYuJingGridShow = "Collapsed";
                                HaoCaiOK = "A";
                            }

                        }
                    }

                }
                catch
                {
                    HaoCaiYuJingGridShow = "Visible";
                    HaoCaiYuJingBackGroudColor = "Gray";
                    HaoCaiYuJingString = "数值异常";
                    HaoCaiOK = "C";
                }
            }
        }


        public async void Clear1(object p)
        {
            switch (p.ToString())
            {
                case "0":
                    if (ZhiJu1ZuoBupin1 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu1ZuoBupin1 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1ZuoDangqian1 = 0;
                            SaveHaoCaiParameter();
                        }
                            
                    }
                    break;
                case "1":
                    if (ZhiJu1ZuoBupin2 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu1ZuoBupin2 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1ZuoDangqian2 = 0;
                            SaveHaoCaiParameter();
                        }
                            
                    }
                    break;
                case "2":
                    if (ZhiJu1ZuoBupin3 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu1ZuoBupin3 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1ZuoDangqian3 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "3":
                    if (ZhiJu1ZuoBupin4 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu1ZuoBupin4 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1ZuoDangqian4 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "4":
                    if (ZhiJu1ZuoBupin5 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu1ZuoBupin5 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1ZuoDangqian5 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "5":
                    if (ZhiJu1YouBupin1 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu1YouBupin1 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1YouDangqian1 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "6":
                    if (ZhiJu1YouBupin2 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu1YouBupin2 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1YouDangqian2 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "7":
                    if (ZhiJu1YouBupin3 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu1YouBupin3 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1YouDangqian3 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "8":
                    if (ZhiJu1YouBupin4 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu1YouBupin4 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1YouDangqian4 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "9":
                    if (ZhiJu1YouBupin5 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu1YouBupin5 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu1YouDangqian5 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;

                case "10":
                    if (ZhiJu2ZuoBupin1 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具2左穴" + ZhiJu2ZuoBupin1 + " ？请小心操作！");
                        if (r)
                    
                        {
                            ZhiJu2ZuoDangqian1 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "11":
                    if (ZhiJu2ZuoBupin2 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu2ZuoBupin2 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2ZuoDangqian2 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "12":
                    if (ZhiJu2ZuoBupin3 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu2ZuoBupin3 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2ZuoDangqian3 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "13":
                    if (ZhiJu2ZuoBupin4 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu2ZuoBupin4 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2ZuoDangqian4 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "14":
                    if (ZhiJu2ZuoBupin5 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1左穴" + ZhiJu2ZuoBupin5 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2ZuoDangqian5 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "15":
                    if (ZhiJu2YouBupin1 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu2YouBupin1 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2YouDangqian1 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "16":
                    if (ZhiJu2YouBupin2 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu2YouBupin2 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2YouDangqian2 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "17":
                    if (ZhiJu2YouBupin3 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu2YouBupin3 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2YouDangqian3 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "18":
                    if (ZhiJu2YouBupin4 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu2YouBupin4 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2YouDangqian4 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "19":
                    if (ZhiJu2YouBupin5 != "")
                    {
                        var r = await mydialog.showconfirm("确定更换 治具1右穴" + ZhiJu2YouBupin5 + " ？请小心操作！");
                        if (r)
                        {
                            ZhiJu2YouDangqian5 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "20":
                    {
                        var r = await mydialog.showconfirm("确定更换 A爪手吸嘴 " + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian1 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }
                    break;
                case "21":
                    {
                        var r = await mydialog.showconfirm("确定更换 B爪手吸嘴 " + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian2 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }

                    break;
                case "22":
                    {
                        var r = await mydialog.showconfirm("确定更换 上料产品吸嘴 " + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian3 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }

                    break;
                case "23":
                    {
                        var r = await mydialog.showconfirm("确定更换 上料空盘吸嘴 " + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian4 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }

                    break;
                case "24":
                    {
                        var r = await mydialog.showconfirm("确定更换 下料产品吸嘴 " + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian5 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }

                    break;
                case "25":
                    {
                        var r = await mydialog.showconfirm("下料空盘吸嘴" + "？请小心操作！");
                        if (r)
                        {
                            JiTaiDangqian6 = 0;
                            SaveHaoCaiParameter();
                        }
                        
                    }

                    break;
                default:
                    break;
            }

        }


        public void SaveHaoCaiParameter()
        {
            try
            {
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin1", ZhiJu1ZuoBupin1);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin2", ZhiJu1ZuoBupin2);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin3", ZhiJu1ZuoBupin3);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin4", ZhiJu1ZuoBupin4);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoBupin5", ZhiJu1ZuoBupin5);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian1", ZhiJu1ZuoDangqian1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian2", ZhiJu1ZuoDangqian2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian3", ZhiJu1ZuoDangqian3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian4", ZhiJu1ZuoDangqian4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoDangqian5", ZhiJu1ZuoDangqian5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing1", ZhiJu1ZuoShouMing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing2", ZhiJu1ZuoShouMing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing3", ZhiJu1ZuoShouMing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing4", ZhiJu1ZuoShouMing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoShouMing5", ZhiJu1ZuoShouMing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing1", ZhiJu1ZuoYujing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing2", ZhiJu1ZuoYujing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing3", ZhiJu1ZuoYujing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing4", ZhiJu1ZuoYujing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1ZuoYujing5", ZhiJu1ZuoYujing5.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin1", ZhiJu2ZuoBupin1);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin2", ZhiJu2ZuoBupin2);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin3", ZhiJu2ZuoBupin3);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin4", ZhiJu2ZuoBupin4);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoBupin5", ZhiJu2ZuoBupin5);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian1", ZhiJu2ZuoDangqian1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian2", ZhiJu2ZuoDangqian2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian3", ZhiJu2ZuoDangqian3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian4", ZhiJu2ZuoDangqian4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoDangqian5", ZhiJu2ZuoDangqian5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing1", ZhiJu2ZuoShouMing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing2", ZhiJu2ZuoShouMing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing3", ZhiJu2ZuoShouMing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing4", ZhiJu2ZuoShouMing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoShouMing5", ZhiJu2ZuoShouMing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing1", ZhiJu2ZuoYujing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing2", ZhiJu2ZuoYujing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing3", ZhiJu2ZuoYujing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing4", ZhiJu2ZuoYujing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2ZuoYujing5", ZhiJu2ZuoYujing5.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin1", ZhiJu1YouBupin1);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin2", ZhiJu1YouBupin2);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin3", ZhiJu1YouBupin3);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin4", ZhiJu1YouBupin4);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouBupin5", ZhiJu1YouBupin5);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian1", ZhiJu1YouDangqian1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian2", ZhiJu1YouDangqian2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian3", ZhiJu1YouDangqian3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian4", ZhiJu1YouDangqian4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouDangqian5", ZhiJu1YouDangqian5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing1", ZhiJu1YouShouMing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing2", ZhiJu1YouShouMing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing3", ZhiJu1YouShouMing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing4", ZhiJu1YouShouMing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouShouMing5", ZhiJu1YouShouMing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing1", ZhiJu1YouYujing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing2", ZhiJu1YouYujing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing3", ZhiJu1YouYujing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing4", ZhiJu1YouYujing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu1YouYujing5", ZhiJu1YouYujing5.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin1", ZhiJu2YouBupin1);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin2", ZhiJu2YouBupin2);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin3", ZhiJu2YouBupin3);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin4", ZhiJu2YouBupin4);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouBupin5", ZhiJu2YouBupin5);
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian1", ZhiJu2YouDangqian1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian2", ZhiJu2YouDangqian2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian3", ZhiJu2YouDangqian3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian4", ZhiJu2YouDangqian4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouDangqian5", ZhiJu2YouDangqian5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing1", ZhiJu2YouShouMing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing2", ZhiJu2YouShouMing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing3", ZhiJu2YouShouMing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing4", ZhiJu2YouShouMing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouShouMing5", ZhiJu2YouShouMing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing1", ZhiJu2YouYujing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing2", ZhiJu2YouYujing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing3", ZhiJu2YouYujing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing4", ZhiJu2YouYujing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "ZhiJu2YouYujing5", ZhiJu2YouYujing5.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian1", JiTaiDangqian1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian2", JiTaiDangqian2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian3", JiTaiDangqian3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian4", JiTaiDangqian4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian5", JiTaiDangqian5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiDangqian6", JiTaiDangqian6.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing1", JiTaiShouMing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing2", JiTaiShouMing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing3", JiTaiShouMing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing4", JiTaiShouMing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing5", JiTaiShouMing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiShouMing6", JiTaiShouMing6.ToString());

                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing1", JiTaiYujing1.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing2", JiTaiYujing2.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing3", JiTaiYujing3.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing4", JiTaiYujing4.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing5", JiTaiYujing5.ToString());
                Inifile.INIWriteValue(iniParameterPath, "HaoCai", "JiTaiYujing6", JiTaiYujing6.ToString());
            }
            catch { }
        }
        #endregion
    }
    public class X758SamCheckinData
    {
        public string Partnum { set; get; }
        public string Barcode { set; get; }
        public uint Stnum { set; get; }
        public uint Unum { set; get; }
        public string Ngitem { set; get; }
    }
    public class X758SampleResultData
    {
        public string PARTNUM { set; get; }
        public string SITEM { set; get; }
        public string BARCODE { set; get; }
        public string NGITEM { set; get; }
        public string TRES { set; get; }
        public string MNO { set; get; }
        public string CDATE { set; get; }
        public string CTIME { set; get; }
        //控制板ID
        public string SR01 { set; get; }
        public string FL02 { set; get; }
        public string FL03 { set; get; }
    }
    public class AlarmRecord
    {
        public string AlarmTime { set; get; }
        public string AlarmString { set; get; }
    }
    public class AlarmTableItem
    {
        public string Station { set; get; }
        public ushort SuckFail { set; get; }
        public ushort ReleaseFail { set; get; }
        //public ushort 测试机超时 { set; get; }
        //public ushort 连续NG { set; get; }
        public AlarmTableItem(string position)
        {
            Station = position;
            SuckFail = 0;
            ReleaseFail = 0;
            //测试机超时 = 0;
            //连续NG = 0;
        }








    }

}