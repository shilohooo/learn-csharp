using System.Windows;
using Wpf.Template.ItemsPanelTemplate.ViewModel;

namespace Wpf.Template.ItemsPanelTemplate;

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