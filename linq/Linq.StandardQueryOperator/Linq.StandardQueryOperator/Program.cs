// Linq：标准查询运算符
// 标准查询运算符由一系列API方法组成，它能让我们查询任何.NET数组或集合。
// 被查询的集合对象叫做序列，它必须实现IEnumerable<T>接口，T是类型。
// 标准查询运算符使用方法语法。
// 一些运算符返回IEnumerable对象，而其他的一些运算符返回标量。返回标量的运算符立即执行，并返回一个值。
// 很多操作都以一个谓词作为参数。
// 注意：标准查询运算符可用来操作一个或多个序列。
// 序列是指实现了IEnumerable<>的类型，包括List<>、Dictionary<>、Stack<>、Array<>等。
// 标准查询运算符参考：https://hzd.plus/2019/08/26/C-%E5%9B%BE%E8%A7%A3%E6%95%99%E7%A8%8B%E4%B9%8BLINQ/#%E6%A0%87%E5%87%86%E6%9F%A5%E8%AF%A2%E8%BF%90%E7%AE%97%E7%AC%A6
// 示例：Sum 和 Count 运算符的作用。

List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var sum = numbers.Sum();
var count = numbers.Count();
Console.WriteLine($"Sum: {sum}, Count: {count}");
Console.WriteLine();

// 标准查询运算符的签名
// System.Linq.Enumerable类声明了标准查询运算符方法。
// 示例：直接调用扩展方法和将其作为扩展进行调用的不同。
// 方法语法
var count2 = Enumerable.Count(numbers);
var firstNum = Enumerable.First(numbers);
Console.WriteLine($"Count2: {count2}, First Number: {firstNum}");
// 扩展语法
var count3 = numbers.Count();
var firstNum2 = numbers.First();
Console.WriteLine($"Count3: {count3}, First Number2: {firstNum2}");
Console.WriteLine();

// 查询表达式与标准查询运算符的组合
// 编译器会把每个查询表达式翻译成标准查询运算符的形式。
var lessThanSevenCount = (from n in numbers where n < 7 select n).Count();
Console.WriteLine($"Less than 7 Count: {lessThanSevenCount}");
Console.WriteLine();


// 将委托作为参数
// 每个运算符的第一个参数是IEnumerable<T>对象的引用，之后的参数可以是任何类型。
// 很多运算符接受泛型委托作为参数，泛型委托用于给运算符提供用户自定义代码。
// 示例：使用委托作为参数
var myDelegate = new Func<int, bool>(IsOdd);
var oddNumCount = numbers.Count(myDelegate);
Console.WriteLine($"Odd Number Count: {oddNumCount}");
Console.WriteLine();

// 使用 lambda 表达式参数
var oddNumCountUsingLambda = numbers.Count(x => x % 2 != 1);
Console.WriteLine($"Odd Number Count Using Lambda: {oddNumCountUsingLambda}");
Console.WriteLine();

// 使用匿名方法替代 lambda 表达式
var anonymousMethod = delegate(int x) { return x % 2 != 0; };
var oddNumCount2 = numbers.Count(anonymousMethod);
Console.WriteLine($"Odd Number Count Using Anonymous Method: {oddNumCount2}");
Console.WriteLine();

return;

// 判断一个数是否为奇数
bool IsOdd(int num) => num % 2 != 0;