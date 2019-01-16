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
using System.Windows.Shapes;

namespace HeBianGu.Product.UserControls.SystemKeyBoard
{
    /// <summary>
    /// KeyBoardWindow.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoardWindow : Window
    {
        public KeyBoardWindow()
        {
            InitializeComponent();
        }

        private void KeyBoardControl_SumitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KeyBoardControl_CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
