// 记忆 & 持久化

using System.ClientModel;
using Agent.Framework.Examples.MemoryPersistence.Context;
using Agent.Framework.Examples.MemoryPersistence.Provider;
using Microsoft.Agents.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI;
using OpenAI.Chat;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<ChatMsgContext>(options =>
{
    options.LogTo(Console.WriteLine)
        .UseNpgsql(configuration.GetConnectionString("Default"));
});
serviceCollection.AddScoped<PostgresChatHistoryProvider>();


var apiKey = Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException($"未配置模型接口密钥：{apiKey}");
var client = new OpenAIClient(
    new ApiKeyCredential(apiKey),
    new OpenAIClientOptions
    {
        Endpoint = new Uri("https://api.deepseek.com/v1")
    }
);
var serviceProvider = serviceCollection.BuildServiceProvider();
using var serviceScope = serviceProvider.CreateScope();
var chatClient = client.GetChatClient("deepseek-v4-flash");
var options = new ChatClientAgentOptions
{
    Name = "MemoryAgent",
    ChatOptions = new ChatOptions(),
    ChatHistoryProvider = serviceProvider.GetRequiredService<PostgresChatHistoryProvider>()
};
options.ChatOptions.Instructions = "You are a friendly assistant. Keep your answers brief.";
var agent = chatClient.AsAIAgent(
    options
);
var session = await agent.CreateSessionAsync();

Console.WriteLine(await agent.RunAsync("Hello! What's the square root of 9?", session));
Console.WriteLine(await agent.RunAsync("My name is Alice", session));
Console.WriteLine(await agent.RunAsync("What is my name?", session));
Console.WriteLine("Hello World!");