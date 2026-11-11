using StackExchange.Redis;
using StackExchange.Redis.Example;

const string host = "127.0.0.1";
const int port = 6379;
const string pwd = "";
const int defaultDatabase = 0;
await using var redis = await ConnectionMultiplexer.ConnectAsync($"{host}:{port},password={pwd},defaultDatabase={defaultDatabase},allowAdmin=true");
var db = redis.GetDatabase();
var server = redis.GetServer(host, port);

long totalFields = 0;

// server.KeysAsync 会高效地遍历所有匹配的 key，内部自动使用 SCAN
await foreach (var redisKey in server.KeysAsync(pattern: "EcardService:Attendance:AccessCount:1676422860610080768:*", pageSize: 500))
{
    // 判断 key 的类型是否为 Hash
    if (await db.KeyTypeAsync(redisKey) == RedisType.Hash)
    {
        // 累加该 Hash 的字段数量
        var fieldCount = await db.HashLengthAsync(redisKey);
        totalFields += fieldCount;
    }
}

Console.WriteLine($"考勤记录总数：{totalFields}");


IEnumerable<string> testStr = [];
Console.WriteLine(testStr.IsEmpty);

User? user = null;
user?.Name = "shiloh";