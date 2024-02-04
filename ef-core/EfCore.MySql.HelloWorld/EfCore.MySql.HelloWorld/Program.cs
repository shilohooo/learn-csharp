using EfCore.MySql.HelloWorld.Context;
using EfCore.MySql.HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.MySql.HelloWorld;

/// <summary>
/// EF Core 连接到 MySQL 数据库
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        using var ctx = new OrderContext();
        ctx.Database.EnsureCreated();

        var order = new Order()
        {
            OrderNo = Guid.NewGuid().ToString(),
            OrderDate = DateTime.Now,
            IsDeleted = false,
            OrderItems = new List<OrderItem>
            {
                new() { ProductName = "CPU" },
                new() { ProductName = "主板" },
                new() { ProductName = "散热器" },
                new() { ProductName = "电源" }
            }
        };

        ctx.Orders.Add(order);
        ctx.SaveChanges();

        var orders = ctx.Orders
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.OrderDate)
            .ToList();
        Console.WriteLine($"当前数据库有{orders.Count}张订单");
        foreach (var item in orders)
        {
            // item.OrderNo = $"{Guid.NewGuid()}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
            Console.WriteLine($"订单信息：{item}");
            Console.WriteLine("订单项：");
            foreach (var orderItem in item.OrderItems)
            {
                Console.WriteLine(orderItem);
                // orderItem.ProductName = $"{orderItem.ProductName}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
            }
            // ctx.OrderItems.RemoveRange(item.OrderItems);
            // item.OrderItems.Clear();
        }

        // ctx.Orders.UpdateRange(orders);
        // ctx.SaveChanges();

        // ctx.Orders.RemoveRange(orders);
        ctx.SaveChanges();
    }
}