using Wpf.Template.DataTemplate;
using Wpf.Template.ItemsPanelTemplate.Model;

namespace Wpf.Template.ItemsPanelTemplate.ViewModel;

/// <summary>
/// 主窗体数据上下文
/// </summary>
public class MainViewModel : ObservableObject
{
    /// <summary>
    /// backing field of <see cref="Person"/>
    /// </summary>
    private Person _person;

    /// <summary>
    /// 人员信息
    /// </summary>
    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field of <see cref="Persons"/>
    /// </summary>
    private List<Person> _persons = [];

    /// <summary>
    /// 人员信息集合
    /// </summary>
    public List<Person> Persons
    {
        get => _persons;
        set
        {
            _persons = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        _person = new Person
        {
            Name = "张三",
            Age = 20,
            Occupation = "程序员",
            Money = 99999,
            Address = "北京"
        };
        _persons.Add(_person);
        
        _persons.Add(new Person
        {
            Name = "李四",
            Age = 21,
            Occupation = "程序员",
            Money = 99999,
            Address = "北京"
        });
        _persons.Add(new Person
        {
            Name = "王五",
            Age = 22,
            Occupation = "程序员",
            Money = 99999,
            Address = "北京"
        });
        _persons.Add(new Person
        {
            Name = "赵六",
            Age = 23,
            Occupation = "程序员",
            Money = 99999,
            Address = "北京"
        });
    }
}