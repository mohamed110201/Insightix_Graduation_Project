namespace Graduation_Project.Data.Models
{
    public class MachineTypeMonitoringAttribute
    {
        public int Id { get; set; }
        public int LowerRange { get; set; }
        public int UpperRange { get; set; }
        public int MonitoringAttributeId { get; set; }
        public MonitoringAttribute MonitoringAttribute { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; } = null!;
        public ICollection<MonitorAttributeAlertRule> AlertRules { get; set; } = new List<MonitorAttributeAlertRule>();

    }
}
