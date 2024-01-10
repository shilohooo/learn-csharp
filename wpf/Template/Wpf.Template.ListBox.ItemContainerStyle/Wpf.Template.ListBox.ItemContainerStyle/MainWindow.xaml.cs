using System.Windows;
using Wpf.Template.ListBox.ItemContainerStyle.ViewModel;

namespace Wpf.Template.ListBox.ItemContainerStyle;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}