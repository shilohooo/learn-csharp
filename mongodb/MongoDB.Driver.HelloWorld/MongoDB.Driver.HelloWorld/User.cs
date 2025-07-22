using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Driver.HelloWorld;

/// <summary>
///     Mongodb Entity
/// </summary>
public class User
{
    /// <summary>
    ///     Id
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    ///     JavaClassType
    /// </summary>
    [BsonElement("_class")]
    public string JavaClassType { get; set; }

    /// <summary>
    ///     Age
    /// </summary>
    [BsonElement("age")]
    public int Age { get; set; }

    /// <summary>
    ///     Birthday
    /// </summary>
    [BsonElement("birthday")]
    public DateOnly Birthday { get; set; }

    /// <summary>
    ///     CreateTime
    /// </summary>
    [BsonElement("createTime")]
    public DateTime CreateTime { get; set; }

    /// <summary>
    ///     Enabled
    /// </summary>
    [BsonElement("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    ///     Name
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///     UpdateTime
    /// </summary>
    [BsonElement("updateTime")]
    public DateTime UpdateTime { get; set; }

    /// <summary>
    ///     Version
    /// </summary>
    [BsonElement("version")]
    public int Version { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return
            $"Id: {Id}, JavaClassType: {JavaClassType}, Age: {Age}, Birthday: {Birthday}, CreateTime: {CreateTime.ToLocalTime()}, Enabled: {Enabled}, Name: {Name}, UpdateTime: {UpdateTime.ToLocalTime()}, Version: {Version}";
    }
}