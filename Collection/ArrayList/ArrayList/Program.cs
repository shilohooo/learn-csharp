namespace ArrayList;

/// <summary>
/// C# 中的 ArrayList（动态数组)，代表了可被单独索引的对象的有序集合。
/// <remarks>
/// 提示：就像 Java 中的 ArrayList，可以动态扩容~
/// <para>
/// 动态数组基本上可以代替数组，唯一与数组不同的是，动态数组可以使用索引在指定的位置添加和移除指定的项目，
/// 动态数组会自动重新调整自身的大小。<br/> 另外，动态数组允许在列表中进行动态内存分配、增加、搜索、排序等操作。
/// </para>
/// </remarks>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 实例化
        var numbers = new System.Collections.ArrayList();
        // 接收用户输入
        Console.WriteLine("请输入数字列表，多个数字以英文逗号分隔:)");
        var userInput = Console.ReadLine();
        // 切割，遍历
        var strNumbers = userInput.Split(",");
        foreach (var num in strNumbers)
        {
            // 添加元素到列表中
            numbers.Add(num);
        }

        // 遍历输出列表内容
        Console.WriteLine("排序之前的列表：");
        PrintList(numbers);

        // 排序
        numbers.Sort();
        Console.WriteLine("排序之后的列表：");
        PrintList(numbers);
    }

    public static void PrintList(System.Collections.ArrayList arrayList)
    {
        foreach (var o in arrayList)
        {
            Console.Write($"{o} ");
        }

        Console.WriteLine();
    }
}