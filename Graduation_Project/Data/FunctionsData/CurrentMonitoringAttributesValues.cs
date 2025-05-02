namespace Graduation_Project.Data.FunctionsData;

public class CurrentMonitoringAttributesValues
{
    public int MachineId { get; set; }
    public int MonitoringAttributeId { get; set; }
    public string MonitoringAttributeName { get; set; } = null!;
    public DateTimeOffset? TimeStamp { get; set; }
    public double? Value { get; set; }
}