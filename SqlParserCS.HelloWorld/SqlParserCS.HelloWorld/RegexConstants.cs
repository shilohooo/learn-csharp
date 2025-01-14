using System.Text.RegularExpressions;

namespace SqlParserCS.HelloWorld;

internal static partial class RegexConstants
{
    [GeneratedRegex(@"\((\d+)\)")]
    public static partial Regex LengthPattern();
}