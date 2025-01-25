using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using System.Text;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SNS2Teams;

public class Function
{
    private HttpClient _httpClient;

    private readonly Uri _uri;

    public Function()
    {
        _httpClient = new HttpClient();
        _uri = new Uri(Environment.GetEnvironmentVariable("TeamsWebHook")!);
        _httpClient.BaseAddress = new Uri($"{_uri.Scheme}://{_uri.Host}:{_uri.Port}");
    }

    public async Task FunctionHandler(SNSEvent evnt, ILambdaContext context)
    {
        foreach (var record in evnt.Records)
        {
            await ProcessRecord(record, context);
        }
    }
    
    private Task ProcessRecord(SNSEvent.SNSRecord record, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed record {record.Sns.Message}");
        if (record.Sns.Message == null)
        {
            return Task.CompletedTask;
        }
        var alarm = JsonSerializer.Deserialize<Alarm>(record.Sns.Message);
        if (string.IsNullOrEmpty(alarm?.NewStateReason))
        {
            return Task.CompletedTask;
        }
        var message = new Message()
        {
            Type = "message", 
            Attachments = new[] {
                new Attachment()
                {
                    ContentType="application/vnd.microsoft.card.adaptive",
                    Content = new Content()
                    {
                        Type= "AdaptiveCard",
                        Body = new[]
                        {
                            new Element()
                            {
                                Type="TextBlock", 
                                Text = alarm.NewStateReason
                            }
                        },
                        Version = "1.0",
                        Schema = "http://adaptivecards.io/schemas/adaptive-card.json"
                    }
                }
            }
        };

        var body = JsonSerializer.Serialize(message);

        return _httpClient.PostAsync(_uri.PathAndQuery, new StringContent(body, Encoding.UTF8, "application/json"));
    }
}
