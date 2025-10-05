using Microsoft.AspNetCore.Mvc;
using WebApi.Redis.Example.Domain;
using WebApi.Redis.Example.Services;

namespace WebApi.Redis.Example.Controllers;

/// <summary>
///     Redis test controller
/// </summary>
[Route("/[controller]/[action]")]
[ApiController]
public class RedisTestController(IRedisService redisService) : ControllerBase
{
    private const string UserHashKey = "UserDict";

    /// <summary>
    ///     Set string value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetStringValue(string key, string value)
    {
        await redisService.SetAsync(key, value, TimeSpan.FromMinutes(5));
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get string value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> GetStringValue(string key)
    {
        var val = await redisService.GetAsync<string>(key);
        return ApiResponse<string>.Success(val);
    }

    /// <summary>
    ///     Set boolean value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetBooleanValue(string key, bool value)
    {
        await redisService.SetAsync(key, value);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get boolean value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<bool>> GetBooleanValue(string key)
    {
        var val = await redisService.GetAsync<bool>(key);
        return ApiResponse<bool>.Success(val);
    }

    /// <summary>
    ///     Set integer value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetIntValue(string key, int value)
    {
        await redisService.SetAsync(key, value);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get integer value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<int>> GetIntValue(string key)
    {
        var val = await redisService.GetAsync<int>(key);
        return ApiResponse<int>.Success(val);
    }

    /// <summary>
    ///     Set long value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetLongValue(string key, long value)
    {
        await redisService.SetAsync(key, value);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get long value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<long>> GetLongValue(string key)
    {
        var val = await redisService.GetAsync<long>(key);
        return ApiResponse<long>.Success(val);
    }

    /// <summary>
    ///     Set float value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetFloatValue(string key, float value)
    {
        await redisService.SetAsync(key, value);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get float value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<float>> GetFloatValue(string key)
    {
        var val = await redisService.GetAsync<float>(key);
        return ApiResponse<float>.Success(val);
    }

    /// <summary>
    ///     Set double value to redis
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<string>> SetDoubleValue(string key, double value)
    {
        await redisService.SetAsync(key, value);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get double value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<double>> GetDoubleValue(string key)
    {
        var val = await redisService.GetAsync<double>(key);
        return ApiResponse<double>.Success(val);
    }

    /// <summary>
    ///     Set json str value to redis
    /// </summary>
    /// <param name="userEntity">user info</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResponse<string>> AddUser([FromBody] UserEntity userEntity)

    {
        await redisService.SetAsync("user", userEntity);
        return ApiResponse<string>.Success();
    }

    /// <summary>
    ///     Get object value from redis by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResponse<UserEntity>> GetUser(string key)
    {
        var val = await redisService.GetAsync<UserEntity>(key);
        return ApiResponse<UserEntity>.Success(val);
    }

    [HttpPost]
    public async Task<ApiResponse<string>> SetHashValue([FromBody] UserEntity userEntity)
    {
        await redisService.HashSetAsync(UserHashKey, userEntity.Id, userEntity);
        return ApiResponse<string>.Success(userEntity.Id);
    }

    [HttpPost]
    public async Task<ApiResponse<string>> SetHashValues([FromBody] List<UserEntity> users)
    {
        await redisService.HashSetAsync(UserHashKey, users.ToDictionary(x => x.Id));
        return ApiResponse<string>.Success();
    }

    [HttpGet]
    public async Task<ApiResponse<UserEntity>> GetHashValue(string userId)
    {
        var user = await redisService.HashGetAsync<UserEntity>(UserHashKey, userId);
        return ApiResponse<UserEntity>.Success(user);
    }

    [HttpGet]
    public async Task<ApiResponse<List<UserEntity?>>> GetHashValues()
    {
        var users = await redisService.HashGetAllAsync<UserEntity>(UserHashKey);
        return ApiResponse<List<UserEntity?>>.Success(users);
    }

    [HttpGet]
    public async Task<ApiResponse<string>> Remove(string key)
    {
        await redisService.RemoveAsync(key);
        return ApiResponse<string>.Success();
    }

    [HttpGet]
    public async Task<ApiResponse<string>> HashRemove(string userId)
    {
        await redisService.HashRemoveAsync(UserHashKey, userId);
        return ApiResponse<string>.Success();
    }
}