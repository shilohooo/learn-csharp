using System.Windows;

namespace Label;

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
    /// 弹窗显示当前时间
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SayHi(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"你好，现在是北京时间：{DateTime.Now}");
    }
}