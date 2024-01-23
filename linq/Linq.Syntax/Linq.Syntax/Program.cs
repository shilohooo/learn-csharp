// See https://aka.ms/new-console-template for more information

// Linq 方法语法和查询语法
// 在写Linq查询的时候，可以使用两种形式的语法：查询语法和方法语法
// 方法语法（Method Syntax）：使用标准的方法调用。这些方法是一组叫做标准查询运算符的扩展方法。
// 查询语法（Query Syntax）：看上去和SQL语法很相似，使用查询表达式的形式书写。
// 在一个查询中可以组合这两种形式。
// 方法语法是命令式（imperative）的，它指明了查询方法调用的顺序。
// 查询语法式声明式式（declarative）的，即查询描述的式你想返回的东西，但并没有指明如何执行这个查询。
// 微软推荐使用查询语法，因为它更容易读，能更清晰地表明查询意图，不容易出错。然而，有些运算符必须使用方法语法来书写。

List<int> numbers = [1, 2, 5, 28, 31, 45, 55, 66, 77, 88, 99];
// 查询语法示例：找到小于20的数字
var numsQuery = from n in numbers
    where n < 20
    select n;

Console.WriteLine("================= query syntax start =================");
foreach (var i in numsQuery)
{
    Console.WriteLine(i);
}

Console.WriteLine("================= query syntax end =================");

// 方法语法示例：找到小于20的数字
var numsMethod = numbers.Where(n => n < 20);
Console.WriteLine("================= method syntax start =================");
foreach (var i in numsMethod)
{
    Console.WriteLine(i);
}

Console.WriteLine("================= method syntax end =================");

// 查询语法与方法语法组合
var numsCount = (from n in numbers
    where n < 20
    select n).Count();

Console.WriteLine($"小于20的数字共有 {numsCount} 个");