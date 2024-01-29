using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Movies.Api.Model;

[BsonIgnoreExtraElements]
public class MovieModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    public string? plot { get; set; }
    public List<string>? genres { get; set; }
    public List<string>? cast { get; set; }
    public string? title { get; set; }
    public string? fullPlot { get; set; }
    public List<string>? countries { get; set; }
    public List<string>? directors { get; set; }
    public string? rated { get; set; }
    public string? lastUpdated { get; set; }
    public string? type { get; set; }
}