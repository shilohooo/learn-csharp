using System.Text.RegularExpressions;

namespace RegularExpressions;

/// <summary>
/// C# 正则表达式，参考文档：https://c.biancheng.net/csharp/regular-expressions.html
/// </summary>
internal class Program
{
    public const string EmptyStr = "";

    static void Main(string[] args)
    {
        // 匹配以字母 C 开头的词组
        const string text = "C#教程 C语言中文网 c.biancheng.net 正则表达式";
        ShowMatch(text, @"\bC\S*");
        // 匹配以字母 m 开头，字母 e 结尾的单词
        const string text2 = "make maze and manage to measure it.";
        ShowMatch(text2, @"\bm\S*e\b");
        // 去除字符串中多余的空格
        const string text3 = "Hello World :)";
        Console.WriteLine($"原始字符串：{text3}");
        var regex = new Regex("\\s+");
        var result = regex.Replace(text3, EmptyStr);
        Console.WriteLine($"替换后的字符串：{result}");
    }

    /// <summary>
    /// 打印匹配的内容
    /// </summary>
    /// <param name="text">文本内容</param>
    /// <param name="regexp">正则表达式</param>
    public static void ShowMatch(string text, string regexp)
    {
        Console.WriteLine($"文本内容：{text}，正则表达式：{regexp}");
        var matchCollection = Regex.Matches(text, regexp);
        foreach (Match match in matchCollection)
        {
            Console.WriteLine(match);
        }
    }
}