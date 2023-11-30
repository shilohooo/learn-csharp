using System.Diagnostics;

namespace Attribute;

/// <summary>
/// C# 中的 Attribute（特性），类似Java中的注解~
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        AttributeDemo.PrintMsg("Main 函数");
        Demo.fun1();
        // 取消注释将无法通过编译
        // OldMethod();
        NewMethod();

        var rectangle = new Rectangle(15, 30);
        rectangle.Display();
    }

    /// <summary>
    /// <para>预定义特性 Obsolete 用来标记不应被使用的程序，您可以使用它来通知编译器放弃某个目标元素。</para>
    /// <para>例如当需要使用一个新方法来替代类中的某个旧方法时，就可以使用该特性将旧方法标记为 obsolete（过时的）并来输出一条消息，</para>
    /// <para>来提示我们应该使用新方法代替旧方法。</para>
    /// <para>第一个参数 message 是一个字符串，用来描述项目为什么过时以及应该使用什么替代；</para>
    /// <para>第二个参数 error 是一个布尔值，默认值是 false（编译器会生成一个警告），如果设置为 true，那么编译器会把该项目的当作一个错误。</para>
    /// </summary>
    [Obsolete("该函数已废弃，请改用 NewMethod!!!", true)]
    public static void OldMethod()
    {
        Console.WriteLine("已废弃的函数，请勿调用");
    }

    public static void NewMethod()
    {
        Console.WriteLine("新定义的函数");
    }
}

public class AttributeDemo
{
    /// <summary>
    /// <para>输出指定信息</para>
    /// <para>预定义特性 Conditional 用来标记一个方法，它的执行依赖于指定的预处理标识符。</para>
    /// <para>根据该特性值的不同，在编译时会起到不同的效果，例如当值为 Debug 或 Trace 时，会在调试代码时显示变量的值。</para>
    /// </summary>
    /// <param name="msg">指定信息</param>
    [Conditional("DEBUG")]
    public static void PrintMsg(string msg)
    {
        Console.WriteLine(msg);
    }
}

public class Demo
{
    public static void fun1()
    {
        AttributeDemo.PrintMsg("Demo.fun1 函数");
        fun2();
    }

    public static void fun2()
    {
        AttributeDemo.PrintMsg("Demo.fun2 函数");
    }
}

/// <summary>
/// <para>自定义特性：用于存储声明性的信息，还可以在运行时被检索。</para>
/// <para>创建并使用自定义特性可以分为四个步骤</para>
/// <para>声明自定义特性</para>
/// <para>构建自定义特性</para>
/// <para>在目标程序上应用自定义特性</para>
/// <para>通过反射访问特性</para>
///
/// <para>预定义特性 AttributeUsage 用来描述如何使用自定义特性类，其中定义了可以应用特性的项目类型。</para>
/// <para>参数 validOn 用来定义特性可被放置的语言元素。它是枚举器 AttributeTargets 的值的组合。默认值是 AttributeTargets.All；</para>
/// <para>参数 allowMultiple（可选参数）用来为该特性的 AllowMultiple 属性（property）提供一个布尔值，默认值为 false（单用的），如果为 true，则该特性是多用的；</para>
/// <para>参数 inherited（可选参数）用来为该特性的 Inherited 属性（property）提供一个布尔值，默认为 false（不被继承），如果为 true，则该特性可被派生类继承。</para>
/// </summary>
[
    AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Method |
        AttributeTargets.Field |
        AttributeTargets.Property,
        AllowMultiple = true
    )
]
public class DebugInfo : System.Attribute
{
    // bug编号
    private int _bugNo;

    // 开发者
    private string _developer;

    // 上次审查代码的日期
    private string _lastReviewDate;

    // 存储开发人员标记的字符串消息
    public string Message;

    /// <summary>
    /// 带参构造函数
    /// </summary>
    /// <param name="bugNo">bug编号</param>
    /// <param name="developer">开发者</param>
    /// <param name="lastReviewDate">上次审查代码的日期</param>
    public DebugInfo(int bugNo, string developer, string lastReviewDate)
    {
        _bugNo = bugNo;
        _developer = developer;
        _lastReviewDate = lastReviewDate;
    }
}

public class Rectangle
{
    private double _length;

    private double _width;

    public Rectangle(double length, double width)
    {
        _length = length;
        _width = width;
    }

    [DebugInfo(1, "shiloh", "2023-11-30", Message = "返回值类型不匹配")]
    public double GetArea()
    {
        return _length * _width;
    }

    [DebugInfo(2, "shiloh", "2023-11-30")]
    public void Display()
    {
        Console.WriteLine($"length: {_length}");
        Console.WriteLine($"width: {_width}");
        Console.WriteLine($"area: {GetArea()}");
    }
}