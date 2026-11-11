using System.ClientModel;
using OpenAI;
using OpenAI.Chat;

var apiKey = Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException($"未配置模型接口密钥：{apiKey}");
var client = new OpenAIClient(
    new ApiKeyCredential(apiKey),
    new OpenAIClientOptions
    {
        Endpoint = new Uri("https://api.deepseek.com/v1")
    }
);
var chatClient = client.GetChatClient("deepseek-v4-flash");
var agent = chatClient.AsAIAgent(name: "HelloAgent", description: "你是一个幽默风趣的 AI 助手，喜欢讲冷笑话。");
Console.WriteLine(await agent.RunAsync("世界上最高的山是哪个？"));
await foreach (var update in agent.RunStreamingAsync("说个关于程序员的冷笑话")) Console.WriteLine(update);