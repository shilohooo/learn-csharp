namespace CSharpNullable
{
    // 可空类型：可以包含数据类型对应的值和 null
    class Program
    {
        static void Main(string[] args)
        {
            // 声明语法 data_type? variable_name = null;
            int? num;
            int num2 = 33;
            num = null;

            double? d = new double?();
            double? d2 = 3.1415926;
            bool? b = null;

            Console.WriteLine("num = {0}\r\nnum2 = {1}\r\nd = {2}\r\nd2 = {3}\r\nb = {4}\r\n", num, num2, d, d2, b);


            // Null 合并运算符 ??
            // Null 合并运算符用于定义可空类型和引用类型的默认值。如果此运算符的左操作数不为 null，那么运算符将返回左操作数，否则返回右操作数。
            // 例如表达式a ?? b中，如果 a 不为空，那么表达式的值则为 a，反之则为 b。
            // 需要注意的是，Null 合并运算符左右两边操作数的类型必须相同，或者右操作数的类型可以隐式的转换为左操作数的类型，否则将编译错误。
            int? a = null;
            int? c = 123;
            int e;

            e = a ?? 321;
            Console.WriteLine("e = {0}", e);

            e = c ?? 321;
            Console.WriteLine("e = {0}", e);

            Console.ReadLine();


        }
    }
}
