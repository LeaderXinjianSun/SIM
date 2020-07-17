using System;
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
    /// DiaoLiaoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DiaoLiaoWindow 
    {
        public DiaoLiaoWindow()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty QuitDiaoLiaoWindowProperty =
            DependencyProperty.Register("QuitDiaoLiaoWindow", typeof(bool), typeof(DiaoLiaoWindow), new PropertyMetadata(
            new PropertyChangedCallback((d, e) =>
            {
                var mDiaoLiaoWindow = d as DiaoLiaoWindow;
                if (mDiaoLiaoWindow.HasShow)
                {
                    mDiaoLiaoWindow.HasShow = false;
                    mDiaoLiaoWindow.Close();
                    mDiaoLiaoWindow = null;
                }
            })));
        public bool QuitDiaoLiaoWindow
        {
            get { return (bool)GetValue(QuitDiaoLiaoWindowProperty); }
            set { SetValue(QuitDiaoLiaoWindowProperty, value); }
        }
        public bool HasShow { get; set; }
        protected override void OnClosed(EventArgs e)
        {
            HasShow = false;
            base.OnClosed(e);
        }
    }
}
