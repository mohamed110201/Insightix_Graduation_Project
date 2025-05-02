namespace Graduation_Project.Modules.MachinesMonitoringData.DTOs;

public class GetCurrentMonitoringAttributesValuesDto
{
    public int MonitoringAttributeId { get; set; }
    public string MonitoringAttributeName { get; set; } = null!;
    public DateTimeOffset? TimeStamp { get; set; }
    public double? Value { get; set; }
}