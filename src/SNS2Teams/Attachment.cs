using System.Text.Json.Serialization;

namespace SNS2Teams;

public class Attachment
{
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }
    [JsonPropertyName("content")]
    public Content Content { get; set; }
}
