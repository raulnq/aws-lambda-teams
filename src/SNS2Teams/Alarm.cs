
namespace SNS2Teams;

public class Alarm
{
    public string? AlarmName { get; set; }
    public string? AlarmDescription { get; set; }
    public string? AWSAccountId { get; set; }
    public string? NewStateValue { get; set; }
    public string? NewStateReason { get; set; }
    public string? OldStateValue { get; set; }
    public Trigger? Trigger { get; set; }
}
