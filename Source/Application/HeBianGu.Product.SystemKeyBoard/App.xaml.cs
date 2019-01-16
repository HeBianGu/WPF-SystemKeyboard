using HeBianGu.Product.UserControls.SystemKeyBoard;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.Product.SystemKeyBoard
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            KeyBoardWindow keyBoardWindow = new KeyBoardWindow();
            keyBoardWindow.Show();

            InputNumWindow inputNumWindow = new InputNumWindow();
            inputNumWindow.Show();
        }
    }
}
