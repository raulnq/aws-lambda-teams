using System.Text.Json.Serialization;

namespace SNS2Teams;

public class Message
{
    [JsonPropertyName("attachments")]
    public Attachment[] Attachments { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
}
