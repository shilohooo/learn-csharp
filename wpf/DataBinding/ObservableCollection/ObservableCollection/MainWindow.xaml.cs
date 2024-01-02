using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ObservableCollection;

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

    public void CreateNewPerson(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainViewModel;
        if (vm is null)
        {
            return;
        }

        var person = new Person
        {
            Name = "新创建的人员信息",
            Age = new Random().Next(1, 100),
            Address = DateTime.Now.ToString(CultureInfo.CurrentCulture)
        };
        vm.Persons.Add(person);
    }
}

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Person : ObservableObject
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }

    private string _address;

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChanged();
        }
    }
}

public class MainViewModel : ObservableObject
{
    private Person _person;

    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Person> Persons { get; set; } = [];
}