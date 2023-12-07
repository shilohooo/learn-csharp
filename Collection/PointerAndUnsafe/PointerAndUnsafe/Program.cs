namespace PointerAndUnsafe;

/// <summary>
/// C# 指针变量与 Unsafe：为了保持类型的安全性，默认情况下 C# 是不支持指针的，但是如果使用 unsafe 关键字来修饰类或类中的成员，
/// 这样的类或类中成员就会被视为不安全代码，C# 允许在不安全代码中使用指针变量。在公共语言运行时 (CLR) 中，不安全代码是指无法验证的代码，
/// 不安全代码不一定是危险的，只是 CLR 无法验证该代码的安全性。因此 CLR 仅会执行信任程序集中包含的不安全代码。
/// <remarks>
/// <para>指针变量：</para>
/// <para>
/// 在 C# 中，指针同样是一个变量，但是它的值是另一个变量的内存地址，在使用指针之前同样需要先声明指针，声明指针的语法格式如下所示：
/// </para>
/// <code>type* pointerName</code>
/// <para>注意：指针类型不能从对象中继承，并且装箱和拆箱也不支持指针，但是不同的指针类型以及指针与整型之间可以进行转换。</para>
/// </remarks>
/// </summary>
class Program
{
    /// <summary>
    /// Unsafe关键字修饰方法，可以在方法内使用指针
    /// </summary>
    /// <param name="args"></param>
    static unsafe void Main(string[] args)
    {
        var f = 3.14159;
        // 定义指针变量，使用 & 符号取址
        var p = &f;
        Console.WriteLine($"数据的内容是：{f}");
        // 将指针强转为 int 类型，输出地址信息
        Console.WriteLine($"数据在内存中的地址是：{(int)p}");
        // 使用指针检索数据的值
        // 在 C# 中，可以使用 ToString() 来获取指针变量所指向的数据的值，如下例所示：
        Console.WriteLine($"指针 p 指向的值为：{p->ToString()}");
        // 将指针作为参数传递给函数
        var num1 = 20;
        var num2 = 30;
        var p1 = &num1;
        var p2 = &num2;
        Console.WriteLine($"调用 Swap 函数前，num1 = {num1}, num2 = {num2}");
        Swap(p1, p2);
        Console.WriteLine($"调用 Swap 函数后，num1 = {num1}, num2 = {num2}");
        // 使用指针访问数组元素
        // 在 C# 中，数组和指向该数组且与数组名称相同的指针是不同的数据类型，例如int* p和int[] p就是不同的数据类型。
        // 可以增加指针变量 p 的值，因为它在内存中不是固定的，但数组地址在内存中是固定的，因此不能增加数组 p 的值。
        // 如果需要使用指针变量访问数组数据，可以使用 fixed 关键字来固定指针。示例：
        int[] nums = { 1, 2, 3, 4, 5, 6 };
        // 固定指针
        fixed (int* arrP = nums)
            // 使用指针访问数组
            for (var i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"num[{i}] 的内存地址为：{(int)(arrP + i)}");
                Console.WriteLine($"num[{i}] 的值为：{*(arrP + i)}");
            }
    }

    /// <summary>
    /// 将指针作为函数参数
    /// </summary>
    /// <param name="left">左值</param>
    /// <param name="right">右值</param>
    public static unsafe void Swap(int* left, int* right)
    {
        // 使用 * 符号取值
        var temp = *left;
        *left = *right;
        *right = temp;
    }
}