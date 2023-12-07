namespace CSharpGeneric;

/// <summary>
/// C# 泛型（Generic）：泛型（Generic）是一种规范，它允许我们使用占位符来定义类和方法，编译器会在编译时将这些占位符替换为指定的类型，
/// 利用泛型的这一特性我们可以定义通用类（泛型类）或方法（泛型方法）。
/// <remarks>
/// 定义通用类需要使用尖括号&lt;&gt;，这里的尖括号用于将类或方法声明为泛型。<br />
/// 可以将泛型看作是一种增强程序功能的技术，泛型类和泛型方法兼具可重用性、类型安全性和效率，这是非泛型类和非泛型方法无法实现的。
/// 泛型通常与集合以及作用于集合的方法一起使用，System.Collections.Generic 命名空间下就包含几个基于泛型的集合类。
/// 下面总结了一些关于泛型的特性：<br />
/// <ul>
///   <li>使用泛型类型可以最大限度地重用代码、保护类型的安全性以及提高性能；</li>
///   <li>泛型最常见的用途是创建集合类；</li>
///   <li>.NET 类库在 System.Collections.Generic 命名空间中包含几个新的泛型集合类，可以使用这些类来代替 System.Collections 中的集合类；</li>
///   <li>可以创建自己的泛型接口、泛型类、泛型方法、泛型事件和泛型委托；</li>
///   <li>可以对泛型类进行约束以访问特定数据类型的方法；</li>
///   <li>在泛型数据类型中所用类型的信息可在运行时通过使用反射来获取。</li>
/// </ul>
/// </remarks>
/// </summary>
class Program
{
    public static int Num = 10;

    static void Main(string[] args)
    {
        var stringGenericClass = new GenericClass<string>("hello c# generic:)");
        var intGenericClass = new GenericClass<int>(123);
        var charGenericClass = new GenericClass<char>('C');

        // 泛型方法测试
        var a = 1;
        var b = 2;
        var c = 'A';
        var d = 'B';

        Console.WriteLine("交换值之前的数据：");
        Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");

        Swap(ref a, ref b);
        Swap(ref c, ref d);

        Console.WriteLine("交换值之后的数据：");
        Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");

        // 泛型委托测试
        var addNumChanger = new NumberChanger<int>(AddNum);
        var multiplyNumChanger = new NumberChanger<int>(MultiplyNum);
        addNumChanger(5);
        Console.WriteLine($"Num = {Num}");
        multiplyNumChanger(10);
        Console.WriteLine($"Num = {Num}");
    }

    /// <summary>
    /// 泛型方法：交换值
    /// </summary>
    /// <param name="left">左值</param>
    /// <param name="right">右值</param>
    /// <typeparam name="T">泛型</typeparam>
    public static void Swap<T>(ref T left, ref T right)
    {
        (left, right) = (right, left);
    }

    /// <summary>
    /// 泛型委托
    /// </summary>
    /// <typeparam name="T">数字类型</typeparam>
    public delegate T NumberChanger<T>(T num);

    /// <summary>
    /// 加法
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns>加法运算后的数</returns>
    public static int AddNum(int param)
    {
        Num += param;
        return Num;
    }

    /// <summary>
    /// 乘法运算
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns>乘法运算后的数</returns>
    public static int MultiplyNum(int param)
    {
        Num *= param;
        return Num;
    }
}

/// <summary>
/// 定义一个泛型类
/// </summary>
/// <typeparam name="T">泛型类型</typeparam>
public class GenericClass<T>
{
    /// <summary>
    /// 使用了泛型的构造函数
    /// </summary>
    /// <param name="msg">打输出的信息，具体的类型现在还不知道</param>
    public GenericClass(T msg)
    {
        Console.WriteLine(msg);
    }
}