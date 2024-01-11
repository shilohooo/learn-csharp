using System.Windows;
using Wpf.Command.EventToCommand.ViewModel;

namespace Wpf.Command.EventToCommand;

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