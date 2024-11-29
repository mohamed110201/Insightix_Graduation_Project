namespace Graduation_Project.Data.Models
{
    public class MachineTypeMonitoringAttribute
    {
        public int Id { get; set; }
        public ICollection<MonitorAttributeAlertRule> AlertRules { get; set; } = new List<MonitorAttributeAlertRule>();
    }
}
