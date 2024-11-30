namespace Graduation_Project.Data.Models
{
    public class MonitoringAttribute
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;

        public List<MachineType> MachineTypes { get; set; } = [];
        public List<MonitoringData> MonitoringData { get; set; } = [];

        public List<MachineTypeMonitoringAttribute> MachineTypeMonitoringAttributes { get; set; } = [];

    }
}
