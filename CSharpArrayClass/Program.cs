namespace CSharpArrayClass
{
    // Array 类
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[6] { 1, 4, 3, 2, 6, 5 };
            int[] arr2 = new int[6];
            // 获取数组的长度
            Console.WriteLine("数组 arr 的长度为：{0}", arr.Length);
            // 给数组排序
            Array.Sort(arr);
            Console.WriteLine("排序后的 arr 数组为：");
            PrintArr(arr);
            // 查找数组元素的索引
            Console.WriteLine("数组 arr 中值为6的元素的索引为：{0}", Array.IndexOf(arr, 6));
            // 拷贝 arr 到 arr2
            Array.Copy(arr, arr2, arr.Length);
            Console.WriteLine("数组 arr2 为：");
            PrintArr(arr2);
            // 反转数组 arr
            Array.Reverse(arr);
            Console.WriteLine("反序排列数组 arr：");
            PrintArr(arr);
        }

        static void PrintArr(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}
