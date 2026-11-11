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
var agent = chatClient.AsAIAgent(
    instructions: "You are a friendly assistant. Keep your answers brief.",
    name: "ConversationAgent");
// 创建一个会话，保存对话历史
var session = await agent.CreateSessionAsync();
Console.WriteLine(await agent.RunAsync("我的名字叫张三，喜欢打游戏～",session));
Console.WriteLine(await agent.RunAsync("你对我的印象是啥？",session));