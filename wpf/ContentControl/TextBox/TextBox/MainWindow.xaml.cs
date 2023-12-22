using System.Windows;

namespace TextBox;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Confirm(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"您输入的用户名为：{TextBox.Text}");
    }
}