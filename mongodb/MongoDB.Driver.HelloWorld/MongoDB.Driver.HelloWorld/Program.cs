// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.HelloWorld;

BsonSerializer.RegisterSerializer(new DateOnlySerializer());

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config["MongoDB:ConnectionString"];
var dbName = config["MongoDB:Database"];
var client = new MongoClient(connectionString);
var database = client.GetDatabase(dbName);
var collection = database.GetCollection<User>("Users");

var users = await collection.Find(FilterDefinition<User>.Empty).ToListAsync();
foreach (var user in users) Console.WriteLine(user);

#region Create

var newUser = new User
{
    Name = "bruce lee",
    Age = 33,
    Birthday = DateOnly.FromDateTime(DateTime.Today),
    CreateTime = DateTime.Now,
    UpdateTime = DateTime.Now
};
await collection.InsertOneAsync(newUser);
Console.WriteLine($"newUser Id = {newUser.Id}");

#endregion