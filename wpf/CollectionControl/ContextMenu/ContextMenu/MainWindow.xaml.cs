using System.Windows;
using System.Windows.Controls;

namespace ContextMenu;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnMenuItemClick(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        MessageBox.Show(menuItem?.Header.ToString());
    }
}