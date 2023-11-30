namespace CSharpString
{
    // 字符串
    internal class Program
    {
        static void Main(string[] args)
        {
            // 使用常规字符串为字符串变量赋值
            //string name = "shiloh595";
            //// 字符串拼接
            //string greeting = "Hello " + name;
            //Console.WriteLine(greeting);
            //// 使用 System.String.Empty 定义一个空字符串
            //string emptyStr = string.Empty;
            //Console.WriteLine(emptyStr);
            //// 使用 String 类
            //String url = "https://github.com/shilohooo";
            //Console.WriteLine(url);
            //// 局部变量（即在方法体中定义的变量）可以使用 var 关键字来代替具体的数据类型来定义变量
            //var temp = "学习 C# 字符串";
            //Console.WriteLine(temp);
            //// 定义一个常量字符串
            //const string constStr = "我是一个常量字符串~";
            //Console.WriteLine(constStr);
            //// 使用字符串构造函数定义字符串
            //char[] letters = { 'h', 'e', 'l', 'l', 'o' };
            //string msg = new string(letters);
            //Console.WriteLine(msg);

            // 比较两个字符串是否相等
            //string str1 = "https://github.com/shilohooo";
            //string str2 = "github.com";
            //if (String.Compare(str1, str2) == 0)
            //{
            //    Console.WriteLine("{0} 和 {1} 相同", str1, str2);
            //}
            //else
            //{
            //    Console.WriteLine("{0} 和 {1} 不相同", str1, str2);
            //}
            //Console.WriteLine(str1.Equals(str2));

            // 从一个字符串中截取指定长度的字符串
            //string url = "https://www.baidu.com";
            //Console.WriteLine("原字符串：{0}", url);
            //string domain = url.Substring(8);
            //Console.WriteLine("截取之后的字符串为：{0}", domain);

            // 将数组中的元素合并为字符串
            string[] arr = new string[] {
                "Hello",
                "World"
            };
            string message = string.Join(" ", arr);
            Console.WriteLine(message);
        }
    }
}
