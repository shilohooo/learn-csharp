namespace CSharpArray
{
    // C# 中的数组
    internal class Program
    {
        static void Main(string[] args)
        {
            // 声明语法：data_type[] array_name;
            int[] arr;
            // 初始化数组，长度为 10，表示可以存放10个元素，
            // 编译器会根据数组类型隐式的为数组中的每个元素初始化一个默认值，例如 int 类型的数组中所有元素都会被初始化为0
            arr = new int[10];
            // 为数组中的元素赋值，将第一个元素赋值为1
            arr[0] = 1;
            // 声明数组的同时初始化数组
            int[] arr2 = new int[10];
            // 声明数组的同时为数组的元素赋值
            int[] arr3 = { 1, 2, 3 };
            // 声明数组的同时，提前设定长度，并为数组元素赋值
            int[] arr4 = new int[3] { 1, 2, 3 };
            // 访问数组中的元素
            Console.WriteLine(arr4[0]);
            // 使用 for 循环访问数组中的每一个元素
            for (int i = 0; i < arr4.Length; i++)
            {
                Console.WriteLine("arr4[{0}] = {1}", i, arr4[i]);
            }
            // 使用 foreach 遍历数组
            int index = 0;
            foreach (int i in arr4)
            {
                Console.WriteLine("arr4[{0}] = {1}", index, i);
                index++;
            }
        }
    }
}
