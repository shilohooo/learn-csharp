using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using WebApi.Redis.Example.Helpers;

namespace WebApi.Redis.Example.Repository;

/// <summary>
///     Redis Repository
/// </summary>
public class RedisRepository(IConnectionMultiplexer connectionMultiplexer, IOptions<JsonOptions> options)
    : IRedisRepository
{
    private readonly IDatabase _db = connectionMultiplexer.GetDatabase();
    private readonly JsonSerializerOptions _jsonSerializerOptions = options.Value.JsonSerializerOptions;

    /// <inheritdoc />
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _db.StringGetAsync(key);
        return RedisHelper.GetValueByType<T>(value, _jsonSerializerOptions);
    }

    /// <inheritdoc />
    public async Task<T?> HashGetAsync<T>(string key, string fieldName)
    {
        var value = await _db.HashGetAsync(key, fieldName);
        return RedisHelper.GetValueByType<T>(value, _jsonSerializerOptions);
    }

    /// <inheritdoc />
    public async Task<List<T?>> HashGetAllAsync<T>(string key)
    {
        var values = await _db.HashGetAllAsync(key);
        return values.Select(x => RedisHelper.GetValueByType<T>(x.Value, _jsonSerializerOptions))
            .ToList();
    }

    /// <inheritdoc />
    public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        return _db.StringSetAsync(key, RedisHelper.GetRedisValueByType(value, _jsonSerializerOptions), expiry);
    }

    /// <inheritdoc />
    public async Task HashSetAsync<T>(string key, string fieldName, T value)
    {
        await _db.HashSetAsync(key, fieldName, RedisHelper.GetRedisValueByType(value, _jsonSerializerOptions));
    }

    /// <inheritdoc />
    public async Task HashSetAsync<T>(string key, IDictionary<string, T> values)
    {
        await _db.HashSetAsync(
            key,
            values.Select(kvPair => new HashEntry(
                    kvPair.Key, RedisHelper.GetRedisValueByType(kvPair.Value, _jsonSerializerOptions)
                ))
                .ToArray()
        );
    }

    /// <inheritdoc />
    public Task RemoveAsync(string key)
    {
        return _db.KeyDeleteAsync(key);
    }

    /// <inheritdoc />
    public async Task HashRemoveAsync(string key, string fieldName)
    {
        await _db.HashDeleteAsync(key, fieldName);
    }

    /// <inheritdoc />
    public Task<bool> ExistsAsync(string key)
    {
        return _db.KeyExistsAsync(key);
    }
}