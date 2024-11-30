namespace Graduation_Project.Data.Models
{
    public class ResourceConsumptionData
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int MachineTypeResourceConsumptionAttributeId { get; set; }
        public MachineTypeResourceConsumptionAttribute MachineTypeResourceConsumptionAttribute { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Value { get; set; }
    }
}
