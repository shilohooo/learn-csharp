namespace AnonymousFunction;

/// <summary>
/// C# 匿名函数：可以将匿名函数简单的理解为没有名称只有函数主体的函数。匿名函数提供了一种将代码块作为委托参数传递的技术，
/// 它是一个“内联”语句或表达式，可在任何需要委托类型的地方使用。匿名函数可以用来初始化命名委托或传递命名委托作为方法参数。
/// <remarks>
/// 无需在匿名函数中指定返回类型，返回值类型是从方法体内的 return 语句推断出来的。<br />
/// 匿名函数的语法，匿名函数是通过使用 delegate 关键字创建的委托实例来声明的，如下例所示：
/// <code>
/// public delegate void NumberChanger(int i);
/// ...
/// NumberChanger n = delegate(int i) {
///     Console.WriteLine($"Anonymous method: {i}");
/// };
/// </code>
/// 代码块<code>Console.WriteLine($"Anonymous method: {i}");</code>是匿名函数的主体。<br />
/// 委托可以通过匿名函数调用，也可以通过普通有名称的函数调用，只需要向委托对象中传递相应的方法参数即可。<br />
/// 注意，匿名函数的主体后面需要使用;结尾。
/// </remarks>
/// </summary>
public class Program
{
    public static int Num = 10;

    /// <summary>
    /// 定义委托
    /// </summary>
    public delegate void NumberChanger(int num);

    public static void AddNum(int param)
    {
        Num += param;
        Console.WriteLine($"命名函数调用，Num = {Num}");
    }

    public static void MultiplyNum(int param)
    {
        Num *= param;
        Console.WriteLine($"命名函数调用，Num = {Num}");
    }

    /// <summary>
    /// 匿名函数示例
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        // 使用匿名函数创建委托实例
        NumberChanger anonymousNumberChanger = delegate(int num)
        {
            Console.WriteLine($"匿名函数调用，参数值：{num}");
        };
        // 使用匿名函数调用委托
        anonymousNumberChanger(10);
        // 使用命名函数调用委托
        var addNumChanger = new NumberChanger(AddNum);
        addNumChanger(10);
        var multiplyNumberChanger = new NumberChanger(MultiplyNum);
        multiplyNumberChanger(5);
    }
}