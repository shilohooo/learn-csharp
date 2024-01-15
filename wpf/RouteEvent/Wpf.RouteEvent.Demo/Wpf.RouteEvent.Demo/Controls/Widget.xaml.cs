using System.Windows;
using System.Windows.Controls;

namespace Wpf.RouteEvent.Demo.Controls;

public partial class Widget : UserControl
{
    public Widget()
    {
        InitializeComponent();
        // 由于依赖属性天生具有属性通知功能，所以我们不必去实现INotifyPropertyChanged接口，
        // 只需要将当前类做为ViewModel传给Widget的DataContent，前端的控件就可以绑定Value、Title、Icon三个属性了。
        DataContext = this;
    }

    #region RoutedEvents

    /// <summary>
    /// 注册路由事件
    /// </summary>
    public static readonly RoutedEvent CompletedEvent = EventManager.RegisterRoutedEvent(
        "CompletedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Widget)
    );

    /// <summary>
    /// 将路由事件包装为一个普通的事件
    /// </summary>
    public event RoutedEventHandler Completed
    {
        add => AddHandler(CompletedEvent, value);
        remove => RemoveHandler(CompletedEvent, value);
    }

    #endregion

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
    /// 目标
    /// </summary>
    public double Target
    {
        get => (double)GetValue(TargetProperty);
        set => SetValue(TargetProperty, value);
    }

    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
        nameof(Target), typeof(double), typeof(Widget), new PropertyMetadata(null)
    );

    /// <summary>
    /// 内容
    /// </summary>
    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value), typeof(double), typeof(Widget), new PropertyMetadata(0.0, OnValuePropertyChangedCallback)
    );

    /// <summary>
    /// Value 变更回调
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void OnValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Widget widget || e.NewValue is not double newValue)
        {
            return;
        }

        if (newValue >= widget.Target && widget.Target != 0)
        {
            widget.Icon = "😍";
            // 触发路由事件
            widget.RaiseCompletedEvent();
            return;
        }

        widget.Icon = "💕";
    }

    #endregion

    #region PublicMethods

    /// <summary>
    /// 触发路由事件
    /// </summary>
    public void RaiseCompletedEvent()
    {
        RaiseEvent(new RoutedEventArgs(CompletedEvent, this));
    }

    #endregion
}