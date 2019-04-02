using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace HeBianGu.Product.UserControls.SystemKeyBoard
{
    /// <summary>
    /// InputNumControl.xaml 的交互逻辑
    /// </summary>
    public partial class InputNumControl : UserControl
    {
        public InputNumControl()
        {
            InitializeComponent();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;

            if (button == null) return;

            Debug.WriteLine(button.Content);

            string content = button.Content.ToString();

            if (content == "确定")
            {
                this.OnSumitClick();
            }
            else if (content == "取消")
            {
                this.OnCancelClick();
            }
            else
            {

                string tag = button.Tag.ToString();

                this.txt_input.Focus();

                byte b = Convert.ToByte(tag);

                KeyHelper.OnKeyPress(b);

                KeyHelper.OnKeyPress(13);
            }
        }


        //声明和注册路由事件
        public static readonly RoutedEvent SumitClickRoutedEvent =
            EventManager.RegisterRoutedEvent("SumitClick", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(InputNumControl));
        //CLR事件包装
        public event RoutedEventHandler SumitClick
        {
            add { this.AddHandler(SumitClickRoutedEvent, value); }
            remove { this.RemoveHandler(SumitClickRoutedEvent, value); }
        }

        //激发路由事件,借用Click事件的激发方法

        protected void OnSumitClick()
        {
            RoutedEventArgs args = new RoutedEventArgs(SumitClickRoutedEvent, this);
            this.RaiseEvent(args);
        }


        //声明和注册路由事件
        public static readonly RoutedEvent CancelClickRoutedEvent =
            EventManager.RegisterRoutedEvent("CancelClick", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(InputNumControl));
        //CLR事件包装
        public event RoutedEventHandler CancelClick
        {
            add { this.AddHandler(CancelClickRoutedEvent, value); }
            remove { this.RemoveHandler(CancelClickRoutedEvent, value); }
        }

        //激发路由事件,借用Click事件的激发方法

        protected void OnCancelClick()
        {
            RoutedEventArgs args = new RoutedEventArgs(CancelClickRoutedEvent, this);
            this.RaiseEvent(args);
        }



        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputTextProperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(InputNumControl), new PropertyMetadata(default(string), (d, e) =>
             {
                 InputNumControl control = d as InputNumControl;

                 if (control == null) return;

                 string config = e.NewValue as string;

                 control.txt_input.Text = config;

             }));




    }
    
}
