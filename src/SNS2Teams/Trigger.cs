
namespace SNS2Teams;

public class Trigger
{
    public string? MetricName { get; set; }
    public string? Namespace { get; set; }
    public string? Statistic { get; set; }
    public string? GreaterThanOrEqualToThreshold { get; set; }
    public decimal Period { get; set; }
    public decimal Threshold { get; set; }
    public decimal EvaluationPeriods { get; set; }
}
