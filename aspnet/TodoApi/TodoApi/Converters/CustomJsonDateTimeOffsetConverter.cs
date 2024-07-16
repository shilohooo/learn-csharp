using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoApi.Converters;

/// <summary>
/// 
/// </summary>
public class CustomJsonDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    private const string NormDatetimePattern = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    /// 时间反序列化
    /// </summary>
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var datetimeStr = reader.GetString();
        if (string.IsNullOrWhiteSpace(datetimeStr))
        {
            return null;
        }

        return DateTimeOffset.ParseExact(datetimeStr, NormDatetimePattern, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// 时间序列化
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateTimeOffset? dateTimeOffset, JsonSerializerOptions options)
    {
        if (dateTimeOffset is not null)
        {
            writer.WriteStringValue(dateTimeOffset.Value.ToString(NormDatetimePattern));
        }
    }
}