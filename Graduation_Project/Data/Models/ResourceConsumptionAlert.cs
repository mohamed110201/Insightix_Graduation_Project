namespace Graduation_Project.Data.Models;

public class ResourceConsumptionAlert:Alert
{
    public int ResourceConsumptionAttributeAlertRuleId { get; set; }
    public ResourceConsumptionAttributeAlertRule ResourceConsumptionAttributeAlertRule { get; set; } = null!;

}