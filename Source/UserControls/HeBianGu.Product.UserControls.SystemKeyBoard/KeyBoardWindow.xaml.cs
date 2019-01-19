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

            this.Loaded += KeyBoardWindow_Loaded;
        }

        public static KeyBoardWindow Instance = new KeyBoardWindow();

        public static void ShowDefault()
        {
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
