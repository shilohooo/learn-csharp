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
var student = new { Name = "shiloh", Age = 26, Gender = "Male", Major = "Computer Science & Technology" };