using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApi.Redis.Example.Constants;

namespace WebApi.Redis.Example.Converters;

/// <summary>
///     Custom <see cref="System.Text.Json" /> datetime converter
/// </summary>
public sealed class DateTimeJsonConverterFactory
    : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime)
               || typeToConvert == typeof(DateTime?)
               || typeToConvert == typeof(DateOnly)
               || typeToConvert == typeof(DateOnly?)
               || typeToConvert == typeof(TimeOnly)
               || typeToConvert == typeof(TimeOnly?)
               || typeToConvert == typeof(DateTimeOffset)
               || typeToConvert == typeof(DateTimeOffset?);
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(DateTime)) return new DateTimeJsonConverter<DateTime>(DatePattern.DefaultDateTime);

        if (typeToConvert == typeof(DateTime?))
            return new DateTimeJsonConverter<DateTime?>(DatePattern.DefaultDateTime);

        if (typeToConvert == typeof(DateOnly)) return new DateTimeJsonConverter<DateOnly>(DatePattern.DefaultDate);

        if (typeToConvert == typeof(DateOnly?)) return new DateTimeJsonConverter<DateOnly?>(DatePattern.DefaultDate);

        if (typeToConvert == typeof(TimeOnly)) return new DateTimeJsonConverter<TimeOnly>(DatePattern.DefaultTime);

        if (typeToConvert == typeof(TimeOnly?)) return new DateTimeJsonConverter<TimeOnly?>(DatePattern.DefaultTime);

        if (typeToConvert == typeof(DateTimeOffset))
            return new DateTimeJsonConverter<DateTimeOffset>(DatePattern.DefaultDateTimeOffset);

        return typeToConvert == typeof(DateTimeOffset?)
            ? new DateTimeJsonConverter<DateTimeOffset?>(DatePattern.DefaultDateTimeOffset)
            : throw new NotSupportedException($"Unsupported datetime type: {typeToConvert}");
    }

    /// <summary>
    /// </summary>
    /// <param name="format">date pattern</param>
    /// <typeparam name="T">type of datetime value</typeparam>
    private sealed class DateTimeJsonConverter<T>(string format) : JsonConverter<T>
    {
        /// <inheritdoc />
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return default;

            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value)) return default;

            if (typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?))
                return (T)(object)DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);

            if (typeToConvert == typeof(DateOnly) || typeToConvert == typeof(DateOnly?))
                return (T)(object)DateOnly.ParseExact(value, format, CultureInfo.InvariantCulture);

            if (typeToConvert == typeof(TimeOnly) || typeToConvert == typeof(TimeOnly?))
                return (T)(object)TimeOnly.ParseExact(value, format, CultureInfo.InvariantCulture);

            if (typeToConvert == typeof(DateTimeOffset) || typeToConvert == typeof(DateTimeOffset?))
                return (T)(object)DateTimeOffset.ParseExact(value, format, CultureInfo.InvariantCulture);

            throw new JsonException($"Can not read datetime value: {value} with format: {format}");
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }

            switch (value)
            {
                case DateTime dateTime:
                    writer.WriteStringValue(dateTime.ToString(format));
                    break;
                case DateOnly dateOnly:
                    writer.WriteStringValue(dateOnly.ToString(format));
                    break;
                case TimeOnly timeOnly:
                    writer.WriteStringValue(timeOnly.ToString(format));
                    break;
                case DateTimeOffset dateTimeOffset:
                    writer.WriteStringValue(dateTimeOffset.ToString(format));
                    break;
                default:
                    throw new JsonException($"Can not write datetime value: {value} with format: {format}");
            }
        }
    }
}