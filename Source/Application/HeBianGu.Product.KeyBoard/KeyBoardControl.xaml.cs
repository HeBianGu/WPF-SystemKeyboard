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
    public partial class KeyBoardControl : UserControl
    {
        public KeyBoardControl()
        {
            InitializeComponent();


            this.btn_caps.IsChecked = Console.CapsLock;

            this.RefreshCaps();
        }

        void RefreshCapsText()
        {
            if (this.btn_caps.IsChecked)
            {
                this.btn_caps.Content = "大写";
            }
            else
            {
                this.btn_caps.Content = "小写";
            }
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

                //// Do ：打开大写 
                if (this.btn_shift.IsChecked)
                {
                    KeyHelper.OnKeyDown(Convert.ToByte(this.btn_shift.Tag.ToString()));
                }

                if (this.btn_shift.IsChecked)
                {
                    KeyHelper.OnKeyDown(Convert.ToByte(this.btn_shift.Tag.ToString()));
                }


                string tag = button.Tag.ToString(); 

                byte b = Convert.ToByte(tag);

                KeyHelper.OnKeyPress(b); 
            }
        }

        //声明和注册路由事件
        public static readonly RoutedEvent SumitClickRoutedEvent =
            EventManager.RegisterRoutedEvent("SumitClick", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(KeyBoardControl));
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
            EventManager.RegisterRoutedEvent("CancelClick", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(KeyBoardControl));
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
            DependencyProperty.Register("InputText", typeof(string), typeof(KeyBoardControl), new PropertyMetadata(default(string), (d, e) =>
             {
                 KeyBoardControl control = d as KeyBoardControl;

                 if (control == null) return;

                 string config = e.NewValue as string;

                 control.txt_input.Text = config;

             }));

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            FuncButtonControl btn = sender as FuncButtonControl;

            string tag = btn.Tag.ToString();

            byte b = Convert.ToByte(tag);

            if (btn.IsChecked)
            {
                KeyHelper.OnKeyUp(b);
            }
            else
            {
                KeyHelper.OnKeyDown(b);
            }

            btn.IsChecked = !btn.IsChecked;

        }

        void RefreshCaps()
        {


            var btns = FindVisualChild<FuncButtonControl>(this.grid_center);

            foreach (var btn in btns)
            {
                if (btn.Content == null) continue;

                if (btn.Content.ToString().Length != 1) continue;

                btn.Content = this.btn_caps.IsChecked ? btn.Content.ToString().ToUpper() : btn.Content.ToString().ToLower();

            }

            this.RefreshCapsText();

        }

        List<T> FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            List<T> collecion = new List<T>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is T)
                    collecion.Add((T)child);
                else
                {
                    collecion.AddRange(FindVisualChild<T>(child));
                }
            }

            return collecion;
        }

        private void btn_caps_Click(object sender, RoutedEventArgs e)
        {
            FuncButtonControl btn = sender as FuncButtonControl;

            string tag = btn.Tag.ToString();

            byte b = Convert.ToByte(tag);

            KeyHelper.OnKeyDown(b);

            btn.IsChecked = !btn.IsChecked; 

            this.RefreshCaps();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.OnCancelClick();
        }
    }


}
