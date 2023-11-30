﻿namespace Reflection;

/// <summary>
/// <para>c#中的反射：</para>
/// <para>反射（Reflection）是指程序可以访问、检测和修改它本身状态或行为的一种能力，反射中提供了用来描述程序集、模块和类型的对象，</para>
/// <para>可以使用反射动态地创建类型的实例，并将类型绑定到现有对象，或者从现有对象中获取类型，然后调用其方法或访问其字段和属性。</para>
/// <para>如果代码中使用了特性，也可以利用反射来访问它们。</para>
/// <para>反射的用途：</para>
/// <para>在运行时查看视图属性信息</para>
/// <para>检查装配中的各种类型并实例化这些类型</para>
/// <para>在后期绑定到方法和属性</para>
/// <para>在运行时创建新类型，然后使用这些类型执行一些任务</para>
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 初始化 System.Reflection 类的 MemberInfo 对象，用来发现与类关联的属性
        var type = typeof(MyClass);
        var customAttributes = type.GetCustomAttributes(true);
        foreach (var customAttribute in customAttributes)
        {
            Console.WriteLine(customAttribute.ToString());
        }
    }
}

/// <summary>
/// 自定义特性
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : Attribute
{
    // URL
    public readonly string Url;

    // 主题属性
    public string? Topic
    {
        get => _topic;

        set => _topic = value;
    }

    // 私有的主题字段
    private string? _topic;

    public HelpAttribute(string url)
    {
        Url = url;
    }

    public override string ToString()
    {
        return "我是自定义的HelpAttribute特性";
    }
}

[Help("https://www.baidu.com")]
public class MyClass;

[
    AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Method |
        AttributeTargets.Field |
        AttributeTargets.Property,
        AllowMultiple = true
    )
]
public class DebugInfo : Attribute
{
    // bug编号
    private int _bugNo;

    // 开发者名称
    private string _developer;

    // 上次审查代码的日期：yyyy-MM-dd
    private string _lastReviewDate;

    // 开发者信息
    public string Message;

    public DebugInfo(int bugNo, string developer, string lastReviewDate)
    {
        _bugNo = bugNo;
        _developer = developer;
        _lastReviewDate = lastReviewDate;
    }

    public override string ToString()
    {
        return $"bug编号：{_bugNo}, 开发者名称：{_developer}，上次审查代码的日期：{_lastReviewDate}，开发者信息：{Message}";
    }
}

/// <summary>
/// 测试类
/// </summary>
[DebugInfo(1, "shiloh", "2023-11-30", Message = "返回值不匹配")]
[DebugInfo(2, "shiloh", "2023-11-30", Message = "变量未使用")]
public class Rectangle
{
    private int _length;
    private int _width;

    public Rectangle(int length, int width)
    {
        _length = length;
        _width = width;
    }

    [DebugInfo(1, "shiloh", "2023-11-30", Message = "返回值不匹配")]
    public double GetArea()
    {
        return _length * _width;
    }

    [DebugInfo(2, "shiloh", "2023-11-30", Message = "变量未使用")]
    public void Display()
    {
        Console.WriteLine($"length: {_length}, width: {_width}, area: {GetArea()}");
    }
}