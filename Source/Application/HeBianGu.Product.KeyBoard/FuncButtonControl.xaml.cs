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

namespace HeBianGu.Product.UserControls.SystemKeyBoard
{
    /// <summary>
    /// FuncButtonControl.xaml 的交互逻辑
    /// </summary>
    public partial class FuncButtonControl : Button
    {
        static FuncButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FuncButtonControl), new FrameworkPropertyMetadata(typeof(FuncButtonControl)));
        }

        #region - 依赖属性 -


        public string CheckedText
        {
            get { return (string)GetValue(CheckedTextProperty); }
            set { SetValue(CheckedTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedTextProperty =
            DependencyProperty.Register("CheckedText", typeof(string), typeof(FuncButtonControl), new PropertyMetadata(default(string), (d, e) =>
             {
                 FuncButtonControl control = d as FuncButtonControl;

                 if (control == null) return;

                 string config = e.NewValue as string;

             }));


        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(FuncButtonControl), new PropertyMetadata(Brushes.DarkBlue));
        /// <summary> 鼠标按下背景样式 </summary>
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(FuncButtonControl), new PropertyMetadata(Brushes.White));
        /// <summary> 鼠标按下前景样式（图标、文字） </summary>
        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(FuncButtonControl), new PropertyMetadata(Brushes.RoyalBlue));
        /// <summary> 鼠标进入背景样式 </summary>
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(FuncButtonControl), new PropertyMetadata(Brushes.White));
        /// <summary> 鼠标进入前景样式 </summary>
        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty FIconProperty =
            DependencyProperty.Register("FIcon", typeof(string), typeof(FuncButtonControl), new PropertyMetadata("\xe607"));
        /// <summary> 按钮字体图标编码 </summary>
        public string FIcon
        {
            get { return (string)GetValue(FIconProperty); }
            set { SetValue(FIconProperty, value); }
        }

        public static readonly DependencyProperty FIconSizeProperty =
            DependencyProperty.Register("FIconSize", typeof(int), typeof(FuncButtonControl), new PropertyMetadata(20));
        /// <summary> 按钮字体图标大小 </summary>
        public int FIconSize
        {
            get { return (int)GetValue(FIconSizeProperty); }
            set { SetValue(FIconSizeProperty, value); }
        }

        public static readonly DependencyProperty FIconMarginProperty = DependencyProperty.Register(
            "FIconMargin", typeof(Thickness), typeof(FuncButtonControl), new PropertyMetadata(new Thickness(0, 1, 3, 1)));
        /// <summary> 字体图标间距 </summary>
        public Thickness FIconMargin
        {
            get { return (Thickness)GetValue(FIconMarginProperty); }
            set { SetValue(FIconMarginProperty, value); }
        }

        public static readonly DependencyProperty AllowsAnimationProperty = DependencyProperty.Register(
            "AllowsAnimation", typeof(bool), typeof(FuncButtonControl), new PropertyMetadata(true));
        /// <summary> 是否启用Ficon动画 </summary>
        public bool AllowsAnimation
        {
            get { return (bool)GetValue(AllowsAnimationProperty); }
            set { SetValue(AllowsAnimationProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FuncButtonControl), new PropertyMetadata(new CornerRadius(2)));
        /// <summary> 按钮圆角大小,左上，右上，右下，左下 </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty ContentDecorationsProperty = DependencyProperty.Register(
            "ContentDecorations", typeof(TextDecorationCollection), typeof(FuncButtonControl), new PropertyMetadata(null));
        public TextDecorationCollection ContentDecorations
        {
            get { return (TextDecorationCollection)GetValue(ContentDecorationsProperty); }
            set { SetValue(ContentDecorationsProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(FuncButtonControl), new PropertyMetadata(Orientation.Vertical));

        /// <summary> 图标和文字的布局方式 </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(FuncButtonControl), new PropertyMetadata(false));
        /// <summary> 按钮是否被选中 </summary>
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }


        public static readonly DependencyProperty IconFontWeightProperty = DependencyProperty.Register("IconFontWeight", typeof(FontWeight), typeof(FuncButtonControl), new PropertyMetadata(null));
        /// <summary> 按钮字体图标编码 </summary>
        public FontWeight IconFontWeight
        {
            get { return (FontWeight)GetValue(IconFontWeightProperty); }
            set { SetValue(IconFontWeightProperty, value); }
        }



        public string ShiftValue
        {
            get { return (string)GetValue(ShiftValueProperty); }
            set { SetValue(ShiftValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShiftValueProperty =
            DependencyProperty.Register("ShiftValue", typeof(string), typeof(FuncButtonControl), new PropertyMetadata(default(string), (d, e) =>
             {
                 FuncButtonControl control = d as FuncButtonControl;

                 if (control == null) return;

                 string config = e.NewValue as string;

             }));



        public bool IsCheckedControl
        {
            get { return (bool)GetValue(IsCheckedControlProperty); }
            set { SetValue(IsCheckedControlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedControlProperty =
            DependencyProperty.Register("IsCheckedControl", typeof(bool), typeof(FuncButtonControl), new PropertyMetadata(default(bool), (d, e) =>
             {
                 FuncButtonControl control = d as FuncButtonControl;

                 if (control == null) return;

                 //bool config = e.NewValue as bool;

             }));

        //public FuncButtonControl()
        //{
        //    this.Click +=(l, k) =>
        //     {
        //         if(this.IsCheckedControl)
        //         {
        //             this.IsChecked = !this.IsChecked;
        //         }
 
        //     };
        //}

        #endregion
    }
}
