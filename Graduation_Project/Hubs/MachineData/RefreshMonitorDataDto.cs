namespace Graduation_Project.Hubs.MachineData;

public class RefreshMonitorDataDto
{
    public int MachineId { get; set; }
    public int AttributeId { get; set; }
    public DateTimeOffset TimeStamp { get; set;}
    public double Value { get; set; }
}