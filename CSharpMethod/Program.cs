namespace CSharpMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // 实例化当前类的对象
            Program program = new();
            // 调用定义好的 Greeting 函数
            program.Greeting();
            // 调用定义好的 SayHi 函数，并将字符串 Shiloh 作为参数传递给函数
            program.SayHi("Shiloh");
            // 调用定义好的 GetMsg 函数，传递参数并接收返回值
            String msg = program.GetMsg("Thomas");
            Console.WriteLine(msg);
            // 调用静态函数，接收返回值
            String url = GetUrl("csharp");
            Console.WriteLine(url);
        }

        // 定义一个没有返回值的函数
        public void Greeting()
        {
            Console.WriteLine("我是成员函数");
        }

        // 定义一个有参数但没有返回值的函数
        public void SayHi(String name)
        {
            Console.WriteLine("Hi {0}:)", name);
        }

        // 定义一个有参数且有返回值的函数
        public String GetMsg(String name)
        {
            return "Hello " + name;
        }

        // 定义静态函数，可以直接使用函数名称调用，不需要实例化类的对象
        static String GetUrl(String param)
        {
            return "https://www.baidu.com/s?wd=" + param;
        }
    }
}
