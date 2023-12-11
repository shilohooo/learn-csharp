using System.Collections;

namespace CSharpQueue;

/// <summary>
/// C# Queue（队列）：与堆栈类似，它代表了一个先进先出的对象集合，
/// <remarks>
/// 当需要对项目进行先进先出访问时，则可以使用队列。向队列中添加元素称为入队（enqueue），从堆栈中移除元素称为出队（deque）。
/// </remarks>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var queue = new Queue();
        // 元素入队
        queue.Enqueue('A');
        queue.Enqueue('B');
        queue.Enqueue('C');
        queue.Enqueue('D');
        PrintQueue(queue);

        Console.WriteLine("往队列中添加一点元素");
        queue.Enqueue('E');
        queue.Enqueue('F');
        queue.Enqueue('G');
        PrintQueue(queue);

        // 元素出队
        Console.WriteLine($"队列元素: {queue.Dequeue()} 出队");
        Console.WriteLine($"队列元素: {queue.Dequeue()} 出队");
        Console.WriteLine($"队列元素: {queue.Dequeue()} 出队");
        PrintQueue(queue);
    }

    /// <summary>
    /// 打印队列信息
    /// </summary>
    /// <param name="queue">队列</param>
    public static void PrintQueue(Queue queue)
    {
        Console.WriteLine($"当前队列中包含 {queue.Count} 个元素");
        foreach (var ele in queue)
        {
            Console.Write($"{ele} ");
        }

        Console.WriteLine();
    }
}