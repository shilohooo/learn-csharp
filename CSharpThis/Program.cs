namespace CSharpThis
{
    /// <summary>
    /// this 关键字：用来表示当前对象，可以使用 this 来访问类中的成员。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Website website = new Website("个人主页", "https://github.com/shilohooo");
            website.Display();

            Test test = new Test();
            Console.WriteLine($"_val0 = {test[0]}, _val1 = {test[1]}");
            test[0] = 15;
            test[1] = 20;
            Console.WriteLine($"_val0 = {test[0]}, _val1 = {test[1]}");

            string name = "老李头";
            string url = name.ExpandString();
            Console.WriteLine(url);
        }
    }

    public class Website
    {
        private string name;

        private string url;

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Website()
        {
            Console.WriteLine("无参构造函数");
        }

        /// <summary>
        /// 带参构造函数
        /// <para>使用 this 关键字串联构造函数</para>
        /// <para>这里的 this() 代表无参构造函数</para>
        /// <para>先执行 Website()，再执行Website(string name, string url)</para>
        /// </summary>
        /// <param name="name">网站名称</param>
        /// <param name="url">网站地址</param>
        public Website(string name, string url) : this()
        {
            Console.WriteLine("带参构造函数");

            // 使用 this 关键字访问成员属性
            this.name = name;
            this.url = url;
        }

        public void Display()
        {
            Console.WriteLine($"{name} {url}");
        }
    }

    /// <summary>
    /// 使用 this 作为类的索引器
    /// </summary>
    public class Test
    {
        private int _val0;
        private int _val1;

        /// <summary>
        /// 使用 this 关键字作为类的索引器
        /// </summary>
        public int this[int index]
        {
            get { return 0 == index ? _val0 : _val1; }

            set
            {
                if (0 == index)
                {
                    _val0 = value;
                }
                else
                {
                    _val1 = value;
                }
            }
        }
    }

    public static class StringTest
    {
        public static string ExpandString(this string name)
        {
            Console.WriteLine($"this.name = {name}");
            return $"{name} https://github.com/shilohooo";
        }
    }
}