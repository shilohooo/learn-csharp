using System.ComponentModel.DataAnnotations;

namespace WebApi.JwtAuth.Models;

/// <summary>
/// User Model
/// </summary>
public class UserModel
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不能为空")]
    public string? Password { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 加入时间
    /// </summary>
    public DateTimeOffset DateOfJoin { get; set; }

    public override string ToString()
    {
        return $"User: [Username: {Username}, Email: {Email}, DateOfJoin: {DateOfJoin}]";
    }
}