namespace EfCore.MySql.HelloWorld.Models;

/// <summary>
/// 订单项实体
/// </summary>
public class OrderItem
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 产品名称
    /// </summary>
    public string ProductName { get; set; }

    ///  <summary>
    /// 订单 ID，<see cref="Order.Id"/>
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// 订单，<see cref="Order"/>，多个订单项可以属于一个订单
    /// </summary>
    public Order Order { get; set; }

    public override string ToString()
    {
        return $"OrderItem[Id={Id}, ProductName={ProductName}, OrderId={OrderId}]";
    }
}