using System.Windows;
using Style.DataTrigger.Model;
using Style.DataTrigger.ViewModel;

namespace Style.DataTrigger;

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
        var vm = DataContext as MainViewModel;

        vm?.Persons.Add(new Person
        {
            Name = "张三",
            Age = 18,
            Address = "北京市海淀区"
        });
    }
}