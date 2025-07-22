using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Driver.HelloWorld;

/// <summary>
///     MongoDB ISODate to DateOnly Serializer
/// </summary>
public class DateOnlySerializer : StructSerializerBase<DateOnly>
{
    /// <inheritdoc />
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
    {
        context.Writer.WriteDateTime(BsonUtils.ToMillisecondsSinceEpoch(
            value.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc)
        ));
    }

    /// <inheritdoc />
    public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var timestamp = context.Reader.ReadDateTime();
        var dateTime = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(timestamp);
        return DateOnly.FromDateTime(dateTime);
    }
}