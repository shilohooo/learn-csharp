namespace CSharpEvent;

/// <summary>
/// <para>c# 中的 Event （事件）</para>
/// <para>可以看作是用户的一系列操作，例如点击键盘的某个按键、单击/移动鼠标等，当事件发生时我们可以针对事件做出一系列的响应，例如退出程序、记录日志等等。</para>
/// <para>C# 中线程之间的通信就是使用事件机制实现的。</para>
/// <para>事件需要在类中声明和触发，并通过委托与事件处理程序关联。事件可以分为发布器和订阅器两个部分，其中发布器是一个包含事件和委托的对象，</para>
/// <para>事件和委托之间的联系也定义在这个类中，发布器类的对象可以触发事件，并使用委托通知其他的对象；</para>
/// <para>订阅器则是一个接收事件并提供事件处理程序的对象，发布器类中的委托调用订阅器类中的方法（事件处理程序）。</para>
/// 
/// <para>有关事件需要注意以下几点：</para>
/// <ul>
///   <li>发布器确定何时触发事件，订阅器确定对事件作出何种响应；</li>
///   <li>一个事件可以拥有多个订阅器，同时订阅器也可以处理来自多个发布器的事件；</li>
///   <li>没有订阅器的事件永远也不会触发；</li>
///   <li>事件通常用于定义针对用户的操作，例如单击某个按钮；</li>
///   <li>如果事件拥有多个订阅器，当事件被触发时会同步调用所有的事件处理程序；</li>
///   <li>在 .NET 类库中，事件基于 EventHandler 委托和 EventArgs 基类。</li>
/// </ul>
/// <para>若要在类中声明一个事件，首先需要为该事件声明一个委托类型，例如：</para>
/// <code>
/// public delegate void DelegateName(string status);
/// </code>
/// <para>然后使用 event 关键字来声明事件本身，如下所示：</para>
/// <code>
/// // 基于上面的委托定义事件
/// public event DelegateName EventName;
/// </code>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 创建事件发布者实例
        var publisher = new Publisher();
        // 创建事件订阅者实例
        var subscriber = new Subscriber();
        // 通过委托创建事件实例
        publisher.MyEvent += new Publisher.MyDelegate(subscriber.Print);
        // 发布事件
        publisher.SetValue($"{DateTime.Now}: 事件触发啦");
    }
}

/// <summary>
/// 事件发布者
/// </summary>
public class Publisher
{
    private string _value;

    /// <summary>
    /// 定义一个委托
    /// </summary>
    /// <param name="val">值</param>
    public delegate void MyDelegate(string val);

    /// <summary>
    /// 基于上面的委托定义一个事件
    /// </summary>
    public event MyDelegate MyEvent;

    public void SetValue(string val)
    {
        _value = val;
        // 发布事件
        MyEvent(_value);
    }
}

/// <summary>
/// 事件订阅者
/// </summary>
public class Subscriber
{
    /// <summary>
    /// 打印消息
    /// </summary>
    /// <param name="msg">消息</param>
    public void Print(string msg)
    {
        Console.WriteLine(msg);
    }
}
