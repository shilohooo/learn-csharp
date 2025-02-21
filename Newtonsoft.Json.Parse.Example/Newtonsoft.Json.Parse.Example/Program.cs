// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var jsonStr = await File.ReadAllTextAsync(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Template/data.json"));
var jToken = JToken.Parse(jsonStr);
var jsonSerializerSettings = new JsonSerializerSettings
{
    DateFormatString = "yyyy-MM-dd"
};
var jObject = jToken switch
{
    JObject => JsonConvert.DeserializeObject<JObject>(jsonStr, jsonSerializerSettings),
    JArray => JsonConvert.DeserializeObject<JArray>(jsonStr, jsonSerializerSettings)!.AsEnumerable().OfType<JObject>().First(),
    _ => throw new NotSupportedException()
};

if (jObject is null)
{
    return;
}

foreach (var property in jObject.Properties())
{
    Console.WriteLine($"PropertyName: {property.Name}, ValueType: {property.Value.Type}");
}