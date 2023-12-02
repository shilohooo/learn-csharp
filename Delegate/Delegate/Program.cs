namespace Delegate;

/// <summary>
/// 定义一个委托，可以引用带有一个 int 类型参数的方法
/// </summary>
delegate int NumberChanger(int n);

/// <summary>
/// <para>C#中的委托</para>
/// <para>委托是一种引用类型，表示对具有特定参数列表和返回类型的方法的引用。委托特别适用于实现事件和回调方法，</para>
/// <para>所有的委托都派生自 System.Delegate 类。在实例化委托时，可以将委托的实例与具有相同返回值类型的方法相关联，</para>
/// <para>这样就可以通过委托来调用方法。另外，使用委托还可以将方法作为参数传递给其他方法，</para>
/// <para>委托具有以下特点：</para>
/// <ul>
///   <li>委托是完全面向对象的。同时封装对象实例和方法；</li>
///   <li>委托允许将方法作为参数进行传递（想象一下 JS、Java中的函数式接口）</li>
///   <li>委托可用于定义回调方法；</li>
///   <li>委托可以链接在一起（使用 + 号），例如可以对一个事件调用多个方法；</li>
///   <li>方法不必与委托类型完全匹配；</li>
///   <li>
///   C# 2.0 版引入了匿名函数的概念，可以将代码块作为参数（而不是单独定义的方法）进行传递。C# 3.0 引入了 Lambda 表达式，
///   利用它们可以更简练地编写内联代码块。匿名方法和 Lambda 表达式都可编译为委托类型，这些功能现在统称为匿名函数。
///   </li>
/// </ul>
/// <para>声明委托需要使用 delegate 关键字，语法格式如下：</para>
/// <code>
/// 访问修饰符 delegate 返回值类型 委托名称(参数列表);
/// </code>
/// <para>提示：提示：委托可以引用与委托具有相同签名的方法，也就是说委托在声明时即确定了委托可以引用的方法。</para>
/// <para>实例化委托：委托一旦声明，想要使用就必须使用 new 关键字来创建委托的对象，同时将其与特定的方法关联。如下例所示：</para>
/// <code>
/// public delegate void printString(string s);                      // 声明一个委托
/// ...
/// printString ps1 = new printString(WriteToScreen);       // 实例化委托对象并将其与 WriteToScreen 方法关联
/// printString ps2 = new printString(WriteToFile);            // 实例化委托对象并将其与 WriteToFile 方法关联
/// </code>
/// </summary>
public class Program
{
    private static int _sNum = 10;
    private static FileStream? _fileStream;
    private static StreamWriter? _streamWriter;

    // 定义一个委托 printString，使用这个委托来调用两个方法，第一个把字符串打印到控制台，第二个把字符串打印到文件：
    public delegate void PrintStr(string msg);

    public static int AddNum(int num)
    {
        _sNum += num;
        return _sNum;
    }

    public static int MultiplyNum(int num)
    {
        _sNum *= num;
        return _sNum;
    }

    public static int GetNum()
    {
        return _sNum;
    }

    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="msg">要输出的信息</param>
    public static void WriteToScreen(string msg)
    {
        Console.WriteLine($"msg: {msg}");
    }

    /// <summary>
    /// 输出信息到文件中
    /// </summary>
    /// <param name="msg">要输出的信息</param>
    public static void WriteToFile(string msg)
    {
        _fileStream = new FileStream("msg.txt", FileMode.Append, FileAccess.Write);
        _streamWriter = new StreamWriter(_fileStream);
        _streamWriter.WriteLine(msg);
        _streamWriter.Flush();
        _streamWriter.Close();
        _fileStream.Close();
    }

    /// <summary>
    /// 把委托当作方法参数，并调用它引用的方法
    /// </summary>
    /// <param name="printStr"></param>
    public static void SendString(PrintStr printStr)
    {
        printStr("shiloh595-19980302");
    }

    public static void Main(string[] args)
    {
        // 使用 new 关键字创建委托实例
        var addNumberChanger = new NumberChanger(AddNum);
        var multiplyNumberChanger = new NumberChanger(MultiplyNum);
        // 多播委托：委托对象有一个非常有用的属性，那就是可以通过使用+运算符将多个对象分配给一个委托实例，
        // 同时还可以使用-运算符从委托中移除已分配的对象，当委托被调用时会依次调用列表中的委托。
        // 委托的这个属性被称为委托的多播，也可称为组播，利用委托的这个属性，可以创建一个调用委托时要调用的方法列表。
        var numberChanger = addNumberChanger;
        numberChanger += multiplyNumberChanger;
        // 使用委托对象调用方法
        // addNumberChanger(25);
        // Console.WriteLine($"num 的值 = {GetNum()}");
        // 调用委托多播：先调用 AddNum，再把 AddNum 的返回值当作参数，调用 MultiplyNum
        numberChanger(5);
        Console.WriteLine($"num 的值 = {GetNum()}");

        var writeToScreen = new PrintStr(WriteToScreen);
        var writeToFile = new PrintStr(WriteToFile);
        SendString(writeToScreen);
        SendString(writeToFile);
    }
}