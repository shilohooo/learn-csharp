namespace CSharpInheritance
{
    /// <summary>
    /// C#中的继承：C#仅支持单继承，要使一个类继承另一个类，需要使用到冒号:，语法格式如下：
    /// <code>
    /// public class SubClass : ParentClass {}
    /// </code>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetWidth(20);
            rectangle.SetLength(15);
            Console.WriteLine($"长方形的面积为：{rectangle.GetArea()}");
            Console.WriteLine($"长方形的周长为：{rectangle.GetGirth()}");
        }
    }

    /// <summary>
    /// 父类：图形
    /// </summary>
    public class Shape
    {
        // 宽度
        protected int Width;

        // 长度
        protected int Length;

        public void SetWidth(int width)
        {
            Width = width;
        }

        public void SetLength(int length)
        {
            Length = length;
        }
    }

    /// <summary>
    /// 接口，可用于实现多重继承
    /// </summary>
    public interface IPerimeter
    {
        /// <summary>
        /// 获取图形的周长
        /// </summary>
        /// <returns>图形的周长</returns>
        int GetGirth();
    }

    /// <summary>
    /// 子类：长方形
    /// </summary>
    public class Rectangle : Shape, IPerimeter
    {
        /// <summary>
        /// 获取长方形的面积
        /// </summary>
        /// <returns>长方形面积</returns>
        public int GetArea()
        {
            return Width * Length;
        }

        public int GetGirth()
        {
            return (Width + Length) * 2;
        }
    }
}