using System.Text.Json.Serialization;

namespace SNS2Teams;

public class Element
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
}