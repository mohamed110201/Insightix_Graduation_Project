namespace Graduation_Project.Data.Models
{
    public class MachineTypeMonitoringAttribute
    {
        public int Id { get; set; }
        public int MonitorAttributeId { get; set; }
        public MonitoringAttribute MonitoringAttribute { get; set; }

        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; }

        public List<MonitoringData>? MonitoringData { get; set; }


        public int LowerRange { get; set; }
        public int UpperRange { get; set; }
    }
}
