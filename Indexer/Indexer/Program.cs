namespace Indexer;

/// <summary>
/// <para>C#中的索引器</para>
/// <para>索引器是类中的一个特殊成员，它能够让对象以类似数组的形式来操作，使程序看起来更为直观，更容易编写。</para>
/// <para>索引器与属性类似，在定义索引器时同样会用到 get 和 set 访问器，不同的是，访问属性不需要提供参数而访问索引器则需要提供相应的参数。</para>
/// <para>C# 中属性的定义需要提供属性名称，而索引器则不需要具体名称，而是使用 this 关键字来定义，语法格式如下：</para>
/// <code>
/// 访问修饰符 索引器类型 this[int index]
/// {
///     get {
///         // 返回 index 指定的值
///     }
///     set {
///         // 设置 index 指定的值
///     }
/// }
/// </code>
/// </summary>
public class Program
{
    private const int Size = 10;

    private string[] _names = new string[Size];

    public Program()
    {
        for (var i = 0; i < Size; i++)
        {
            _names[i] = "NULL";
        }
    }

    /// <summary>
    /// 定义索引器
    /// </summary>
    /// <param name="index">索引</param>
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= _names.Length)
            {
                return string.Empty;
            }

            return _names[index];
        }

        set
        {
            if (index < 0 || index >= _names.Length)
            {
                return;
            }

            _names[index] = value;
        }
    }

    /// <summary>
    /// <para>索引器可以被重载，而且在声明索引器时也可以带有多个参数，每个参数可以是不同的类型。</para>
    /// <para>另外，索引器中的索引不必是整数，也可以是其他类型，例如字符串类型。</para>
    /// </summary>
    /// <param name="name">名称</param>
    public int this[string name]
    {
        get
        {
            for (var i = 0; i < _names.Length; i++)
            {
                if (_names[i].Equals(name))
                {
                    return i;
                }
            }

            return -1;
        }
    }

    public void PrintNames()
    {
        foreach (var name in _names)
        {
            Console.WriteLine(name);
        }
    }

    public static void Main(string[] args)
    {
        var program = new Program
        {
            [0] = "shiloh595",
            [1] = "25",
            [2] = "backend developer",
            [3] = "https://github.com/shilohooo"
        };
        program.PrintNames();
        Console.WriteLine($"\"shiloh595\" 的索引为：{program["shiloh595"]}");
    }
}