// Linq 查询变量
// Linq 查询可以返回两种类型的结果：
// 1. 一个枚举（可枚举的一组数据（IEnumerable），不是枚举类型！），它满足查询参数的列表
// 2. 一个叫做标量（Scalar）的单一值，它是满足查询条件的结果的某种摘要形式

// 查询变量示例

List<int> numbers = [2, 5, 6, 7, 82, 21, 33, 41, 15, 26, 17, 18, 9, 10];
// 返回可枚举的一组数据
var lowNums = from n in numbers
    where n < 20
    select n;

foreach (var lowNum in lowNums)
{
    Console.WriteLine(lowNum);
}

Console.WriteLine("--------------------------------------------------");

// 返回一个整数
var numsCount = (from n in numbers where n < 20 select n).Count();
Console.WriteLine(numsCount);