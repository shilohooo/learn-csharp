using System.Windows;
using Wpf.RouteEvent.AttachedEvent.Controls;
using Wpf.RouteEvent.AttachedEvent.Mvvm;

namespace Wpf.RouteEvent.AttachedEvent;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 当总销售额达到目标时，添加到 ListBox 中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Widget_OnCompleted(object sender, RoutedEventArgs e)
    {
        var widget = sender as Widget;
        ListBox.Items.Insert(0, $"完成目标销售额：{widget?.Value}");
        // 触发附件事件
        widget?.RaiseEvent(new RoutedEventArgs(SalesManager.CheckEvent));
    }

    /// <summary>
    /// 附件事件触发后的回调
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Widget_OnCheck(object sender, RoutedEventArgs e)
    {
        if (sender is not Widget widget)
        {
            return;
        }

        if ((int)widget.Value % 500000 < 5000)
        {
            ListBox.Items.Insert(
                0, $"当前业绩：{widget.Value}，每累计50万绩效发奖金啦：{widget.Value * 0.5}"
            );
        }
    }
}