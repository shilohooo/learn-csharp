namespace CSharpParameterTransfer
{
    // 值传递、引用传递、输出传递
    internal class Program
    {
        static void Main(string[] args)
        {
            int val = 10;
            Console.WriteLine("调用函数之前的值：{0}", val);
            Program program = new();
            // 值传递：函数默认的传参方式，将实参的值复制一份传递到函数内部，函数内部修改形参的值，不会影响到实参
            // program.Func(val);

            // 引用传递：实参和形参共同指向同一个内存地址，形参修改后，会影响实参
            // program.Func(ref val);

            // 输出传递：需要使用 out 关键字来使用输出传递
            program.Func(out val);
            Console.WriteLine("调用函数之后的值：{0}", val);
            // 输出传递也可以不为实参赋值
            int a, b;
            program.getValues(out a, out b);
            Console.WriteLine("调用函数之后，a = {0}, b = {1}", a, b);
        }

        public void Func(out int val)
        {
            int temp = 11;
            val = temp;
            val *= val;
        }

        public void getValues(out int x, out int y)
        {
            Console.WriteLine("请输入第一个值：");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入第二个值：");
            y = Convert.ToInt32(Console.ReadLine());
        }
    }
}
