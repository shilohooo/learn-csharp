using System.ComponentModel.DataAnnotations;

namespace Agent.Framework.Examples.MemoryPersistence.Entity;

public class ChatMsgContent
{
    [Key] public long Id { get; set; }

    [MaxLength(30)] [Required] public string Type { get; set; } = "text";

    [MaxLength(int.MaxValue)] public required string Text { get; set; }

    public int OrderNum { get; set; }

    public long MsgId { get; set; }

    public ChatMsg ChatMsg { get; set; } = null!;
}