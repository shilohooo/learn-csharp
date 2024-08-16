namespace WebApi.JwtAuth.DtoModels;

/// <summary>
/// Login response DTO
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// Access token
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
}