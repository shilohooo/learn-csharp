using System.ComponentModel.DataAnnotations;

namespace Agent.Framework.Examples.MemoryPersistence.Entity;

public class ChatMsg
{
    [Key] public long Id { get; set; }

    [MaxLength(36)] [Required] public string MsgId { get; set; } = Guid.NewGuid().ToString();

    [MaxLength(255)] public string? AuthorName { get; set; }

    [MaxLength(50)] [Required] public required string Role { get; set; }

    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<ChatMsgContent> Contents { get; set; } = [];
}