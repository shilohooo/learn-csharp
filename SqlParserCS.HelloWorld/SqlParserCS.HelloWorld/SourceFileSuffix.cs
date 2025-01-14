using System.ComponentModel;

namespace SqlParserCS.HelloWorld;

/// <summary>
///     代码源文件后缀枚举
/// </summary>
internal enum SourceFileSuffix
{
    [Description("cs")] CSharp,
    [Description("java")] Java,
    [Description("ts")] TypeScript,
    [Description("js")] JavaScript
}