using System.Collections;

namespace CSharpHashTable;

/// <summary>
/// C# HashTable：表示根据键的哈希代码进行组织的键（key）/值（value）对的集合，可以使用键来访问集合中的元素。
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var hashtable = new Hashtable();
        // 添加元素
        hashtable.Add("001", "张三");
        hashtable.Add("002", "李四");
        hashtable.Add("003", "王五");
        // 根据 key 判断元素是否已存在
        const string key = "003";
        if (hashtable.ContainsKey(key))
        {
            Console.WriteLine($"key: {key} already exists~");
        }
        else
        {
            Console.WriteLine($"key: {key} not exist");
            hashtable.Add(key, "王五");
        }

        // 根据 value 判断元素是否已存在
        const string val = "赵六";
        if (hashtable.ContainsValue(val))
        {
            Console.WriteLine($"value: {val} already exists~");
        }
        else
        {
            Console.WriteLine($"value: {val} not exist");
            hashtable.Add("004", val);
        }

        // 遍历 hash table 中的 key value
        foreach (var keyItem in hashtable.Keys)
        {
            Console.WriteLine($"key: {keyItem}, value: {hashtable[keyItem]}");
        }
    }
}