using System.Windows;
using ValidationRule.Model;
using ValidationRule.ViewModel;

namespace ValidationRule;

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


    private void CreatePerson(object sender, RoutedEventArgs e)
    {
        if (DataContext is not MainViewModel vm)
        {
            return;
        }

        vm.Person = new Person
        {
            Name = "张三",
            Age = 18,
            Money = 10000,
            Address = "北京市海淀区"
        };
    }
}