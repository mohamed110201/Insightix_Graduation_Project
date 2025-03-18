namespace Graduation_Project.Data.Models
{
    public class MonitoringData
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;

        public int MonitoringAttributeId { get; set; }
        public MonitoringAttribute MonitoringAttribute { get; set; } = null!;

        public DateTime TimeStamp { get; set;}
        public double Value { get; set; }


    }
}
