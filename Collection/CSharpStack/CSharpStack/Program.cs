using System.Collections;

namespace CSharpStack;

/// <summary>
/// C# Stack（栈)：表示一个后进先出的对象集合，
/// <remarks>
/// 当需要对项目进行后进先出的访问时，则可以使用堆栈。<br />
/// 向堆栈中添加元素称为推入元素，从堆栈中移除元素称为弹出元素。
/// </remarks>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var stack = new Stack();
        // 添加元素
        stack.Push('A');
        stack.Push('B');
        stack.Push('C');
        stack.Push('D');
        stack.Push('E');

        PrintStack(stack);

        stack.Push('F');
        stack.Push('G');
        Console.WriteLine($"当前栈中下一个可以弹出的值是：{stack.Peek()}");
        PrintStack(stack);

        // 弹出栈中的元素
        Console.WriteLine($"弹出栈中的元素：{stack.Pop()}");
        Console.WriteLine($"弹出栈中的元素：{stack.Pop()}");
        Console.WriteLine($"弹出栈中的元素：{stack.Pop()}");
        PrintStack(stack);
    }

    /// <summary>
    /// 打印栈中的元素
    /// </summary>
    /// <param name="stack">栈对象</param>
    public static void PrintStack(Stack stack)
    {
        Console.WriteLine($"当前栈中包含 {stack.Count} 个元素");
        // 遍历打印堆栈里面的元素
        foreach (var ele in stack)
        {
            Console.Write($"{ele} ");
        }

        Console.WriteLine();
    }
}