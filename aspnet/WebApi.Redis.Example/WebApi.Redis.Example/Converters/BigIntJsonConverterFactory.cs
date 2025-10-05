using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApi.Redis.Example.Converters;

/// <summary>
///     Custom <see cref="System.Text.Json" /> converter for big integers
/// </summary>
public sealed class BigIntJsonConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(long) || typeToConvert == typeof(long?) ||
               typeToConvert == typeof(ulong) || typeToConvert == typeof(ulong?);
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == typeof(long)) return new BigIntJsonConverter<long>();

        if (typeToConvert == typeof(long?)) return new BigIntJsonConverter<long?>();

        if (typeToConvert == typeof(ulong)) return new BigIntJsonConverter<ulong>();

        return typeToConvert == typeof(ulong?)
            ? new BigIntJsonConverter<ulong?>()
            : throw new NotSupportedException($"Unsupported big integer type: {typeToConvert}");
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private sealed class BigIntJsonConverter<T> : JsonConverter<T>
    {
        private const long MaxSaveInteger = 9007199254740991L;

        /// <inheritdoc />
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null) return default;

            var isLong = typeToConvert == typeof(long) || typeToConvert == typeof(long?);
            if (isLong && reader.TryGetInt64(out var longNum)) return (T)(object)longNum;

            var isUlong = typeToConvert == typeof(ulong) || typeToConvert == typeof(ulong?);
            if (isUlong && reader.TryGetUInt64(out var ulongNum)) return (T)(object)ulongNum;


            throw new JsonException(
                $"Can not read big integer value: {reader.GetString()}, value type: {typeToConvert}"
            );
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
                case long longNum:
                    if (longNum > MaxSaveInteger)
                    {
                        writer.WriteStringValue(longNum.ToString());
                        break;
                    }

                    writer.WriteNumberValue(longNum);
                    break;
                case ulong ulongNum:
                    if (ulongNum > MaxSaveInteger)
                    {
                        writer.WriteStringValue(ulongNum.ToString());
                        break;
                    }

                    writer.WriteNumberValue(ulongNum);
                    break;
                default:
                    throw new JsonException($"Can not write big integer value: {value}");
            }
        }
    }
}