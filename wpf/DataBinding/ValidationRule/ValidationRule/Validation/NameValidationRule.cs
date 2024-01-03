using System.Globalization;
using System.Windows.Controls;

namespace ValidationRule.Validation;

/// <summary>
/// 人员信息姓名字段校验规则：字段长度只能在 1~10 之间
/// </summary>
public class NameValidationRule : System.Windows.Controls.ValidationRule
{
    /// <summary>
    /// 设置校验规则
    /// </summary>
    /// <param name="value">前端输入的值</param>
    /// <param name="cultureInfo"></param>
    /// <returns></returns>
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        if (value is null)
        {
            return new ValidationResult(false, "姓名不能为空");
        }

        if (value.ToString()?.Length < 1 || value.ToString()?.Length > 10)
        {
            return new ValidationResult(false, "姓名长度只能在 1 ~ 10字符之间");
        }

        return new ValidationResult(true, null);
    }
}