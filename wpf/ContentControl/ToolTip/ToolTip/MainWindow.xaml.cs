using System.Diagnostics;
using System.Windows;

namespace ToolTip;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToWpfHomePage(object sender, RoutedEventArgs e)
    {
        Process.Start("explorer.exe", "https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview");
    }
}