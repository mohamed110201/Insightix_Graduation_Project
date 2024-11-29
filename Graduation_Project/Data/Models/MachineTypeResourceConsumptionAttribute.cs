namespace Graduation_Project.Data.Models
{
    public class MachineTypeResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public ICollection<ResourceConsumptionAttributeAlertRule> AlertRules { get; set; } = new List<ResourceConsumptionAttributeAlertRule>();
    }
}
