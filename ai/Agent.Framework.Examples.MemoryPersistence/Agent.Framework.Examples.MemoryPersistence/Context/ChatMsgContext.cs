using Agent.Framework.Examples.MemoryPersistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace Agent.Framework.Examples.MemoryPersistence.Context;

public class ChatMsgContext(DbContextOptions<ChatMsgContext> options) : DbContext(options)
{
    public DbSet<ChatMsg> ChatMessages { get; set; }
    public DbSet<ChatMsgContent> ChatMsgContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ChatMsg>(builder =>
        {
            builder.HasKey(entity => entity.Id);

            builder.HasMany(entity => entity.Contents)
                .WithOne(entity => entity.ChatMsg)
                .HasForeignKey(entity => entity.MsgId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ChatMsgContent>(builder =>
        {
            builder.Property(entity => entity.OrderNum)
                .HasDefaultValue(0);
        });
    }
}