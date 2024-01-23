// See https://aka.ms/new-console-template for more information

List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
// 找出所有偶数
// 第一种写法：查询表达式
var evenNumbers = from n in numbers
    where n % 2 == 0
    select n;

foreach (var evenNumber in evenNumbers)
{
    Console.WriteLine(evenNumber);
}

// 第二种写法：lambda 表达式链式调用
var evenNumbers2 = numbers.Where(n => n % 2 == 0)
    .Select(n => n);

foreach (var evenNumber in evenNumbers2)
{
    Console.WriteLine(evenNumber);
}

// 匿名类型
// 匿名类型只能和局部变量配合使用，不能用于类成员
// 由于匿名类型没有名字，必须使用 var 关键字作为变量类型
// 不能设置匿名类型对象的属性。编译器为匿名类型创建的属性是只读的。
var student = new
{
    Name = "shiloh",
    Age = 26,
    Gender = "Male",
    Major = "Computer Science & Technology"
};
Console.WriteLine(
    $"StudentInfo: [Name={student.Name}, Age={student.Age}, Gender={student.Gender}, Major={student.Major}]"
);

// 使用投影初始化语句创建匿名类型
const string major = "History";
var studentInfo = new
{
    Age = 19,
    Other.Name,
    Major = major
};
Console.WriteLine(
    $"StudentInfo2: [Age={studentInfo.Age}, Name={studentInfo.Name}, Major={studentInfo.Major}]"
);

internal abstract class Other
{
    public const string Name = "Bruce Lee";
}