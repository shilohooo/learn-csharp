using System.Windows;

namespace Wpf.Dp.PropertyChangeCallback;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Submit(object sender, RoutedEventArgs e)
    {
        foreach (var item in TrayControl.SelectedItems)
        {
            MessageBox.Show($"{item.Name} 移动坐标 = （{item.Tag}）");
        }
    }
}