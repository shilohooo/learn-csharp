namespace CSharpPolymorphism
{
    /// <summary>
    /// <para>C#中的多态：</para>
    /// <para>编译时多态：通过 C# 中的方法重载和运算符重载来实现编译时多态，也称为静态绑定或早期绑定。</para>
    /// <para>运行时多态：通过方法重载实现的运行时多态，也称为动态绑定或后期绑定。</para>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.print(1);
            program.print(1.123);
            program.print("hello world");
            program.print(true);

            // 运行时多态测试
            Shape shape = new Rectangle(15, 20);
            Console.WriteLine($"图形的面积是：{shape.GetArea()}");
        }

        // 函数重载（编译时多态）
        // 在同一个作用域中，可以定义多个同名的函数，但是这些函数彼此之间必须有所差异，比如参数个数不同或参数类型不同等等，
        // 返回值类型不同除外。

        // 定义一个 print 函数来打印不同的数据类型

        void print(int param)
        {
            Console.WriteLine($"打印 int 类型的数据：{param}");
        }

        void print(double param)
        {
            Console.WriteLine($"打印 double 类型的数据：{param}");
        }

        void print(string param)
        {
            Console.WriteLine($"打印 string 类型的数据：{param}");
        }

        void print(bool param)
        {
            Console.WriteLine($"打印 bool 类型的数据：{param}");
        }
    }

    /// <summary>
    /// 运行时多态，通过抽象类 / 接口实现
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// 获取图形的面积
        /// </summary>
        /// <returns>图形面积</returns>
        public abstract int GetArea();
    }

    /// <summary>
    /// 继承抽象类，实现抽象方法
    /// </summary>
    class Rectangle : Shape
    {
        private int _width;
        private int _length;

        public Rectangle(int width, int length)
        {
            _width = width;
            _length = length;
        }

        /// <summary>
        /// 重写父类方法，以关键字 override 标识
        /// </summary>
        /// <returns>长方形面积</returns>
        public override int GetArea()
        {
            return _width * _length;
        }
    }
}