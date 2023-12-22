using System.Windows;

namespace RepeatButton;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int _Counter = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        _Counter++;
        Console.WriteLine($"当前时间：{DateTime.Now} {DateTime.Now.Millisecond}，重复执行几次：{_Counter}");
    }
}