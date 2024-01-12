using System.Windows;
using System.Windows.Controls;

namespace Wpf.Dp.HelloWorld.Controls;

public partial class Widget : UserControl
{
    public Widget()
    {
        InitializeComponent();
        // 由于依赖属性天生具有属性通知功能，所以我们不必去实现INotifyPropertyChanged接口，
        // 只需要将当前类做为ViewModel传给Widget的DataContent，前端的控件就可以绑定Value、Title、Icon三个属性了。
        DataContext = this;
    }

    #region Custom Dependency Property

    /// <summary>
    /// 图标
    /// </summary>
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(string), typeof(Widget), new PropertyMetadata("🙂")
    );

    /// <summary>
    /// 标题
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(Widget), new PropertyMetadata("请输入标题")
    );

    /// <summary>
    /// 内容
    /// </summary>
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value), typeof(string), typeof(Widget), new PropertyMetadata("请输入内容")
    );

    #endregion
}