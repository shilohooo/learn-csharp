using System;

namespace org.shiloh
{
    class Program
    {
        static void Main(String[] args)
        {
            /* 我的第一个C#程序 */
            //Console.WriteLine("Hello World");

            //Rectangle rectangle = new Rectangle();
            //rectangle.Init();
            //rectangle.Display();

            //Console.WriteLine("int类型的大小为：{0}", sizeof(int));

            //// 动态类型变量，实际是什么类型将在程序运行时检查
            //dynamic val = 123;

            //// 字符串可以用双引号和@加双引号的形式声明
            //String msg = "Hello C#";
            //Console.WriteLine(msg);
            //// 使用@" "形式声明的字符串称为“逐字字符串”，逐字字符串会将转义字符\当作普通字符对待，
            //// 例如string str = @"C:\Windows"; 等价于string str = "C:\\Windows";。
            //// 另外，在@" "形式声明的字符串中可以任意使用换行，换行符及缩进空格等都会计算在字符串的长度之中。
            //String msg2 = @"Hello
            //C#";
            //Console.WriteLine(msg2);

            //// 变量初始化
            //short a;
            //int b;
            //double c;
            //a = 10;
            //b = 20;
            //c = a + b;
            //Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

            //// 接收用户的输入
            //// Console.ReadLine()接收的数据都是字符串类型的，这里使用Convert.ToInt32()将用户输入的内容转换为 int 类型
            //int num1, num2;
            //Console.WriteLine("请输入第一个数字");
            //num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("请输入第二个数字");
            //num2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);

            //// 数据类型转换：隐式类型转换，类型安全，不会丢失数据
            //int numVal = 30;
            //double numVal2 = numVal;
            //Console.WriteLine("numVal2 = {0}", numVal2);
            //// 强制类型转换，需要使用(type)value的形式或预定义函数进行，可能会导致数据丢失
            //double dVal = 123.456;
            //int iVal = (int)dVal;
            //Console.WriteLine("转换前：{0}，转换后：{1}", dVal, iVal);

            // 使用内置的类型转换函数将各种类型的数据转换为字符串类型
            //int a = 111;
            //float b = 222.05f;
            //double c = 333.123;
            //bool d = true;
            //Console.WriteLine(a.ToString());
            //Console.WriteLine(b.ToString());
            //Console.WriteLine(c.ToString());
            //Console.WriteLine(d.ToString());

            // 运算符
            // 算术运算符
            //int a = 10;
            //int b = 20;
            //Console.WriteLine("a + b = {0}", a + b);
            //Console.WriteLine("a - b = {0}", a - b);
            //Console.WriteLine("a * b = {0}", a * b);
            //Console.WriteLine("a / b = {0}", a / b);
            //Console.WriteLine("a % b = {0}", a % b);
            //Console.WriteLine("++a 的值是：{0}", ++a);
            //a = 10;
            //Console.WriteLine("a-- 的值是：{0}", a--);
            //Console.WriteLine("a 的值是：{0}", a);

            // 关系运算符
            //if (a > b)
            //{
            //    Console.WriteLine("a 大于 b");
            //}
            //else
            //{
            //    Console.WriteLine("a 不大于 b");
            //}

            //if (a < b)
            //{
            //    Console.WriteLine("a 小于 b");
            //}
            //else
            //{
            //    Console.WriteLine("a 不小于 b");
            //}

            //if (a == b)
            //{
            //    Console.WriteLine("a 等于 b");
            //}
            //else
            //{
            //    Console.WriteLine("a 不等于 b");
            //}

            //if (a >= b)
            //{
            //    Console.WriteLine("a 大于等于 b");
            //}
            //else
            //{
            //    Console.WriteLine("a 不大于等于 b");
            //}

            //if (a <= b)
            //{
            //    Console.WriteLine("a 小于等于 b");
            //}
            //else
            //{
            //    Console.WriteLine("a 不小于等于 b");
            //}

            // 逻辑运算符
            //bool k = true;
            //bool j = false;
            //if (k && j)
            //{
            //    Console.WriteLine("k && j 为真");
            //}
            //else
            //{
            //    Console.WriteLine("k && j 为假");
            //}

            //if (k || j)
            //{
            //    Console.WriteLine("k || j 为真");
            //}
            //else { Console.WriteLine("k || j 为假"); }

            //if (!(k && j))
            //{
            //    Console.WriteLine("!(k && j) 为真");
            //}
            //else
            //{
            //    Console.WriteLine("!(k && j)为假");
            //}

            // 位运算符
            //int a = 60; // 60的二进制为 0011 1100
            //int b = 13; // 13的二进制为 0000 1101
            //int c = 0; // 0的二进制为 0000 0000

            //// 按位与，对应的二进制位都为1，结果为1，否则为0
            //c = a & b; // c = 12，二进制为 0000 1100
            //Console.WriteLine("a & b 的值是：{0}", c);

            //// 按位或，对应的二进制位都为0，结果为0，否则为1
            //c = a | b; // c = 61，二进制为 0011 1101
            //Console.WriteLine("a | b 的值是：{0}", c);

            //// 按位异或，对应的二进制位相同，结果为0，否则为1
            //c = a ^ b; // c = 49，二进制为 0011 0001
            //Console.WriteLine("a ^ b 的值是：{0}", c);

            //// 按位取反，二进制位1变成0，0变成1
            //c = ~a; // c = -61，二进制为 1100 0011
            //Console.WriteLine("~a 的值是：{0}", c);

            //// 按位左移
            //c = a << 2; // c = 240，二进制为 1111 0000
            //Console.WriteLine("a << 2 的值是：{0}", c);

            //// 按位右移
            //c = a >> 2; // c = 15，二进制为 0000 1111
            //Console.WriteLine("a >> 2 的值是：{0}", c);

            // 赋值运算符
            //int a = 30;
            //int c;

            //// 赋值
            //c = a;
            //Console.WriteLine("c = a 的值为：{0}", c);
            //// 加且赋值
            //c += a;
            //Console.WriteLine("c += a 的值为：{0}", c);
            //// 减且赋值
            //c -= a;
            //Console.WriteLine("c -= a 的值为：{0}", c);
            //// 乘且赋值
            //c *= a;
            //Console.WriteLine("c *= a 的值为：{0}", c);
            //// 除且赋值
            //c /= a;
            //Console.WriteLine("c /= a 的值为：{0}", c);
            //// 求模且赋值
            //c %= a;
            //Console.WriteLine("c %= a 的值为：{0}", c);
            //// 右移且赋值
            //c >>= a;
            //Console.WriteLine("c >>= a 的值为：{0}", c);
            //// 左移且赋值
            //c <<= a;
            //Console.WriteLine("c <<= a 的值为：{0}", c);
            //// 按位与且赋值
            //c &= a;
            //Console.WriteLine("c &= a 的值为：{0}", c);
            //// 按位或且赋值
            //c |= a;
            //Console.WriteLine("c |= a 的值为：{0}", c);
            //// 按位异或且赋值
            //c ^= a;
            //Console.WriteLine("c ^= a 的值为：{0}", c);

            // 其他的运算符
            // sizeof 返回数据类型的大小
            //Console.WriteLine("int 类型的大小是：{0}", sizeof(int));
            //Console.WriteLine("short类型的大小是：{0}", sizeof(short));
            //Console.WriteLine("double 类型的大小是：{0}", sizeof(double));

            //// ?: 三元运算符
            //int a = 11;
            //int b;
            //b = (a == 1) ? 20 : 30;
            //Console.WriteLine("b 的值是：{0}", b);

            //b = (a == 11) ? 20 : 30;
            //Console.WriteLine("b 的值是：{0}", b);

            // 运算符优先级
            //int a = 12;
            //int b = 34;
            //int c = 56;
            //int d = 7;
            //int e;

            //e = (a + b) * c / d;
            //Console.WriteLine("(a + b) * c / d 的值是：{0}", e);

            //e = ((a + b) * c) / d;
            //Console.WriteLine("((a + b) * c) / d 的值是：{0}", e);

            //e = (a + b) * (c / d);
            //Console.WriteLine("(a + b) * (c / d) 的值是：{0}", e);

            //e = a + (b * c) / d;
            //Console.WriteLine("a + (b * c) / d 的值是：{0}", e);

            // 常量：值在程序编译阶段已经确定，且运行时不能修改，可以是整数、浮点数、字符串类型等。
            // 定义常量：const data_type constant_name = value;
            // 其中：data_type = 数据类型，constant_name = 常量名称，value = 常量值

            //const double pi = 3.14;
            //Console.WriteLine("本程序可以自动计算圆的面积，请输入圆的半径：");
            //double r = Convert.ToDouble(Console.ReadLine());
            //double area = pi * r * r;
            //Console.WriteLine("半径为：{0}，圆的面积是：{1}", r, area);

            // 整数常量：可以是八进制、十进制、十六进制，可以使用前缀指定具体的进制，例如0x或0X表示十六进制，0表示八进制，没有前缀则表示十进制。
            // 除了前缀外，整数常量还可以包含后缀，后缀可以是U和L的组合（不区分大小写，但是不能重复），U和L分别表示unsigned和long。

            //const int decimalConst = 10; // 合法的十进制常量
            //Console.WriteLine(decimalConst);

            //const int octalConst = 0213; // 合法的八进制常量
            //Console.WriteLine(octalConst);

            //const int hexConst = 0x4b; // 合法的十六进制常量
            //Console.WriteLine(hexConst);

            //const int intConst = 30; // 合法的 int 类型常量
            //Console.WriteLine(intConst);

            //const uint unsignedIntConst = 30U; // 合法的无符号 int 类型常量
            //Console.WriteLine(unsignedIntConst);

            //const long longConst = 30L; // 合法的 long 类型常量
            //Console.WriteLine(longConst);

            //const ulong ulongConst = 30UL; // 合法的无符号 long 类型常量
            //Console.WriteLine(ulongConst);

            //// 字符串常量
            //Console.WriteLine("百度一下\thttps://www.baidu.com\n");
            //Console.WriteLine(@"百度一下\thttps://www.baidu.com\n");

            // 条件分支：if else
            //int num = 12;
            //if (num % 2 == 0)
            //{
            //    Console.WriteLine("{0} 是一个偶数", num);
            //}

            //int inputNum;
            //Console.WriteLine("请输入一个数字");
            //inputNum = Convert.ToInt32(Console.ReadLine());
            //if (inputNum % 2 == 0)
            //{
            //    Console.WriteLine("{0} 是偶数", inputNum);
            //}
            //else
            //{
            //    Console.WriteLine("{0} 是奇数", inputNum);
            //}

            //int grade;
            //Console.WriteLine("请输入学生成绩");
            //grade = Convert.ToInt32(Console.ReadLine());
            //if (grade < 0 || grade > 100)
            //{
            //    Console.WriteLine("您输入的成绩有误！");
            //}
            //else if (grade >= 0 && grade < 60)
            //{
            //    Console.WriteLine("不及格");
            //}
            //else if (grade >= 60 && grade < 70)
            //{
            //    Console.WriteLine("及格");
            //}
            //else if (grade >= 70 && grade < 80)
            //{
            //    Console.WriteLine("中等");
            //}
            //else if (grade >= 80 && grade < 90)
            //{
            //    Console.WriteLine("良好");
            //}
            //else if (grade >= 90 && grade <= 100)
            //{
            //    Console.WriteLine("优秀");
            //}

            // 条件分支：switch 语句
            //Console.WriteLine("请输入学生分数（0~100）");
            //int grade = Convert.ToInt32(Console.ReadLine());
            //switch (grade / 10)
            //{
            //    case 10:
            //    case 9:
            //        Console.WriteLine("优秀");
            //        break;
            //    case 8:
            //        Console.WriteLine("良好");
            //        break;
            //    case 7:
            //    case 6:
            //        Console.WriteLine("及格");
            //        break;
            //    default:
            //        Console.WriteLine("不及格");
            //        break;
            //}

            // 循环分支：for循环
            // 使用 for 循环输出 0 ~ 9 之间的数字
            //for (int i = 0; i <= 9; i++)
            //{
            //    // Console.Write 不会换行
            //    Console.Write("{0} ", i);
            //}
            //Console.WriteLine();
            //// 嵌套 for 循环
            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("{0} x {1} = {2}\t", j, i, i * j);
            //    }
            //    Console.WriteLine();
            //}
            // 死循环
            //for (; ; )
            //{
            //    Console.WriteLine("死循环了！！！！！！");
            //}

            // while 循环，多用于迭代次数不固定的情况，如果迭代次数是固定的，建议使用 for 循环
            // 使用 while 循环输出 0 ~ 9 之间的数字
            //int i = 0;
            //while (i <= 9)
            //{
            //    Console.Write("{0}\t", i);
            //    i++;
            //}
            // while 循环也可以嵌套，使用 while 嵌套循环输出九九乘法表
            //int i = 1;
            //while (i <= 9)
            //{
            //    int j = 1;
            //    while (j <= i)
            //    {
            //        Console.Write("{0} * {1} = {2}\t", j, i, j * i);
            //        j++;
            //    }
            //    i++;
            //    Console.WriteLine();
            //}

            // do while 循环：不管表达式的结果如何，循环体至少会执行一次
            // 输出 0 ~ 9 之间的数字
            //int i = 0;
            //do
            //{
            //    Console.Write("{0} ", i);
            //    i++;
            //} while (i <= 9);
            // do while 循环同样支持嵌套，这里使用 do while 嵌套循环输出一下

            // foreach 循环
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            //foreach (int i in arr)
            //{
            //    Console.Write("{0} ", i);
            //}
            //Console.WriteLine();
            //// 使用 for 循环定义一个包含 1~100 以内所有数字的数组，然后使用 foreach 循环计算 1~100 以内所有数字的和
            //int[] arr2 = new int[100];
            //for (int i = 0; i < 100; i++)
            //{
            //    arr2[i] = i + 1;
            //}
            //int sum = 0;
            //foreach (int i in arr2)
            //{
            //    sum += i;
            //}
            //Console.WriteLine("100以内所有数字加起来等于：{0}", sum);

            // break、continue、goto
            // break：可以跳出循环体，执行下一个语句，如果在嵌套循环内使用 break 语句，那么只会跳出内层循环，而不会影响外层循环
            // 输出 0 ~ 9 之间的数字，输出到 5 时跳出循环
            //for (int i = 0; i <= 9; i++)
            //{
            //    Console.Write("{0} ", i);
            //    if (i == 5)
            //    {
            //        break;
            //    }
            //}
            //Console.WriteLine();

            //// continue：跳过本次循环，继续执行下一次循环
            //// 输出 0 ~ 9 之间的数字，遇到 5 时跳过
            //for (int i = 0; i <= 9; i++)
            //{
            //    if (i == 5)
            //    {
            //        continue;
            //    }
            //    Console.Write("{0} ", i);
            //}

            // goto：也称为跳转语句，使用它可以控制程序跳转到指定的位置执行。
            // goto Labels;
            // 语句块1;
            // Labels:
            // 语句块2;
            // 想要使用 goto 语句来跳转程序，必须先在想要跳转的位置定义好一个标签（Labels），标签名称的定义和变量名类似，然后使用goto 标签名;
            // 即可使程序跳转到指定位置执行。如上面语法中所示，程序会跳过“语句块1”直接执行“语句块2”。
            int count = 1;
            login:
            Console.WriteLine("请输入用户名");
            string username = Console.ReadLine();
            Console.WriteLine("请输入密码");
            string password = Console.ReadLine();
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("登录成功");
            }
            else
            {
                count++;
                if (count > 3)
                {
                    Console.WriteLine("用户名或密码错误次数过多！程序退出！");
                }
                else
                {
                    Console.WriteLine("用户名或密码错误");
                    goto login;
                }
            }

            Console.ReadKey();
        }
    }

    // 一个命名空间下可以有多个class
    class Rectangle
    {
        // 成员变量
        double length;
        double width;

        // 成员函数
        public void Init()
        {
            length = 4.5;
            width = 3.5;
        }

        public double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}