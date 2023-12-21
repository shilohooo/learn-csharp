using System.Windows;

namespace Button;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // 通过C#代码提供的事件订阅符号 += 去订阅事件，就像多播委托
        Button.Click += OnClick;
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        Console.WriteLine($"sender: {sender}, args: {e}");
        // 关闭窗体
        Close();
    }
}