namespace CSharpMultiDimensionalArray
{
    // C# 多维数组
    internal class Program
    {
        static void Main(string[] args)
        {
            // 声明语法：data_type[,] array_name，与一维数组的区别需要在[]中添加逗号
            // 声明一个二维数组，该数组有3行，4列
            // int[,] arr = new int[3, 4];
            // 声明一个三维数组
            // int[,,] arr2 = new int[3, 3, 3];
            // 多维数组中，最简单的就是二维数组，可以把二维数组看作是一个表格，具有行和列
            // 初始化二维数组
            // 第一种方式
            //int[,] arr = new int[3, 4] {
            //    { 0,1,2,3 },
            //    { 4,5,6,7 },
            //    { 8,9,10,11 }
            //};
            // 第二种初始化方式
            //int[,] arr = new int[,] {
            //    { 0,1,2,3 },
            //    { 4,5,6,7 },
            //    { 8,9,10,11 }
            //};
            //// 访问二维数组
            //Console.WriteLine(arr[0, 1]);

            // 定义一个二维数据并遍历数组中的每个元素
            int[,] arr = new int[3, 4]
            {
                {1,2,3,4 },
                {5,6,7, 8},
                {9,10,11,12},
            };
            // 有几行？
            Console.WriteLine(arr.GetLength(0));
            // 每行有几列？
            Console.WriteLine(arr.GetLength(1));
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("arr[{0},{1}] = {2}", i, j, arr[i, j]);
                }
            }
        }
    }
}
