namespace Graduation_Project.Data.Models
{
    public class ResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;

        public ICollection<MachineType> MachineTypes { get; set; } = [];
        public ICollection<ResourceConsumptionData> ResourceConsumptionData { get; set; } = [];

        public ICollection<MachineTypeResourceConsumptionAttribute> MachineTypeResourceConsumptionAttributes { get; set; } = [];

    }
}
