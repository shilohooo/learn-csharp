using System.Globalization;
using System.Windows;
using DataBindingDemo.ViewModels;

namespace DataBindingDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 初始化数据上下文
        DataContext = new MainViewModel();
    }

    private void ChangePersonInfo(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainViewModel;
        if (vm is null)
        {
            return;
        }

        vm.Person.Age = new Random().Next(1, 100);
        vm.Person.Address = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    }
}