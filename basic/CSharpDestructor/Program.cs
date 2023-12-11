namespace CSharpDestructor
{
    /// <summary>
    /// 析构函数：类中的一个特殊成员函数，主要用于在垃圾回收器回收类实例时执行一些必要的清理操作（例如：释放资源）
    /// <para>C# 中的析构函数具有以下特点：</para>
    /// <para>析构函数只能在类中定义，不能用于结构体；</para>
    /// <para>一个类中只能定义一个析构函数；</para>
    /// <para>析构函数不能继承或重载；</para>
    /// <para>析构函数没有返回值；</para>
    /// <para>析构函数是自动调用的，不能手动调用；</para>
    /// <para>析构函数不能使用访问权限修饰符修饰，也不能包含参数。</para>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Student student = new Student();
            Student student1 = new Student();
        }
    }

    public class Student
    {
        public Student()
        {
            Console.WriteLine("调用Student类的构造函数");
        }

        /// <summary>
        /// 析构函数的名称同样与类名相同，不过需要在名称的前面加上一个波浪号 ~ 作为前缀。
        /// </summary>
        ~Student()
        {
            Console.WriteLine("调用Student类的析构函数");
        }
    }
}
