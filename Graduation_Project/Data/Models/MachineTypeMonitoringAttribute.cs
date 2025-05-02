namespace Graduation_Project.Data.Models
{
    public class MachineTypeMonitoringAttribute
    {
        public int Id { get; set; }
        public int MonitoringAttributeId { get; set; }
        public MonitoringAttribute MonitoringAttribute { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; } = null!;
        public ICollection<MonitorAttributeAlertRule> AlertRules { get; set; } = [];
        public double UpperRange { get; set; }
        public double LowerRange { get; set; }


    }
}
