namespace CSharpClass
{
    /// <summary>
    /// C# 中的类包括状态（成员属性）和操作（成员方法），类的声明语法如下所示：
    /// <code>
    /// access_modifier class_name {
    ///     // 成员属性
    ///     access_modifier data_type variable_name;
    ///     
    ///     // 成员方法
    ///     access_modifier return_type method_name(parameter_list) {
    ///         // 方法体
    ///     }
    /// }
    /// </code>
    /// 访问修饰符可以不指定，如果没有指定，则使用的是默认的访问修饰符：类的默认访问权限是 internal，类中成员的默认访问权限是 private
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // 实例化类
            Student student = new Student(1, "张三", "男", 20);
            // 打印学生信息
            student.Display();
        }
    }

    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        // 成员属性、方法命名约定：https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/identifier-names
        // 编号
        public int Id;
        // 姓名
        public string Name;
        // 性别
        public string Sex;
        // 年龄
        public int Age;

        /// <summary>
        /// 学生信息初始化
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="name">姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="age">年龄</param>
        public Student(int id, string name, string sex, int age)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Age = age;
        }

        /// <summary>
        /// 打印学生信息
        /// </summary>
        public void Display()
        {
            Console.WriteLine("编号：{0}，姓名：{1}，性别：{2}，年龄：{3}", Id, Name, Sex, Age);
        }
    }
}
