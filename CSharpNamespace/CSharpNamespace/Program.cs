// 使用 using 关键字引入命名空间

using First;
// 引入嵌套命名空间
using First.Second;

namespace CSharpNamespace
{
    /// <summary>
    /// <para>C#中的命名空间，概念类似Java中的package</para>
    /// <para>可以将命名空间看作是一个范围，用来标注命名空间中成员的归属，</para>
    /// <para>一个命名空间中类与另一个命名空间中同名的类互不冲突，但在同一个命名空间中类的名称必须是唯一的。</para>
    /// <para>可以使用 using 关键字来引用某个命名空间：using namespace;，例如：using System;</para>
    /// <para>命名空间的结构类似于我们计算机系统中的目录，我们可以将某个目录看作是一个命名空间，</para>
    /// <para>在这个目录下可以存在若干不同的文件夹，这些文件夹就可以看作是命名空间下的类。</para>
    /// <para>而在每个文件夹下又存放着一些文件或文件夹，这些文件和文件夹则可以看作是类中的成员。</para>
    /// <para>使用命名空间的好处是可以避免命名冲突，同时也便于查找类的位置。</para>
    /// <para>在 C# 中定义命名空间需要使用 namespace 关键字，语法格式如下：</para>
    /// <code>
    /// namespace NamespaceName {
    ///     // 命名空间中的成员...
    /// }
    /// </code>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var demo1 = new FirstDemo();
            demo1.SayHello();
            var demo2 = new SecondDemo();
            demo2.SayHello();
        }
    }
}

namespace First
{
    public class FirstDemo
    {
        public void SayHello()
        {
            Console.WriteLine("First 命名空间下的 DemoClass 类中的 SayHello 方法");
        }
    }

    // 命名空间嵌套
    namespace Second
    {
        public class SecondDemo
        {
            public void SayHello()
            {
                Console.WriteLine("Second 命名空间下的 DemoClass 类中的 SayHello 方法");
            }
        }
    }
}