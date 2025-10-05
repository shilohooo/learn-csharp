using WebApi.Redis.Example.Repository;

namespace WebApi.Redis.Example.Services;

/// <summary>
///     Redis service
/// </summary>
public class RedisService(IRedisRepository redisRepository) : IRedisService
{
    /// <inheritdoc />
    public async Task<T?> GetAsync<T>(string key)
    {
        return await redisRepository.GetAsync<T>(key);
    }

    /// <inheritdoc />
    public async Task<T?> HashGetAsync<T>(string key, string fieldName)
    {
        return await redisRepository.HashGetAsync<T>(key, fieldName);
    }

    /// <inheritdoc />
    public async Task<List<T?>> HashGetAllAsync<T>(string key)
    {
        return await redisRepository.HashGetAllAsync<T>(key);
    }

    /// <inheritdoc />
    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        await redisRepository.SetAsync(key, value, expiry);
    }

    /// <inheritdoc />
    public async Task HashSetAsync<T>(string key, string fieldName, T value)
    {
        await redisRepository.HashSetAsync(key, fieldName, value);
    }

    /// <inheritdoc />
    public async Task HashSetAsync<T>(string key, IDictionary<string, T> values)
    {
        await redisRepository.HashSetAsync(key, values);
    }

    /// <inheritdoc />
    public async Task RemoveAsync(string key)
    {
        await redisRepository.RemoveAsync(key);
    }

    /// <inheritdoc />
    public async Task HashRemoveAsync(string key, string fieldName)
    {
        await redisRepository.HashRemoveAsync(key, fieldName);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsAsync(string key)
    {
        return await redisRepository.ExistsAsync(key);
    }
}