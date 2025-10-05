using WebApi.Redis.Example.Helpers;

namespace WebApi.Redis.Example.Domain;

/// <summary>
///     User entity
/// </summary>
public class UserEntity
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public long SnowflakeId { get; private set; } = SnowflakeIdHelper.GetId();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt => DateTime.Now;
    public DateOnly Birthday => DateOnly.FromDateTime(CreatedAt);
    public TimeOnly PushTime => TimeOnly.FromDateTime(CreatedAt);
    public DateTimeOffset UpdatedAt => DateTimeOffset.Now;
    public bool Enabled { get; set; } = true;
}