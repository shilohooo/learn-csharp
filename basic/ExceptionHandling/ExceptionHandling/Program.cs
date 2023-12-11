namespace ExceptionHandling;

/// <summary>
/// <para>C# 中的异常处理：</para>
/// <para>在 C# 中，异常是在程序运行出错时引发的，例如以一个数字除以零，所有异常都派生自 System.Exception 类。</para>
/// <para>异常处理则是处理运行时错误的过程，使用异常处理可以使程序在发生错误时保持正常运行。</para>
/// <para>C# 中的异常处理基于四个关键字构建，分别是 try、catch、finally 和 throw</para>
/// <para>try：try 语句块中通常用来存放容易出现异常的代码，其后面紧跟一个或多个 catch 语句块；</para>
/// <para>catch：catch 语句块用来捕获 try 语句块中的出现的异常；</para>
/// <para>finally：finally 语句块用于执行特定的语句，不管异常是否被抛出都会执行；</para>
/// <para>throw：throw 用来抛出一个异常。</para>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 使用 try-catch 来捕获程序中的异常
        try
        {
            var a = 123;
            var b = 0;
            var c = a / b;
        }
        catch (Exception e)
        {
            Console.WriteLine($"捕获到的异常：{e}");
        }
        finally
        {
            Console.WriteLine("finally 语句块中的其他代码~");
        }

        try
        {
            TestCustomException.Validate(12);
        }
        catch (InvalidAgeException e)
        {
            Console.WriteLine($"年龄校验失败：{e}");
            // 如果异常是直接或间接派生自 System.Exception 类，则可以在 catch 语句块中使用 throw 语句抛出该异常，
            // 所谓抛出异常这里可以理解为重新引发该异常。throw 语句的语法格式如下所示
            // throw e;
        }

        Console.WriteLine("程序中的其他代码");
    }
}

/// <summary>
/// 自定义异常，建议继承 <see cref="ApplicationException"/>
/// </summary>
public class InvalidAgeException : ApplicationException
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}

public class TestCustomException
{
    public static void Validate(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Sorry, Age must be greater then 18");
        }
    }
}