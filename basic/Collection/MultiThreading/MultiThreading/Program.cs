namespace MultiThreading;

/// <summary>
/// c# 多线程：多线程就是多个线程同时工作的过程，可以将线程看作是程序的执行路径，每个线程都定义了一个独特的控制流，用来完成特定的任务。
/// 如果应用程序涉及到复杂且耗时的操作，那么使用多线程来执行是非常有益的。使用多线程可以节省 CPU 资源，同时提高应用程序的执行效率，
/// 例如现代操作系统对并发编程的实现就用到了多线程。单线程的应用程序一次只能执行一个任务。
/// <remarks>
/// <para>线程生命周期：</para>
/// <para>线程生命周期开始于创建 System.Threading.Thread 类对象的时候，当线程被终止或完成执行时生命周期终止</para>
/// <para>下面列出了线程生命周期中的各种状态：</para>
/// <para>未启动状态：当线程实例被创建但 Start 方法未被调用时的状况</para>
/// <para>就绪状态：当线程准备好运行并等待 CPU 周期时的状况</para>
/// <para>不可运行状态：下面的几种情况下线程是不可运行的：</para>
/// <para>已经调用 Sleep 方法</para>
/// <para>已经调用 Wait 方法</para>
/// <para>通过 I/O 操作阻塞</para>
/// <para>死亡状态：当线程已完成执行或已中止时的状况</para>
/// <para>线程状态定义在 <see cref="ThreadState"/></para>
/// <para>主线程：</para>
/// <para>在 C# 中，System.Threading.Thread 类用于处理线程，它允许在多线程应用程序中创建和访问各个线程。</para>
/// <para>
/// 在多线程中执行的第一个线程称为主线程，当 C# 程序开始执行时，将自动创建主线程，而使用 Thread 类创建的线程则称为子线程，
/// 可以使用 Thread 类的 CurrentThread 属性访问线程。
/// </para>
/// </remarks>
/// </summary>
class Program
{
    public static void CallToThread()
    {
        Console.WriteLine("子线程正在运行~");
        // // 通过调用线程的 sleep 方法来暂停当前线程
        // const int sleepTimeMs = 5000;
        // Console.WriteLine($"{DateTime.Now} - 子线程暂停 {sleepTimeMs / 1000} 秒");
        // Thread.Sleep(sleepTimeMs);
        // Console.WriteLine($"{DateTime.Now} - 继续执行子线程");

        // 销毁线程：调用线程的 Abort 方法会抛出一个 ThreadAbortException 异常来终止线程，
        // 该异常不能被捕获
        try
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i);
            }

            Console.WriteLine("子线程执行完成~");
        }
        catch (ThreadAbortException e)
        {
            Console.WriteLine($"线程终止：{e}");
        }
        finally
        {
            Console.WriteLine("无法捕获线程异常");
        }
    }

    static void Main(string[] args)
    {
        // 获取当前正在执行的线程实例
        // var currentThread = Thread.CurrentThread;
        // currentThread.Name = "主线程";
        // Console.WriteLine($"当前正在执行的线程名称为：{currentThread.Name}");
        // // IsAlive 属性：如果当前线程已启动，且还没死亡，则返回 true
        // Console.WriteLine($"当前线程的状态：{currentThread.ThreadState}");
        // Console.WriteLine($"当前线程是否已启动，且还没死亡：{currentThread.IsAlive}");

        // 创建子线程
        var threadStart = new ThreadStart(CallToThread);
        Console.WriteLine("在Main函数创建子线程");
        var thread = new Thread(threadStart);
        // 启动子线程
        thread.Start();
        // 停止主线程一段时间
        Thread.Sleep(2000);
        // 终止子线程的运行
        Console.WriteLine("在 Main 函数中终止子线程运行");
        thread.Abort();
    }
}