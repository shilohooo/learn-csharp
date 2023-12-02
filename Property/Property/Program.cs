namespace Property;

/// <summary>
/// <para>C#中的属性（Property）</para>
/// <para>属性是字段的扩展，使用属性的 get 访问器可以读取类中的私有字段，使用属性的 set 访问器可以设置类中私有字段的值</para>
/// <para>属性没有确切的内存位置，但具有可读写或计算（想象一下 vue 的 computed）的访问器。</para>
/// <para>例如有一个名为 Student 的类，其中包含 age、name 和 code 三个私有字段，</para>
/// <para>我们不能在类的范围以外直接访问这些字段，但是可以通过访问属性来访问这些私有字段。</para>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 使用对象初始化器来创建类型实例
        var student = new Student
        {
            // Guid 生成36位唯一ID（带 - 的 UUID） 8567563c-0e26-4979-99ca-6ce3c767ed82
            Code = Guid.NewGuid().ToString(),
            Name = "张三三",
            Age = 15
        };
        Console.WriteLine(student);
        // 修改学生的年龄
        student.Age++;
        Console.WriteLine(student);
    }
}

/// <summary>
/// 抽象属性示例
/// </summary>
public abstract class Person
{
    // 定义抽象属性，这些属性会在子类中实现
    public abstract string? Code { get; set; }
    public abstract string? Name { get; set; }
}

public class Student : Person
{
    // 编码
    private string? _code;

    // 姓名
    private string? _name;

    // 年龄
    private int? _age;

    // 声明属性~
    // 属性命名约定：PascalCase，首字母大写
    public override string? Code
    {
        // 用属性的 get 访问器访问私有字段
        get => _code;
        // 用属性的 set 访问器设置私有字段的值
        set => _code = value;
    }

    // 实现父类的抽象属性
    public override string? Name
    {
        get => _name;
        set => _name = value;
    }

    public int? Age
    {
        get => _age;
        set => _age = value;
    }

    public override string ToString()
    {
        return $"学生信息：编码 = {Code}，姓名 = {Name}，年龄 = {Age}";
    }
}