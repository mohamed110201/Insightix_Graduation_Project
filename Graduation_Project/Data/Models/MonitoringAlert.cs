namespace Graduation_Project.Data.Models;

public class MonitoringAlert:Alert
{
    public int MonitorAttributeAlertRuleId { get; set; }
    public MonitorAttributeAlertRule MonitorAttributeAlertRule { get; set; } = null!;
    
}