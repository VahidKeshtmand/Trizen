using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace T.Domain.Visitor;


public class OnlineVisitor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public DateTime DateTime { get; set; }
    public string ClientId { get; set; } = string.Empty;

}
