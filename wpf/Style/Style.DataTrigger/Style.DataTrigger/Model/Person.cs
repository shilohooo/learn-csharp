namespace Style.DataTrigger.Model;

/// <summary>
/// 人员信息实体
/// </summary>
public class Person : ObservableObject
{
    /// <summary>
    /// 姓名字段
    /// </summary>
    private string _name;

    /// <summary>
    /// 姓名属性
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
    /// 年龄字段
    /// </summary>
    private int _age;

    /// <summary>
    /// 年龄属性
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
    /// 地址字段
    /// </summary>
    private string _address;

    /// <summary>
    /// 地址属性
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