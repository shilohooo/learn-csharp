using System.Windows;
using Wpf.Template.ListBox.TemplateStyle.ViewModel;

namespace Wpf.Template.ListBox.TemplateStyle;

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