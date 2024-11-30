namespace Graduation_Project.Data.Models
{
    public class MonitoringData
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }

        public int MachineTypeMonitoringAttributeId { get; set; }
        public MachineTypeMonitoringAttribute MachineTypeMonitoringAttribute { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Value { get; set; }

    }
}
