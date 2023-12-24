using System.Windows;

namespace Expander;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnExpanded(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Expander控件展开");
    }

    private void OnCollapsed(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Expander控件折叠");
    }
}