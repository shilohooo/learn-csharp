namespace Wpf.Template.ListBox.ItemContainerStyle.Model;

/// <summary>
/// 人员信息实体
/// </summary>
public class Person : ObservableObject
{
    /// <summary>
    /// backing field of <see cref="Name"/>
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
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field of <see cref="Age"/>
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
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field of <see cref="Occupation"/>
    /// </summary>
    private string _occupation;

    /// <summary>
    /// 工作
    /// </summary>
    public string Occupation
    {
        get => _occupation;
        set
        {
            _occupation = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field of <see cref="Money"/>
    /// </summary>
    private int _money;

    /// <summary>
    /// 资产
    /// </summary>
    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// backing field of <see cref="Address"/>
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
            OnPropertyChanged();
        }
    }
}