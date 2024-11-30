namespace Graduation_Project.Data.Models;

public class ResourceConsumptionAttributeAlertRule:AlertRule
{
    public ICollection<ResourceConsumptionAlert> Alerts { get; set; } = [];
    public int MachineTypeResourceConsumptionAttributeId { get; set; }
    public MachineTypeResourceConsumptionAttribute MachineTypeResourceConsumptionAttribute { get; set; } = null!;
}