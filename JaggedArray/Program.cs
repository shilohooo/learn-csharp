namespace JaggedArray
{
    // 交错数组
    // 声明语法：data_type[][] array_name;
    internal class Program
    {
        static void Main(string[] args)
        {
            // 假如要声明一个具有三个元素的一维交错数组，并且数组中的每个元素都是一个一维的整型数组，示例代码如下：
            //int[][] jaggedArr = new int[3][];
            // 初始化交错数组
            //jaggedArr[0] = new int[3];
            //jaggedArr[1] = new int[4];
            //jaggedArr[2] = new int[5];
            // 使用具体的值来填充数组，无需指定长度
            //jaggedArr[0] = new int[] { 1, 3, 4, 5 };
            //jaggedArr[1] = new int[] { 2, 3, 4 };
            //jaggedArr[2] = new int[] { 3, 4, 5 };

            // 声明数组并初始化
            //int[][] jaggedArr = new int[][]
            //{
            //    new int[]{1,2,3, 4, 5, 6, 7, 8, 9, 10 },
            //    new int[]{1,2,3, 4, 5, 6, 7, 8, 9, 10 },
            //    new int[]{1,2,3, 4, 5, 6, 7, 8, 9, 10 }
            //};
            //// 访问交错数组中的元素 ==》 2
            //Console.WriteLine(jaggedArr[0][1]);
            //// 将交错数组中的第二个数组元素中的第三个元素的值改为3
            //jaggedArr[1][2] = 3;
            //// 遍历交错数组
            //for (int i = 0; i < jaggedArr.Length; i++)
            //{
            //    for (int j = 0; j < jaggedArr[i].Length; j++)
            //    {
            //        Console.Write("{0} ", jaggedArr[i][j]);
            //    }
            //}

            // 使用交错数组记录学生不同学科的成绩
            string[] names = { "张三", "李四", "王五" };
            string[] courses = { "语文", "数学", "英语" };
            int[][] grades = new int[][] {
                new int[] { 81, 82, 83 },
                new int[] { 91, 92, 93 },
                new int[] { 71, 72, 73 },
            };
            for (int i = 0; i < names.Length; i++)
            {
                string gradeStr = "";
                for (int j = 0; j < grades[i].Length; j++)
                {
                    gradeStr += courses[j] + " " + grades[i][j] + ",";
                }
                Console.WriteLine("{0}的成绩是：{1}", names[i], gradeStr);
            }

        }
    }
}
