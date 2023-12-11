namespace CSharpEnum
{
    // enum - 枚举，声明语法格式：enum enum_name { enumeration list; }
    // 其中，enum_name 为枚举类型变量的名称；enumeration list 为枚举类型中的成员列表，其中包含若干使用逗号分隔的标识符，每个标识符都代表了一个整数值。
    // 在使用枚举类型时有以下几点需要注意：
    // 枚举类型中不能定义方法；
    // 枚举类型具有固定的常量集；
    // 枚举类型可提高类型的安全性；
    // 枚举类型可以遍历。
    internal class Program
    {
        // 定义一个表示周名称的枚举
        enum Week
        {
            // 枚举代表的整数值从 0 开始，按照声明顺序递增
            Sun,
            Mon,
            Tue,
            Wen,
            Thu,
            Fri,
            Sat
        }

        // 默认情况下，枚举类型中的每个成员都为 int 类型，它们的值从零开始，并按定义顺序依次递增。但是我们也可以显式的为每个枚举类型的成员赋值，如下所示：
        enum ErrorCode
        {
            None,
            Unknown,
            GatewayTimeout = 503,
            NotFound = 404
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Sun = {0}", (int)Week.Sun);
            //Console.WriteLine("Mon = {0}", (int)Week.Mon);
            //Console.WriteLine("Tue = {0}", (int)Week.Tue);
            //Console.WriteLine("Wen = {0}", (int)Week.Wen);
            //Console.WriteLine("Thu = {0}", (int)Week.Thu);
            //Console.WriteLine("Fri = {0}", (int)Week.Fri);
            //Console.WriteLine("Sat = {0}", (int)Week.Sat);

            //Console.WriteLine("None = {0}", (int)ErrorCode.None);
            //Console.WriteLine("Unknown = {0}", (int)ErrorCode.Unknown);
            //Console.WriteLine("GatewayTimeout = {0}", (int)ErrorCode.GatewayTimeout);
            //Console.WriteLine("NotFound = {0}", (int)ErrorCode.NotFound);

            // 使用 Enum.GetValues() 遍历枚举中的所有成员
            foreach (Week week in Enum.GetValues(typeof(Week)))
            {
                Console.WriteLine("{0} = {1}", week, (int)week);
            }
            // 使用 GetNames() 遍历枚举类型中的所有成员名称
            foreach (string week in Enum.GetNames(typeof(Week)))
            {
                Console.WriteLine(week);
            }
        }
    }
}
