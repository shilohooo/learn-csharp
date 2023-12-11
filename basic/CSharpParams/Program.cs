namespace CSharpParams
{
    // 参数数组，即可变参数列表
    internal class Program
    {
        static void Main(string[] args)
        {
            // 若要使用参数数组，则需要利用 params 关键字，语法格式如下：
            // 访问权限修饰符 返回值类型 函数名 (params 类型名称[] 数组名称)
            // 使用参数数组时，既可以直接为函数传递一个数组作为参数，也可以使用函数名(参数1, 参数2, ..., 参数n)的形式传递若干个具体的值作为参数。
            Program program = new Program();
            Console.WriteLine(program.getSum(1, 2, 3, 4, 5));
            int[] arr = { 1, 2, 3 };
            Console.WriteLine(program.getSum(arr));
        }

        public string getSum(params int[] nums)
        {
            int sum = 0;
            string desc = "";
            foreach (int i in nums)
            {
                sum += i;
                desc += "+ " + i + " ";
            }
            desc = desc.Trim('+');
            desc += "= " + sum;
            return desc;
        }
    }
}
