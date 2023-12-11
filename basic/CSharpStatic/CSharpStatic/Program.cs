namespace CSharpStatic
{
    /// <summary>
    /// <para>静态成员：使用 static 关键字声明属于类本身而不是实例对象的静态成员，不需要使用对象来访问静态成员。</para>
    /// <para>static 关键字可以修饰变量、函数、构造函数、类、属性、运算符和事件</para>
    /// <para>静态成员可以直接通过 类型.属性名/方法名 的形式访问</para>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // StaticMemberTest.Name = "老李头学C#";
            // Console.WriteLine(StaticMemberTest.Name);

            StaticMemberTest staticMemberTest = new StaticMemberTest();
            staticMemberTest.SetName("老李头学C#");
            StaticMemberTest.PrintName();
            // staticMemberTest.PrintName();

            StaticMemberTest staticMemberTest2 = new StaticMemberTest();
            // staticMemberTest2.PrintName();
            staticMemberTest2.SetName("老李头学CSharp");
            // staticMemberTest.PrintName();
            // staticMemberTest2.PrintName();
            StaticMemberTest.PrintName();
        }
    }

    public class StaticMemberTest
    {
        public static string Name;

        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 静态函数：只能访问静态成员
        /// </summary>
        public static void PrintName()
        {
            Console.WriteLine(Name);
        }
    }
}