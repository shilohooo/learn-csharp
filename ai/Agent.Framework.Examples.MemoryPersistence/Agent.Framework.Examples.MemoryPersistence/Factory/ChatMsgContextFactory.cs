using Agent.Framework.Examples.MemoryPersistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Agent.Framework.Examples.MemoryPersistence.Factory;

public class ChatMsgContextFactory : IDesignTimeDbContextFactory<ChatMsgContext>
{
    public ChatMsgContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ChatMsgContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"))
            .LogTo(Console.WriteLine);
        return new ChatMsgContext(dbContextOptionsBuilder.Options);
    }
}