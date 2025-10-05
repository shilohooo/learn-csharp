using System.Text.Json;
using StackExchange.Redis;

namespace WebApi.Redis.Example.Helpers;

/// <summary>
/// </summary>
public static class RedisHelper
{
    /// <summary>
    ///     Get actual value by type from <see cref="RedisValue" />
    /// </summary>
    /// <param name="redisValue">value from redis</param>
    /// <param name="jsonSerializerOptions">json serializer options</param>
    /// <typeparam name="T">type of value</typeparam>
    /// <returns>value in specified type</returns>
    public static T? GetValueByType<T>(RedisValue redisValue, JsonSerializerOptions jsonSerializerOptions)
    {
        if (!redisValue.HasValue || redisValue.IsNull || string.IsNullOrWhiteSpace(redisValue)) return default;

        var returnType = typeof(T);
        if (returnType.IsEnum && Enum.TryParse(returnType, redisValue, out var enumVal)) return (T)enumVal;

        if (returnType == typeof(string)) return (T)(object)redisValue.ToString();
        if (returnType == typeof(decimal) && decimal.TryParse(redisValue, out var decimalVal))
            return (T)(object)decimalVal;

        try
        {
            if (!returnType.IsPrimitive)
                return JsonSerializer.Deserialize<T>(redisValue.ToString(), jsonSerializerOptions);

            return (T?)Convert.ChangeType(redisValue, returnType);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Can not convert value: {redisValue} to type: {returnType}");
            Console.WriteLine(e);
            return default;
        }
    }

    /// <summary>
    ///     Get <see cref="RedisValue" /> by type
    /// </summary>
    /// <param name="value">value to set</param>
    /// <param name="jsonSerializerOptions">json serializer options</param>
    /// <typeparam name="T">type of value</typeparam>
    /// <returns>
    ///     <see cref="RedisValue" />
    /// </returns>
    public static RedisValue GetRedisValueByType<T>(T value, JsonSerializerOptions jsonSerializerOptions)
    {
        var returnType = typeof(T);
        // NOTE: do not serialize a string value
        // ERROR: Hello -> "Hello" -> "\"Hello\""
        // Expected: Hello -> Hello -> Hello
        return typeof(T).IsPrimitive || returnType == typeof(string)
            ? value?.ToString()
            : JsonSerializer.Serialize(value, jsonSerializerOptions);
    }
}