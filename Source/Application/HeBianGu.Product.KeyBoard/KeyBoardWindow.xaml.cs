using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HeBianGu.Product.UserControls.SystemKeyBoard
{
    /// <summary>
    /// KeyBoardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoardWindow : Window
    {
        KeyBoardWindow()
        {
            InitializeComponent();

            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度

            //this.WindowState = WindowState.Normal;

            double param = y1 / 3;

            this.Width = x1;//设置窗体宽度

            this.Height = param;//设置窗体高度

            double screeHeight = SystemParameters.FullPrimaryScreenHeight;

            double screeWidth = SystemParameters.FullPrimaryScreenWidth;

            this.Top = y1 - this.Height;

            this.Left = (x1 - this.Width) / 2;


            this.Loaded += KeyBoardWindow_Loaded;
        }

        public static KeyBoardWindow Instance = new KeyBoardWindow();


        Action _closeClick;
        public static void ShowDefault(Action closeClick=null)
        {

            Instance._closeClick = closeClick;

            Instance.Show();


        }

        public static void HideDefault()
        {
            Instance.Hide();
        }

        private void KeyBoardWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);

            IntPtr intPtr = windowInteropHelper.Handle;

            int value = -20;

            SetWindowLong(intPtr, value, (IntPtr)0x8000000);
        }

        private void KeyBoardControl_SumitClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void KeyBoardControl_CancelClick(object sender, RoutedEventArgs e)
        {
            this.Hide();

            if (_closeClick != null)
            {
                _closeClick();
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }



        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nindex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 GetWindowLong(IntPtr hWnd, int index);
    }
}
