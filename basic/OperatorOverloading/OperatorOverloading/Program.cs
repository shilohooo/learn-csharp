namespace OperatorOverloading
{
    /// <summary>
    /// <para>C# 中支持运算符重载，所谓运算符重载就是我们可以使用自定义类型来重新定义 C# 中大多数运算符的功能。</para>
    /// <para>运算符重载需要通过 operator 关键字后跟运算符的形式来定义的，我们可以将被重新定义的运算符看作是具有特殊名称的函数，</para>
    /// <para>与其他函数一样，该函数也有返回值类型和参数列表，如下例所示：</para>
    /// <code>
    /// public static Box operator+ (Box a, Box b) {
    ///     Box result = new Box();
    ///     result.length = a.length + b.length;
    ///     result.width = a.width + b.width;
    ///     result.height = a.height + b.height;
    ///     return result;
    /// }
    /// </code>
    /// <para>上述函数中实现了对加法运算符+的重载，该函数需要两个 Box 对象参数，并返回一个 Box 对象。</para>
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(3, 4, 5);
            Console.WriteLine($"box1: {box1}");
            Console.WriteLine($"box1 的体积为：{box1.GetVolume()}");

            Box box2 = new Box(6, 7, 8);
            Console.WriteLine($"box2: {box1}");
            Console.WriteLine($"box2 的体积为：{box2.GetVolume()}");

            Box box3 = box1 + box2;
            Console.WriteLine($"box3: {box3}");
            Console.WriteLine($"box3 的体积为：{box3.GetVolume()}");

            Console.WriteLine($"box1是否等于box2：{box1 == box2}");
            Console.WriteLine($"box1是否不等于box2：{box1 != box2}");
            Console.WriteLine($"box1是否大于box2：{box1 > box2}");
            Console.WriteLine($"box1是否小于box2：{box1 < box2}");
            Console.WriteLine($"box1是否大于等于box2：{box1 >= box2}");
            Console.WriteLine($"box1是否小于等于box2：{box1 <= box2}");
        }
    }

    /// <summary>
    /// 运算符重载示例
    /// </summary>
    internal class Box
    {
        // 长度
        private double _length;

        // 宽度
        private double _width;

        // 高度
        private double _height;

        public Box(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        /// <summary>
        /// 获取体积
        /// </summary>
        /// <returns>体积</returns>
        public double GetVolume()
        {
            return _length * _width * _height;
        }

        /// <summary>
        /// 重载加号运算符，把两个 Box 对象相加
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>相加后的 box 对象</returns>
        public static Box operator +(Box a, Box b)
        {
            return new Box(
                a._length + b._length,
                a._width + b._width,
                a._height + b._height
            );
        }

        /// <summary>
        /// 重载二元运算符 ==，== 运算符重载必须成对重载，也就是说还要重载 !=
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 等于 box b 则返回 true，否则返回false</returns>
        public static bool operator ==(Box a, Box b)
        {
            // 盒子的长宽高都相等，两个盒子才算相等
            return a._length.CompareTo(b._length) == 0 &&
                   a._width.CompareTo(b._width) == 0 &&
                   a._height.CompareTo(b._height) == 0;
        }

        /// <summary>
        /// 重载二元运算符 !=，!= 运算符重载必须成对重载，也就是说还要重载 ==
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 不等于 box b 则返回 true，否则返回false</returns>
        public static bool operator !=(Box a, Box b)
        {
            // 盒子的长宽高任意一个不相等，则两个盒子不相等
            return a._length.CompareTo(b._length) != 0 ||
                   a._width.CompareTo(b._width) != 0 ||
                   a._height.CompareTo(b._height) != 0;
        }

        /// <summary>
        /// 重载二元运算符 >，> 运算符重载必须成对重载，也就是说还要重载 <
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 大于 box b 则返回 true，否则返回 false</returns>
        public static bool operator >(Box a, Box b)
        {
            // 盒子 a 的长宽高都大于盒子 b，才算大于
            return a._length.CompareTo(b._length) > 0 &&
                   a._width.CompareTo(a._width) > 0 &&
                   a._height.CompareTo(b._height) > 0;
        }

        /// <summary>
        /// 重载二元运算符 &lt;，&lt; 运算符重载必须成对重载，也就是说还要重载 >
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 大于 box b 则返回 true，否则返回 false</returns>
        public static bool operator <(Box a, Box b)
        {
            // 盒子 a 的长宽高都小于盒子 b，才算小于
            return a._length.CompareTo(b._length) < 0 &&
                   a._width.CompareTo(b._width) < 0 &&
                   a._height.CompareTo(b._height) < 0;
        }

        /// <summary>
        /// 重载二元运算符 >=，>= 运算符重载必须成对重载，也就是说还要重载 &lt;=
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 大于等于 box b 则返回 true，否则返回false</returns>
        public static bool operator >=(Box a, Box b)
        {
            // 盒子 a 的长宽高都大于等于 盒子 b 的长宽高，才算大于等于
            return a._length.CompareTo(b._length) >= 0 &&
                   a._width.CompareTo(b._width) >= 0 &&
                   a._height.CompareTo(b._height) >= 0;
        }

        /// <summary>
        /// 重载二元运算符 &lt;=，&lt;= 运算符重载必须成对重载，也就是说还要重载 >=
        /// </summary>
        /// <param name="a">box a</param>
        /// <param name="b">box b</param>
        /// <returns>如果 box a 小于等于 box b 则返回 true，否则返回false</returns>
        public static bool operator <=(Box a, Box b)
        {
            // 盒子 a 的长宽高都小于等于 盒子 b 的长宽高，才算小于等于
            return a._length.CompareTo(b._length) <= 0 &&
                   a._width.CompareTo(b._width) <= 0 &&
                   a._height.CompareTo(b._height) <= 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            return GetType() == obj.GetType();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 重写 ToString 方法，修改输出该对象时的内容
        /// </summary>
        /// <returns>表示该对象的字符串</returns>
        public override string ToString()
        {
            return $"length: {_length}, width: {_width}, height: {_height}";
        }
    }
}