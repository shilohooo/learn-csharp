using System.Windows;
using Wpf.RouteEvent.Demo.Controls;

namespace Wpf.RouteEvent.Demo;

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
    }
}