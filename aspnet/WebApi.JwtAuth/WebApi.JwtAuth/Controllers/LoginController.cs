using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.JwtAuth.DtoModels;
using WebApi.JwtAuth.Models;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace WebApi.JwtAuth.Controllers;

/// <summary>
/// Login Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class LoginController(IConfiguration config) : ControllerBase
{
    /// <summary>
    /// 登录接口，允许匿名访问
    /// </summary>
    /// <param name="user">登录用户信息</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost]
    public ActionResult<LoginResponseDto> Login([FromBody] UserModel user)
    {
        var authenticatedUser = Authenticate(user);
        if (authenticatedUser is null)
        {
            return Unauthorized();
        }

        return Ok(new LoginResponseDto { AccessToken = GenerateJwtToken(authenticatedUser) });
    }

    /// <summary>
    /// 登录用户身份验证
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>身份验证通过的用户信息</returns>
    private static UserModel? Authenticate(UserModel user)
    {
        // 在这里进行用户身份信息验证
        if (string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Email))
        {
            return null;
        }

        // 忽略用户信息查询等步骤，简单演示
        if (!"123456".Equals(user.Password))
        {
            return null;
        }

        return new UserModel
        {
            Username = user.Username,
            Email = user.Email,
            Password = null,
            DateOfJoin = DateTimeOffset.Now
        };
    }

    /// <summary>
    /// 生成 JWT token
    /// </summary>
    /// <param name="user">身份验证通过的用户信息</param>
    /// <returns>JWT token</returns>
    private string GenerateJwtToken(UserModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username ?? "default-user"),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? "default-email@gmail.com"),
            new Claim("DateOfJoing", user.DateOfJoin.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            // token 生成时间不能早于当前时间
            notBefore: DateTime.Now,
            // token 有效期为30分钟
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}