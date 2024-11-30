using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models;

public class MonitorAttributeAlertRule : AlertRule
{
    public ICollection<MonitoringAlert> Alerts { get; set; } = [];
    public int MachineTypeMonitoringAttributeId { get; set; }
    public MachineTypeMonitoringAttribute MachineTypeMonitoringAttribute { get; set; } = null!;
}