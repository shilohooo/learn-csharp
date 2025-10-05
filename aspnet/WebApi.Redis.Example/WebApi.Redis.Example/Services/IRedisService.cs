namespace WebApi.Redis.Example.Services;

/// <summary>
///     Redis service abstraction
/// </summary>
public interface IRedisService
{
    /// <summary>
    ///     Get value from redis
    /// </summary>
    /// <param name="key">key</param>
    /// <typeparam name="T">value type</typeparam>
    /// <returns>value</returns>
    Task<T?> GetAsync<T>(string key);

    /// <summary>
    ///     Get hash value by key and hash key
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="fieldName">hash key</param>
    /// <typeparam name="T">type of value</typeparam>
    /// <returns>value</returns>
    Task<T?> HashGetAsync<T>(string key, string fieldName);

    /// <summary>
    ///     Get all hash values by key
    /// </summary>
    /// <param name="key">key</param>
    /// <typeparam name="T">type of value</typeparam>
    /// <returns>all values in hash</returns>
    Task<List<T?>> HashGetAllAsync<T>(string key);

    /// <summary>
    ///     Set value to redis
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="value">value</param>
    /// <param name="expiry">expiration time</param>
    /// <typeparam name="T">value type</typeparam>
    Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);

    /// <summary>
    ///     Set hash value by key and hash key
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="fieldName">hash key</param>
    /// <param name="value">value to set</param>
    /// <typeparam name="T">type of value</typeparam>
    Task HashSetAsync<T>(string key, string fieldName, T value);

    /// <summary>
    ///     Set hash values by key
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="values">value to set</param>
    /// <typeparam name="T">type of value</typeparam>
    Task HashSetAsync<T>(string key, IDictionary<string, T> values);

    /// <summary>
    ///     Remove value from redis
    /// </summary>
    /// <param name="key">key</param>
    Task RemoveAsync(string key);

    /// <summary>
    ///     Remove hash value by key and hash key
    /// </summary>
    /// <param name="key">key</param>
    /// <param name="fieldName">hash key</param>
    Task HashRemoveAsync(string key, string fieldName);

    /// <summary>
    ///     Check if key exists in redis
    /// </summary>
    /// <param name="key">key</param>
    /// <returns>true if exists, false otherwise</returns>
    Task<bool> ExistsAsync(string key);
}