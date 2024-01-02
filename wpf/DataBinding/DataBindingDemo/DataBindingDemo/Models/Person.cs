namespace DataBindingDemo.Models;

/// <summary>
/// 人员实体
/// </summary>
public class Person : ObservableObject
{
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
            // 触发属性更改，此时如果前端 UI 有这几个属性的绑定，将会立即更新内容
            OnPropertyChanged();
        }
    }

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