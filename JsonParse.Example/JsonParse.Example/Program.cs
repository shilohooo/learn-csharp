using System.Text.Json;
using System.Text.Json.Nodes;
using JsonParse.Example.Models;

namespace JsonParse.Example;

/// <summary>
/// JSON 反序列化 demo
/// </summary>
internal static class Program
{
    private static void Main()
    {
        const string jsonStr = """
                               {
                                 "id": 1,
                                 "username": "shiloh",
                                 "gender": 1,
                                 "birthday": "1998-03-02",
                                 "address": {
                                   "country": "China",
                                   "province": "Guangdong",
                                   "city": "FoShan",
                                   "street": "桂城街道"
                                 },
                                 "enabled": true
                               }
                               """;
        // 通过 JsonNode 反序列化，在没有具体的类型时可以使用
        var jsonNode = JsonNode.Parse(jsonStr);
        // 转换成 JsonObject，获取可枚举的键值对列表进行遍历
        GenerateEntity(jsonNode!.AsObject(), "RootObject");
    }

    /// <summary>
    /// 生成实体
    /// <param name="jsonObject">JSON 对象</param>
    /// </summary>
    private static void GenerateEntity(JsonObject jsonObject, string entityName)
    {
        var entity = new Entity { Name = entityName };
        foreach (var (key, value) in jsonObject.AsEnumerable())
        {
            if (value is JsonObject)
            {
                // 首字母大写
                var firstLetter = key[0] - 32;
                var name = (char)firstLetter + key[1..];
                entity.Fields.Add(new Field
                {
                    Name = key,
                    Type = name
                });
                GenerateEntity(value.AsObject(), name);
                continue;
            }

            if (DateTimeOffset.TryParse(value?.ToString(), out _))
            {
                entity.Fields.Add(new Field
                {
                    Name = key,
                    Type = nameof(DateTime)
                });
            }
            else
            {
                entity.Fields.Add(new Field
                {
                    Name = key,
                    Type = value?.GetValueKind() switch
                    {
                        JsonValueKind.String => nameof(String),
                        JsonValueKind.Number => "int",
                        JsonValueKind.True => "bool",
                        JsonValueKind.False => "bool",
                        JsonValueKind.Array => "List",
                        _ => nameof(Object)
                    }
                });
            }
        }

        Console.WriteLine(entity);
    }
}