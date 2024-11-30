namespace Graduation_Project.Data.Models
{
    public class MachineTypeResourceConsumptionAttribute
    {
        public int Id { get; set; }
        public int ResourceConsumptionAttributeId { get; set; }
        public ResourceConsumptionAttribute ResourceConsumptionAttribute { get; set; }

        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; }

        public List<ResourceConsumptionData>? ResourceConsumptionData { get; set; }


        public int LowerRange { get; set; }
        public int UpperRange { get; set; }
    }
}
