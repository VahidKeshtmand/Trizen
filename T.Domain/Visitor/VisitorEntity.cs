using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace T.Domain.Visitor;

public class VisitorEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public string CurrentLink { get; set; } = string.Empty;
    public string ReferrerLink { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Protocol { get; set; } = string.Empty;
    public string PhysicalPath { get; set; } = string.Empty;
    public VisitorVersion Browser { get; set; } = new();
    public VisitorVersion OperatingSystem { get; set; } = new();
    public VisitorDevice Device { get; set; } = new();

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime VisitDate { get; set; }
    public string VisitorId { get; set; } = string.Empty;

}


