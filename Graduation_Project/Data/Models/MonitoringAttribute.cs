namespace Graduation_Project.Data.Models
{
    public class MonitoringAttribute
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;

        public ICollection<MachineType> MachineTypes { get; set; } = [];
        public ICollection<MonitoringData> MonitoringData { get; set; } = [];

        public ICollection<MachineTypeMonitoringAttribute> MachineTypeMonitoringAttributes { get; set; } = [];

    }
}
