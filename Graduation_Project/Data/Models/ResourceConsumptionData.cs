namespace Graduation_Project.Data.Models
{
    public class ResourceConsumptionData
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;

        public int ResourceConsumptionAttributeId { get; set; }
        public ResourceConsumptionAttribute ResourceConsumptionAttribute { get; set; } = null!;

        public DateTime TimeStamp { get; set; }

        public double Value { get; set; }
    }
}
