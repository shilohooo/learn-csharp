// See https://aka.ms/new-console-template for more information

// Redis Client 哨兵连接测试
using CSRedis;

Console.WriteLine("start connect to redis sentinel");
// 连接字符串，连的是哨兵
const string connectionString = "mymaster,password=cuckoo@20#24!,defaultDatabase=0";
// 哨兵连接地址，可以有多个
string[] sentinels = ["110.41.189.65:29736", "110.41.189.65:29737", "110.41.189.65:29738"];
var client = new CSRedisClient(connectionString, sentinels);
// var client = new CSRedisClient("110.41.189.65:39736,password=cuckoo@20#24!,defaultDatabase=0");
RedisHelper.Initialization(client);
var deployMode = await RedisHelper.GetAsync<string>("DeployMode");
Console.WriteLine(deployMode);