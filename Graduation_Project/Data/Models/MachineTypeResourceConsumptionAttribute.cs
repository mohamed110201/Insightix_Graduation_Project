namespace Graduation_Project.Data.Models
{
    public class MachineTypeResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public int ResourceConsumptionAttributeId { get; set; }
        public ResourceConsumptionAttribute ResourceConsumptionAttribute { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; } = null!;
      
        public ICollection<ResourceConsumptionAttributeAlertRule> AlertRules { get; set; } = [];
        public double UpperRange { get; set; }
        public double LowerRange { get; set; }
     
    }
}
