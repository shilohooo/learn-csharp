namespace Wpf.Integration.EfCore.Models;

/// <summary>
/// 产品实体
/// </summary>
public class Product
{
    /// <summary>
    /// ID
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    public string Name { get; set; }

    ///  <summary>
    /// 产品类别ID，<see cref="Models.Category.CategoryId"/>
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// 导航属性：产品类别信息，一个产品只能属于一个类别
    /// 将导航属性定于为 virtual 后，EF 会自动创建一个代理对象，并重写该属性，
    /// 为该属性添加 loading hook，从而实现延迟加载。
    /// </summary>
    public virtual Category Category { get; set; }
}