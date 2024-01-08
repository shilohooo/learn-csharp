using Wpf.Template.TemplateBinding.Model;

namespace Wpf.Template.TemplateBinding.ViewModel;

/// <summary>
/// 主窗体数据上下文
/// </summary>
public class MainViewModel : ObservableObject
{
    /// <summary>
    /// backing field for Person property
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
            base.OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        _person = new Person
        {
            Name = "张三三",
            Age = 26,
            Occupation = "软件开发",
            Money = 9999999,
            Address = "广东省佛山市南海区桂城街道"
        };
    }
}