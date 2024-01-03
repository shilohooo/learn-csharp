using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverter;

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

public class AgeToColorConverter : IValueConverter
{
    /// <summary>
    /// 将输入的 value 和 parameter 参数根据自定义逻辑转换成另一个对象给前端 XAML 使用
    /// </summary>
    /// <param name="value">前端输入的值</param>
    /// <param name="targetType">绑定目标属性的类型</param>
    /// <param name="parameter"></param>
    /// <param name="culture">用于本地化的参数</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Console.WriteLine($"value: {value}");
        Console.WriteLine($"targetType: {targetType}");
        Console.WriteLine($"parameter: {parameter}");
        Console.WriteLine($"culture: {culture}");

        var background = Brushes.Black;
        if (int.TryParse(value?.ToString(), out var age))
        {
            // switch 表达式
            background = age switch
            {
                < 20 => Brushes.Green,
                < 40 => Brushes.Blue,
                < 60 => Brushes.Red,
                < 80 => Brushes.Yellow,
                _ => Brushes.Gray
            };
        }

        return background;
    }

    /// <summary>
    /// 将前端输入的数据转换成另一个对象返回给后端的数据源
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}