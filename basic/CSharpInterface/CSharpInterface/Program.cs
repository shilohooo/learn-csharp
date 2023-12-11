namespace CSharpInterface
{
    /// <summary>
    /// <para>C# 接口：只能声明抽象成员，不能直接实例化</para>
    /// <para>接口中可以包含方法、属性、事件、索引器等成员；</para>
    /// <para>接口命名约定：使用大写字符 I 开头，后续使用PascalCase</para>
    /// <para>接口中成员的访问权限默认为 public，所以我们在定义接口时不用再为接口成员指定任何访问权限修饰符，否则编译器会报错；</para>
    /// <para>在声明接口成员的时候，不能为接口成员编写具体的可执行代码，也就是说，只要在定义成员时指明成员的名称和参数就可以了；</para>
    /// <para>接口一旦被实现（被一个类继承），派生类就必须实现接口中的所有成员，除非派生类本身也是抽象类。</para>
    /// <para>在 C# 中声明接口需要使用 interface 关键字，语法结构如下所示：</para>
    /// <code>
    /// public interface IInterfaceName {
    ///     returnType FunctionName(type parameters);
    ///     returnType FunctionName(type parameters);
    /// }
    /// </code>
    /// <para>其中，InterfaceName 为接口名称，returnType 为返回值类型，funcName 为成员函数的名称，parameterList 为参数列表。</para>
    /// </summary>
    public interface IWebsite
    {
        /// <summary>
        /// 设置网站信息
        /// </summary>
        /// <param name="name">网站名称</param>
        /// <param name="url">网站地址</param>
        void SetVal(string name, string url);

        /// <summary>
        /// 打印网站信息
        /// </summary>
        void Display();
    }

    /// <summary>
    /// 实现接口
    /// </summary>
    public class WebsiteImpl : IWebsite
    {
        private string? _name;
        private string? _url;

        public void SetVal(string name, string url)
        {
            _name = name;
            _url = url;
        }

        public void Display()
        {
            Console.WriteLine($"Website: {_name} {_url}");
        }
    }

    /// <summary>
    /// <para>接口继承：</para>
    /// <para>一个接口可以继承另一个接口，例如可以使用接口 1 继承接口 2，当用某个类来实现接口 1 时，必须同时实现接口 1 和接口 2 中的所有成员</para>
    /// </summary>
    public interface IParent
    {
        void ImplMeParent();
    }

    public interface IChild
    {
        void ImplMeChild();
    }

    public class Demo : IParent, IChild
    {
        public void ImplMeParent()
        {
            Console.WriteLine("实现 IParent 接口中的 ImplMeParent 函数");
        }

        public void ImplMeChild()
        {
            Console.WriteLine("实现 IChild 接口中的 ImplMeChild 函数");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var website = new WebsiteImpl();
            website.SetVal("Homepage", "https://gitee.com/shilohooo");
            website.Display();

            var demo = new Demo();
            demo.ImplMeParent();
            demo.ImplMeChild();
        }
    }
}