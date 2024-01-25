// 查询表达式的结构：
// 查询表达式由查询体后的 from 子句组成
// 子句必须按照一定顺序出现
// from 子句和 select / group 子句是必须的
// Linq 查询表达式中，select 子句在表达式最后
// 可以有任何多的 from...let...where 子句

// from 子句
// from 子句指定了要作为数据源使用的数据集合
// 其中的类型说明符 Type 是可以省略的
// 可以有任意多个 join 子句
// from Type Item in Items

// join 子句
// Linq 中的 join 接收两个集合然后创建一个新的集合，每一个元素包含两个原始集合中的原始成员。
// 示例：

Console.WriteLine("================ join 子句示例 ================");

List<Student> students =
[
    new Student { StuId = 1, StuName = "张三", Age = 20 },
    new Student { StuId = 2, StuName = "李四", Age = 19 },
    new Student { StuId = 3, StuName = "王五", Age = 22 },
    new Student { StuId = 4, StuName = "赵六", Age = 20 }
];

List<CourseStudent> courseStudents =
[
    new CourseStudent { CourseName = "C#", StuId = 1 },
    new CourseStudent { CourseName = "Java", StuId = 2 },
    new CourseStudent { CourseName = "C#", StuId = 3 },
];

// 过滤出课程为 C# 的学生的姓名
var queryResult = from s in students
    join c in courseStudents on s.StuId equals c.StuId
    where c.CourseName == "C#"
    select s.StuName;

foreach (var stuName in queryResult)
{
    Console.WriteLine($"上 C# 课程的学生有：{stuName}");
}

Console.WriteLine("================ join 子句示例 ================");
Console.WriteLine();

// 查询主体的 from...let...where 片段
// 可选的 from...let...where 部分是查询主体的第一部分，可以由任意数量的3个子句来组合
// 即 from 子句、let 子句和 where 子句
// from子句
// 查询表达式必须从 from 开始，后面跟的是查询主体。主体本身可以跟任何数量的其他 from 子句，
// 每一个 from 子句都指定了一个额外的源数据集合并引入了要在之后运算的迭代变量。
// 所有 from 子句的语法和含义都一样
// from 子句示例

Console.WriteLine("================ from 子句示例 ================");

List<int> groupA = [3, 4, 5, 6];
List<int> groupB = [6, 7, 8, 9];
var fromClauseResult = from a in groupA
    from b in groupB
    where a is > 4 and <= 8
    select new { a, b, sum = a + b };

foreach (var item in fromClauseResult)
{
    Console.WriteLine(item);
}


Console.WriteLine("================ from 子句示例 ================");
Console.WriteLine();

// let 子句
// let 子句接受一个表达式的运算并且把它赋值给一个需要在其他运算中使用的标识符
// 示例：
Console.WriteLine("================ let 子句示例 ================");

var letClauseResult = from a in groupA
    from b in groupB
    let sum = a + b
    where sum == 12
    select new { a, b, sum };

foreach (var item in letClauseResult)
{
    Console.WriteLine(item);
}

Console.WriteLine("================ let 子句示例 ================");
Console.WriteLine();

// where 子句
// where 子句根据之后的运算来筛选指定项。只要是在 from…let…where 部分中
// 查询表达式可以有多个 where
// 示例：
Console.WriteLine("================ where 子句示例 ================");

var whereClauseResult = from a in groupA
    from b in groupB
    let sum = a + b
    where sum >= 11
    where a == 4
    select new { a, b, sum };

foreach (var item in whereClauseResult)
{
    Console.WriteLine(item);
}

Console.WriteLine("================ where 子句示例 ================");
Console.WriteLine();

// order by 子句
// order by 子句根据表达式按顺序返回结果项
// 可选的 ascending（升序） 和 descending（倒序） 关键字设置了排序方向
// 表达式可以是数值字段，也可以是字符串类型
// order by 子句默认是升序的。
// 可以有任意多子句，它们必须用逗号分隔
// 示例：按照学生年龄排序
Console.WriteLine("================ order by 子句示例 ================");

var orderByClauseResult = from s in students
    orderby s.Age
    select s;
foreach (var student in orderByClauseResult)
{
    Console.WriteLine(student);
}

Console.WriteLine("================ order by 子句示例 ================");
Console.WriteLine();

// select…group 子句
// select 子句指定所选对象的哪部分应该被 select。可以指定下面任意一项：
// 整个数据项
// 数据项的一个字段
// 数据项的几个字段组成的新对象

// group…by 子句是可选的。
// 示例：select 整个数据项
Console.WriteLine("============ select…group 子句示例：select 整个数据项 ============");

var selectFullItems = from s in students
    select s;
foreach (var student in selectFullItems)
{
    Console.WriteLine(student);
}

Console.WriteLine("============ select…group 子句示例：select 整个数据项 ============");
Console.WriteLine();

// 查询中的匿名类型
// 查询结果可以由原始集合的项、项的某些字段或匿名类型组成。
// 示例：使用 select 创建一个匿名类型
Console.WriteLine("======= select…group 子句示例：使用 select 创建一个匿名类型 =======");

var anonymousTypeResult = from s in students
    select new { s.StuId, s.StuName };

foreach (var item in anonymousTypeResult)
{
    Console.WriteLine(item);
}

Console.WriteLine("======= select…group 子句示例：使用 select 创建一个匿名类型 =======");
Console.WriteLine();

// group 子句
// group 子句把 select 的对象根据一些标准进行分组。
// 示例：将学生信息根据年龄进行分组
Console.WriteLine("======= select…group 子句示例：将学生信息根据年龄进行分组 =======");

var groupByResult = from s in students
    group s by s.Age;

// 分组结果类型为 IEnumerable<IGrouping<int, Student>>
foreach (var s in groupByResult)
{
    // 外层循环遍历获取到的类型是 IGrouping<int, Student>，是已经分组后的集合
    // 集合内部元素的类型为：Student
    // 并且 IGrouping<int, Student> 有一个属性 Key，表示分组的标识
    Console.WriteLine($"key: {s.Key}");
    foreach (var t in s)
    {
        // 内层循环遍历获取到的类型是 Student
        Console.WriteLine($"\tvalue: {t}");
    }
}

Console.WriteLine("======= select…group 子句示例：将学生信息根据年龄进行分组 =======");
Console.WriteLine();

// 查询延续：into子句
// 查询延续子句可以接受查询的一部分结果并赋予一个名字，从而可以在查询的另一部分中使用。
// 示例：连接 groupA 和 groupB 并命名为 groupAAndB
Console.WriteLine("================ into 子句示例 ================");

var intoClauseResult = from a in groupA
    join b in groupB on a equals b
        into groupAAndB
    from c in groupAAndB
    select c;

foreach (var i in intoClauseResult)
{
    Console.WriteLine(i);
}

Console.WriteLine("================ into 子句示例 ================");
Console.WriteLine();


/// <summary>
/// 学生实体
/// </summary>
internal class Student
{
    /// <summary>
    /// 主键 ID
    /// </summary>
    public int StuId { get; init; }

    /// <summary>
    /// 学生姓名
    /// </summary>
    public string? StuName { get; init; }

    /// <summary>
    /// 年龄
    /// </summary>
    public int? Age { get; init; }

    public override string ToString()
    {
        return $"StudentInfo(ID: {StuId}, StuName: {StuName}, Age: {Age})";
    }
}

/// <summary>
/// 学生课程实体
/// </summary>
internal class CourseStudent
{
    /// <summary>
    /// 课程名称
    /// </summary>
    public string? CourseName { get; init; }

    /// <summary>
    /// 学生ID，<see cref="Student.StuId"/>
    /// </summary>
    public int StuId { get; init; }
}