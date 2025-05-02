namespace Graduation_Project.Data.FunctionsData;

public class MachineMonitoringData
{
    public DateTimeOffset TimeStamp { get; set; }
    public int MachineId { get; set; }
    public int MonitoringAttributeId { get; set; }
    public int Count { get; set; }
    public double Value { get; set; }
}