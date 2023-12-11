namespace CSharpConstructor
{
    /// <summary>
    /// 构造函数就是与类（或结构体）具有相同名称的成员函数，
    /// 它在类中的地位比较特殊，不需要我们主动调用，当创建一个类的对象时会自动调用类中的构造函数。
    /// 在程序开发的过程中，我们通常使用类中的构造函数来初始化类中的成员属性。
    /// 
    /// C# 中的构造函数有三种：
    /// 1. 实例构造函数
    /// 2. 静态构造函数
    /// 3. 私有构造函数
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // 只要创建 Person 类的对象，就会调用类中的实例构造函数，我们只需要在实例化对象时将具体的值传递给类中的构造函数即可
            Person person = new Person("shiloh");
            Console.WriteLine(person.Name);

            // 实例化定义了私有构造函数的类会报错
            //Constant constant = new Constant();
            Constant.Name = person.Name;
            Console.WriteLine(Constant.Name);
        }
    }

    /// <summary>
    /// 人员类
    /// </summary>
    public class Person
    {
        // 人员姓名
        public string Name;

        // 静态属性
        public static int Count;

        /// <summary>
        /// 构造函数是类中特殊的成员函数，它的名称与它所在类的名称相同，并且没有返回值。
        /// 当我们使用 new 关键字创建类的对象时，可以使用实例构造函数来创建和初始化类中的任意成员属性。
        /// 
        /// 如果没有为类显式的创建构造函数，那么 C# 将会为这个类隐式的创建一个没有参数的构造函数（无参数构造函数），这个无参的构造函数会在实例化对象时为类中的成员属性设置默认值。
        /// 在结构体中也是如此，如果没有为结构体创建构造函数，那么 C# 将隐式的创建一个无参数的构造函数，用来将每个字段初始化为其默认值。
        /// </summary>
        /// <param name="name">人员姓名</param>
        public Person(string name)
        {
            Console.WriteLine("调用了实例构造函数");
            Name = name;
        }

        /// <summary>
        /// 静态构造函数用于初始化类中的静态数据或执行仅需执行一次的特定操作。静态构造函数将在创建第一个实例或引用类中的静态成员之前自动调用。
        /// 
        /// </summary>
        static Person()
        {
            Console.WriteLine("调用了静态构造函数");
            Count = 1;
        }
    }

    public class Constant
    {
        // 私有构造函数，如果构造函数没有指定访问修饰符，那么它的访问权限默认就是 private
        // 如果一个类中具有一个或多个私有构造函数而没有公共构造函数的话，那么其他类（除嵌套类外）则无法创建该类的实例。
        private Constant() { }

        public static string Name;

        public const double PI = Math.PI;
    }
}
