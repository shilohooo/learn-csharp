namespace EfCore.MySql.HelloWorld.Models;

/// <summary>
/// 订单实体
/// </summary>
public class Order
{
    /// <summary>
    /// 主键
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 订单编号
    /// </summary>
    public string OrderNo { get; set; }

    /// <summary>
    /// 下单时间
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// 逻辑删除标识：<see langword="true"/> = 已删除，<see langword="false"/> = 未删除
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 订单项列表，<see cref="OrderItem"/>，一个订单可以有多个订单项
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; } = [];

    public override string ToString()
    {
        return
            $"Order[Id: {Id}, OrderNo: {OrderNo}, OrderDate: {OrderDate}, IsDeleted: {IsDeleted}]";
    }
}