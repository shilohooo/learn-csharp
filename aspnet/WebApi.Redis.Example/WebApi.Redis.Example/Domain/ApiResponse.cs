namespace WebApi.Redis.Example.Domain;

/// <summary>
///     Api response
/// </summary>
public class ApiResponse<T>
{
    /// <summary>
    ///     code, 200 = success
    /// </summary>
    public int Status { get; set; } = 200;

    /// <summary>
    ///     msg
    /// </summary>
    public string Msg { get; set; } = "success";

    /// <summary>
    ///     data
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    ///     timestamp
    /// </summary>
    public long Timestamp { get; private set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    /// <summary>
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ApiResponse<T> Success(T? data = default)
    {
        return new ApiResponse<T>
        {
            Data = data
        };
    }

    public static ApiResponse<T> Error(int status = 500, string msg = "Unknown server error! Please try again later:)")
    {
        return new ApiResponse<T>
        {
            Status = status,
            Msg = msg
        };
    }
}