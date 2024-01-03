using System.Globalization;
using System.Windows.Controls;

namespace ValidationRule.Validation;

/// <summary>
/// 年龄验证规则：年龄必须在 1 ~ 100 之间
/// </summary>
public class AgeValidationRule : System.Windows.Controls.ValidationRule
{
    /// <summary>
    /// 设置验证规则
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cultureInfo"></param>
    /// <returns></returns>
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        if (value is null)
        {
            return new ValidationResult(false, "年龄不能为空");
        }

        if (!int.TryParse(value.ToString(), out var age))
        {
            return new ValidationResult(false, "年龄必须为数字");
        }

        return age is < 1 or > 100
            ? new ValidationResult(false, "年龄必须在 1 ~ 100 之间")
            : new ValidationResult(true, null);
    }
}