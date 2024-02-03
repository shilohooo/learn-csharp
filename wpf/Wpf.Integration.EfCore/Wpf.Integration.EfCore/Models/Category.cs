using System.Collections.ObjectModel;
using Wpf.Integration.EfCore.Mvvm;

namespace Wpf.Integration.EfCore.Models;

/// <summary>
/// 产品类别实体
/// </summary>
public class Category : ObservableObject
{
    /// <summary>
    /// 产品类型名称，<see cref="Name"/>
    /// </summary>
    private string _name;

    /// <summary>
    /// ID
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// 类别名称
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
    /// 导航属性：产品集合，一个产品类别可以有多个产品信息
    /// 在 EF 中，导航属性提供了一种简单的方法来表示两个实体之间的关系。
    /// </summary>
    public virtual ICollection<Product> Products { get; private set; } = new ObservableCollection<Product>();

    public override string ToString()
    {
        return $"Category[ID: {CategoryId}, Name: {Name}]";
    }
}