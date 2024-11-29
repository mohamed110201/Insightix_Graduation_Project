using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models;

public abstract class AlertRule
{
    public int Id { get; set; }
    public double Value { get; set; }
    public AlertSeverity Severity { get; set; }
    public AlertCondition Condition { get; set; }
}