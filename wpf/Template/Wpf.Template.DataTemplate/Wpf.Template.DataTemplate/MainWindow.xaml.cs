using System.Windows;
using Wpf.Template.DataTemplate.ViewModel;

namespace Wpf.Template.DataTemplate;

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