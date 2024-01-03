using System.Globalization;
using System.Windows;
using MultiValueConverter.Model;
using MultiValueConverter.ViewModel;

namespace MultiValueConverter;

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

    private int _number = 1;

    public void CreatePerson(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainViewModel;
        if (vm is null)
        {
            return;
        }

        var person = new Person
        {
            Name = $"新人{_number++}",
            Age = new Random().Next(1, 100),
            Money = new Random().Next(1, new Random().Next(1, 100_0000)),
            Address = DateTime.Now.ToString(CultureInfo.CurrentCulture)
        };
        vm.Persons.Add(person);
    }
}