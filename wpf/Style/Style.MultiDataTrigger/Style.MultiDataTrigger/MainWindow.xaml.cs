using System.Windows;
using Style.MultiDataTrigger.Model;
using Style.MultiDataTrigger.ViewModel;

namespace Style.MultiDataTrigger;

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