using System.Collections;

namespace CSharpSortedList;

/// <summary>
/// C# SortedList（有序的列表）：表示键/值对的集合，这些键/值对按照键值进行排序，并且可以通过键或索引访问集合中的各个项。
/// <remarks>
/// 可以将排序列表看作是数组和哈希表的组合，其中包含了可以使用键或索引访问各项的列表。
/// 如果使用索引访问各项，那么它就是一个动态数组（ArrayList），如果使用键访问各项，那么它就是一个哈希表（Hashtable）。
/// 另外，集合中的各项总是按键值进行排序。
/// </remarks>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var sortedList = new SortedList();
        // 添加元素
        sortedList.Add("001", "张三");
        sortedList.Add("002", "李四");
        sortedList.Add("003", "王五");
        sortedList.Add("004", "赵六");
        // 根据 key 判断元素是否存在
        const string key = "003";
        if (sortedList.ContainsKey(key))
        {
            Console.WriteLine($"key: {key} already exists:)");
        }
        else
        {
            Console.WriteLine($"key: {key} not exist:(");
            sortedList.Add(key, "王五");
        }

        // 根据 value 判断元素是否存在
        const string val = "钱七";
        if (sortedList.ContainsValue(val))
        {
            Console.WriteLine($"value: {val} already exists:)");
        }
        else
        {
            Console.WriteLine($"value: {val} not exist:(");
            sortedList.Add("000", val);
        }

        // 根据索引访问列表元素
        var element = sortedList.GetByIndex(0);
        Console.WriteLine($"element at index 0 is: {element}");
        // 遍历列表
        foreach (DictionaryEntry item in sortedList)
        {
            Console.WriteLine($"key: {item.Key}, value: {item.Value}");
        }
    }
}