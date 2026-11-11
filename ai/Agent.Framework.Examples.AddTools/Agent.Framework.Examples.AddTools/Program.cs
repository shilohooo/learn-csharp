using System.ClientModel;
using System.ComponentModel;
using Microsoft.Extensions.AI;
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
var agent = chatClient.AsAIAgent(name: "DeepSeekV4Flash", instructions: "You are a helpful assistant",
    // 定义 agent 可以使用的工具集
    tools: [AIFunctionFactory.Create(GetWeather)]);
Console.WriteLine(await agent.RunAsync("What is the weather like in Amsterdam?"));
await foreach (var update in agent.RunStreamingAsync("What is the weather like in BeiJing,China？"))
    Console.WriteLine(update);
return;

// 定义一个方法，作为工具给 agent 调用
// [Description] 特效用于描述这个工具是干啥用的
static string GetWeather([Description("The location to get the weather for.")] string location)
{
    return $"The weather in {location} is cloudy with a high of 15℃";
}