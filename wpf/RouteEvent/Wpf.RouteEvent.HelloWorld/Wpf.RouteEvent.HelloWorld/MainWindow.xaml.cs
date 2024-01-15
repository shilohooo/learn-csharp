using System.Windows;
using System.Windows.Input;

namespace Wpf.RouteEvent.HelloWorld;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 隧道事件：从根节点由上至下传播到事件源

    #region TunnleEventHandlers

    private void Window_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Window_OnPreviewMouseUp");
    }

    private void Border_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Border_OnPreviewMouseUp");
    }

    private void Canvas_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Canvas_OnPreviewMouseUp");
    }

    private void ConfirmButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("ConfirmButton_OnPreviewMouseUp");
    }

    private void CancelButton_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("CancelButton_OnPreviewMouseUp");
    }

    #endregion

    // 冒泡事件：从事件源由下往上传播到根节点

    #region BubbleEventHandlers

    private void Window_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Window_OnMouseUp");
    }

    private void Border_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Border_OnMouseUp");
    }

    private void Canvas_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("Canvas_OnMouseUp");
    }

    private void ConfirmButton_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("ConfirmButton_OnMouseUp");
    }

    private void CancelButton_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        Console.WriteLine("CancelButton_OnMouseUp");
    }

    /// <summary>
    /// Button的MouseUp事件已经在内部被处理掉了，由Click事件代替了，
    /// 因此，如果只定义 Button 的 MouseUp事件，那么ConfirmButton_OnClick不会被触发，
    /// 需要通过Click事件来触发。
    /// 且 Button 的 Click 事件不会向上冒泡，因为内部通过 e.Handled = true 来阻止冒泡
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ConfirmButton_OnClick(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("ConfirmButton_OnClick");
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("CancelButton_OnClick");
    }

    #endregion
}