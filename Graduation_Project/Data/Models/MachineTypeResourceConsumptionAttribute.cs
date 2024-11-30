namespace Graduation_Project.Data.Models
{
    public class MachineTypeResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public int LowerRange { get; set; }
        public int UpperRange { get; set; }

        public int ResourceConsumptionAttributeId { get; set; }
        public ResourceConsumptionAttribute ResourceConsumptionAttribute { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; } = null!;
      
        public ICollection<ResourceConsumptionAttributeAlertRule> AlertRules { get; set; } = new List<ResourceConsumptionAttributeAlertRule>();
     
    }
}
