namespace org.shiloh
{
    // 访问修饰符
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.length = 10;
            rectangle.width = 10;
            //rectangle.Init();
            rectangle.Display();
            Console.ReadLine();
        }
    }

    class Rectangle
    {
        // 访问修饰符：public，可以在其他函数和对象中使用 Rectangle的实例进行访问
        // 访问修饰符：private，私有成员，只有同属一个类中的函数可以访问
        // 访问修饰符：internal，同一个 namespace 下的类和方法可以访问

        // 长度
        internal double length;

        // 宽度
        internal double width;

        public void Init()
        {
            length = 10;
            width = 20;
        }

        // 没有任何修饰符，则默认为 private
        double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("长方形的长：{0}", length);
            Console.WriteLine("长方形的宽：{0}", width);
            Console.WriteLine("长方形的面积：{0}", GetArea());
        }
    }
}
