﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Omicron.View
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        public MainWindowView()
        {
            InitializeComponent();
            this.SetBinding(ShowSampleTestWindowProperty, "ShowSampleTestWindow");
            this.SetBinding(ShowYieldAdminControlWindowProperty, "ShowYieldAdminControlWindow");
            this.SetBinding(ShowDiaoLiaoWindowProperty, "ShowDiaoLiaoWindow");
        }
        public static SampleTestWindow SampleTestWindow = null;

        public static readonly DependencyProperty ShowSampleTestWindowProperty =
            DependencyProperty.Register("ShowSampleTestWindow", typeof(bool), typeof(MainWindowView), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (SampleTestWindow != null)
                    {
                        if (SampleTestWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindowView;
                    SampleTestWindow = new SampleTestWindow();// { Owner = this }.Show();
                    SampleTestWindow.Owner = Application.Current.MainWindow;
                    SampleTestWindow.DataContext = mMainWindow.DataContext;
                    SampleTestWindow.SetBinding(SampleTestWindow.QuitSampleTestProperty, "QuitSampleTest");
                    SampleTestWindow.HasShow = true;
                    SampleTestWindow.Show();
                })));
        public bool ShowSampleTestWindow
        {
            get { return (bool)GetValue(ShowSampleTestWindowProperty); }
            set { SetValue(ShowSampleTestWindowProperty, value); }
        }

        public static YieldAdminControlWindow YieldAdminControlWindow = null;

        public static readonly DependencyProperty ShowYieldAdminControlWindowProperty =
            DependencyProperty.Register("ShowYieldAdminControlWindow", typeof(bool), typeof(MainWindowView), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (YieldAdminControlWindow != null)
                    {
                        if (YieldAdminControlWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindowView;
                    YieldAdminControlWindow = new YieldAdminControlWindow();// { Owner = this }.Show();
                    YieldAdminControlWindow.Owner = Application.Current.MainWindow;
                    YieldAdminControlWindow.DataContext = mMainWindow.DataContext;
                    YieldAdminControlWindow.SetBinding(YieldAdminControlWindow.QuitYieldAdminControlProperty, "QuitYieldAdminControl");
                    YieldAdminControlWindow.HasShow = true;
                    YieldAdminControlWindow.Show();
                })));
        public bool ShowYieldAdminControlWindow
        {
            get { return (bool)GetValue(ShowYieldAdminControlWindowProperty); }
            set { SetValue(ShowYieldAdminControlWindowProperty, value); }
        }

        public static DiaoLiaoWindow DiaoLiaoWindow = null;

        public static readonly DependencyProperty ShowDiaoLiaoWindowProperty =
            DependencyProperty.Register("ShowDiaoLiaoWindow", typeof(bool), typeof(MainWindowView), new PropertyMetadata(
                new PropertyChangedCallback((d, e) =>
                {
                    if (DiaoLiaoWindow != null)
                    {
                        if (DiaoLiaoWindow.HasShow)
                            return;
                    }
                    var mMainWindow = d as MainWindowView;
                    DiaoLiaoWindow = new DiaoLiaoWindow();// { Owner = this }.Show();
                    DiaoLiaoWindow.Owner = Application.Current.MainWindow;
                    DiaoLiaoWindow.DataContext = mMainWindow.DataContext;
                    DiaoLiaoWindow.SetBinding(DiaoLiaoWindow.QuitDiaoLiaoWindowProperty, "QuitDiaoLiaoWindow");
                    DiaoLiaoWindow.HasShow = true;
                    DiaoLiaoWindow.Show();
                })));
        public bool ShowDiaoLiaoWindow
        {
            get { return (bool)GetValue(ShowDiaoLiaoWindowProperty); }
            set { SetValue(ShowDiaoLiaoWindowProperty, value); }
        }
    }
}
