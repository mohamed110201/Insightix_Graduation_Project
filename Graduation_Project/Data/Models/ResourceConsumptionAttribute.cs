namespace Graduation_Project.Data.Models
{
    public class ResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }

        public ICollection<MachineType> MachineTypes { get; set; }
    }
}
