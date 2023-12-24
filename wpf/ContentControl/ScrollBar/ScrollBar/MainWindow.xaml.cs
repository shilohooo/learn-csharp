using System.ComponentModel;
using System.Windows;

namespace ScrollBar;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public MainWindow()
    {
        InitializeComponent();
        // 将当前窗体作为 ViewModel 赋值给当前窗体的 DataContext
        DataContext = this;
        // 加载完成后计算滚动条的最大值
        Loaded += (_, _) =>
        {
            // 滚动条最大值 = 元素宽度 - 可视区域宽度
            Console.WriteLine($"Element Width: {Element.ActualWidth}, Viewport Width: {Viewport.ActualWidth}");
            ScrollBarMaximum = Element.ActualWidth - Viewport.ActualWidth;
            Console.WriteLine($"ScrollBar Maximum: {ScrollBarMaximum}");
        };
    }

    private double _scrollBarMaximum;

    /// <summary>
    /// 滚动条的最大值
    /// </summary>
    public double ScrollBarMaximum
    {
        get => _scrollBarMaximum;
        set
        {
            _scrollBarMaximum = value;
            NotifyPropertyChanged(nameof(ScrollBarMaximum));
        }
    }

    private double _scrollBarValue;

    /// <summary>
    /// 滚动条当前的值
    /// </summary>
    public double ScrollBarValue
    {
        get => _scrollBarValue;
        set
        {
            _scrollBarValue = value;
            CanvasLeft = -_scrollBarValue;
            NotifyPropertyChanged(nameof(ScrollBarValue));
        }
    }

    private double _canvasLeft;

    /// <summary>
    /// 元素距 Canvas 左边的距离
    /// </summary>
    public double CanvasLeft
    {
        get => _canvasLeft;
        set
        {
            _canvasLeft = value;
            // 通知绑定了该属性的控件做出相应的更改
            NotifyPropertyChanged(nameof(CanvasLeft));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// 属性通知方法
    /// </summary>
    /// <param name="propertyName">属性名称</param>
    protected virtual void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}