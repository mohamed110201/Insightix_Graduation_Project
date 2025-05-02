namespace Graduation_Project.Data.FunctionsData
{
    public class MachineResourceConsumptionData
    {
        public DateTimeOffset TimeStamp { get; set; }
        public int MachineId { get; set; }
        public int ResourceConsumptionAttributeId { get; set; }
        public int Count { get; set; }
        public double Value { get; set; }
    }
}
