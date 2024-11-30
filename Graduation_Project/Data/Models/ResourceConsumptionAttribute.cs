namespace Graduation_Project.Data.Models
{
    public class ResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;

        public ICollection<MachineType> MachineTypes { get; set; } = [];
        public List<ResourceConsumptionData> ResourceConsumptionData { get; set; } = [];

        public List<MachineTypeResourceConsumptionAttribute> MachineTypeResourceConsumptionAttributes { get; set; } = [];

    }
}
