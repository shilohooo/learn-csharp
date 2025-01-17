using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using JsonParse.Example.Models;
using Pluralize.NET;

namespace JsonParse.Example;

/// <summary>
/// JSON 反序列化 demo
/// </summary>
internal static class Program
{
    private static void Main()
    {
        var jsonStr = File.ReadAllText("data.json");
        // 通过 JsonNode 反序列化，在没有具体的类型时可以使用
        var jsonNode = JsonNode.Parse(jsonStr);
        GenerateEntity(
            jsonNode!.GetValueKind() is JsonValueKind.Array
                // JSON 数组获取第一个元素，再转换成 JsonObject
                ? jsonNode.AsArray()[0]!.AsObject()
                // JSON 对象直接转换成 JsonObject，获取可枚举的键值对列表进行遍历
                : jsonNode.AsObject(),
            "RootObject"
        );
    }

    /// <summary>
    /// 生成实体
    /// <param name="jsonObject">JSON 对象</param>
    /// </summary>
    private static void GenerateEntity(JsonObject jsonObject, string entityName)
    {
        var pluralizer = new Pluralizer();
        var entity = new Entity { Name = entityName };
        foreach (var (key, value) in jsonObject.AsEnumerable())
        {
            switch (value)
            {
                // 对象处理
                case JsonObject:
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
                // 数组处理
                case JsonArray:
                {
                    // 首字母大写
                    var firstLetter = key[0] - 32;
                    var name = (char)firstLetter + key[1..];
                    // 将实体类名称转换为单数形式
                    var singularizeEntityName = pluralizer.Singularize(name);
                    entity.Fields.Add(new Field
                    {
                        Name = key,
                        Type = $"List<{singularizeEntityName}>"
                    });
                    GenerateEntity(value.AsArray()[0]!.AsObject(), singularizeEntityName);
                    continue;
                }
            }

            // 日期处理
            if (DateTimeOffset.TryParse(value?.ToString(), CultureInfo.CurrentCulture, out _))
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
                        JsonValueKind.String => "string",
                        JsonValueKind.Number => value.ToString().Contains('.') ? "double" : "int",
                        JsonValueKind.True => "bool",
                        JsonValueKind.False => "bool",
                        _ => "object"
                    }
                });
            }
        }

        Console.WriteLine(entity);
    }
}