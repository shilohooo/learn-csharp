// 表达式树入门案例
// 参考资料：https://juejin.cn/post/7155877141068906504
// 什么是表达式？
// 表达式（Expression）在编程语言中是一组值、变量、运算符以及方法调用的组合，它会计算并返回一个值。
// 在C#中，表达式树（Expression Tree）是一种数据结构，它表示代码中的逻辑结构，而不是直接执行代码。
// 最简单的表达式可以由一个左操作数，一个运算符，一个右操作数组成，如：1 + 2
// 表达式树可以转为 Lambda，编译为可执行的委托，通过调用委托可以执行表达式树中的代码。

using System.Linq.Expressions;
using ExpressionTree.Example;

Console.WriteLine("<================================ 无参有返回值 - 求两个数的和 ================================>");
// 左右操作数
var left = Expression.Constant(1, typeof(int));
var right = Expression.Constant(2, typeof(int));
// 运算符
const ExpressionType @operator = ExpressionType.Add;
// 组成加法运算表达式
var addExpr = Expression.MakeBinary(@operator, left, right);
// 创建一个接收表达式运算结果的参数
var parameter = Expression.Parameter(typeof(int), "sum");
// 组成一个赋值的表达式
var assignExpr = Expression.Assign(parameter, addExpr);
Console.WriteLine($"加法运算：左操作数：{addExpr.Left}，运算符：{addExpr.NodeType}，右操作数：{addExpr.Right}");
Console.WriteLine($"赋值表达式：左操作数：{assignExpr.Left}，运算符：{assignExpr.NodeType}，右操作数：{assignExpr.Right}");
// 执行加法运算表达式
var lambda = Expression.Lambda<Func<int>>(addExpr);
Console.WriteLine($"表达式结果：{lambda.Compile().Invoke()}");

Console.WriteLine("<================================ 带参有返回值 - 求某个数的平方 ================================>");
var square = Expression.Constant(2,typeof(int));
var inputParam = Expression.Parameter(typeof(int), "input");
const ExpressionType multiplyOp = ExpressionType.Multiply;
// 组成表达式
var getSquareExpr = Expression.MakeBinary(multiplyOp, inputParam, square);
Console.WriteLine(getSquareExpr);
// 编译为可执行的委托
var getSquareLambda = Expression.Lambda<Func<int,int>>(getSquareExpr,inputParam);
// 执行委托，要传一个参数，具体看 Expression.Lambda方法的 Func<int,int> 泛型定义
// Func = 有参数有返回值，泛型定义的最后一个类型为返回值类型，前面的为参数类型，支持多个参数
var result = getSquareLambda.Compile().Invoke(3);
Console.WriteLine(result);

// 带参数，但是没有返回值的表达式：调用 Console.WriteLine 方法进行输出
Console.WriteLine("<================================ 带参无返回值：输出字符串信息 ================================>");
// 注意参数的类型，要和方法的参数保持一致！！！！
var msgParam = Expression.Parameter(typeof(string), "msg");
var printExpr = Expression.Call(method: typeof(Console).GetMethod("WriteLine", new[] { typeof(string) })!, arg0: msgParam);
Console.WriteLine(printExpr);
// Action = 有参数无返回值，参数类型通过泛型定义，支持多个参数
var printLambda = Expression.Lambda<Action<string>>(printExpr, msgParam);
printLambda.Compile().Invoke("Hello World");

// 访问类的属性
Console.WriteLine("<================================ 访问类的属性 ================================>");
var person = new Person { Name = "John", Age = 30 };
var personParam = Expression.Parameter(typeof(Person), "person");
var nameProperty = Expression.Property(personParam, "Name");
Console.WriteLine($"访问类的属性：{nameProperty}");
var personLambda = Expression.Lambda<Func<Person, string>>(nameProperty, personParam);
Console.WriteLine($"访问类的属性：{personLambda.Compile().Invoke(person)}");

// 以类的属性组成一个表达式，模拟 SQL 查询条件：where T_Person.Age >= 20
Console.WriteLine("<================================ 以类的属性组成一个表达式 ================================>");
var agePropExpr = Expression.Property(personParam, "Age");
var ageConstExpr = Expression.Constant(20, typeof(int));
const ExpressionType goeOperator = ExpressionType.GreaterThanOrEqual;
var ageGoeExpr = Expression.MakeBinary(goeOperator, agePropExpr, ageConstExpr);
Console.WriteLine(ageGoeExpr);
// 转为 lambda 表达式：person => person.Age >= 20
var ageGoeLambda = Expression.Lambda<Func<Person, bool>>(ageGoeExpr, personParam);
Console.WriteLine(ageGoeLambda);
// 传给 IQueryable 的 Where 方法，执行查询
var query = new List<Person> { person }.AsQueryable();
var persons = query.Where(ageGoeLambda).ToList();
foreach (var p in persons)
{
    Console.WriteLine(p);
}
