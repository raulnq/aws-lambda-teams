using System.Text.Json.Serialization;

namespace SNS2Teams;

public class Content
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("body")]
    public Element[] Body { get; set; }
    [JsonPropertyName("version")]
    public string Version { get; set; }
    [JsonPropertyName("$schema")]
    public string Schema { get; set; }
}
