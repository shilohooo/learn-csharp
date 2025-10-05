using IdGen;

namespace WebApi.Redis.Example.Helpers;

/// <summary>
/// </summary>
public static class SnowflakeIdHelper
{
    private static readonly IdGenerator Generator = new(0);

    /// <summary>
    ///     Get a new snowflake id
    /// </summary>
    /// <returns>snowflake id</returns>
    public static long GetId()
    {
        return Generator.CreateId();
    }
}