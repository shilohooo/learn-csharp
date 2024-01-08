namespace Wpf.Template.TemplateBinding.Model;

/// <summary>
/// 人员实体
/// </summary>
public class Person : ObservableObject
{
    /// <summary>
    /// backing field for Name property
    /// </summary>
    private string _name;

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            base.OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field for Age property
    /// </summary>
    private int _age;

    /// <summary>
    /// 年龄
    /// </summary>
    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            base.OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field for Occupation property
    /// </summary>
    private string _occupation;
    
    /// <summary>
    /// 工作
    /// </summary>
    public  string Occupation
    {
        get => _occupation;
        set
        {
            _occupation = value;
            base.OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field for Money property
    /// </summary>
    private int _money;

    /// <summary>
    /// 财产
    /// </summary>
    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            base.OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field for Address property
    /// </summary>
    private string _address;

    /// <summary>
    /// 地址
    /// </summary>
    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            base.OnPropertyChanged();
        }
    }
}