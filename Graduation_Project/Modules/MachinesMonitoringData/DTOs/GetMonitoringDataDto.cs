namespace Graduation_Project.Modules.MachinesMonitoringData.DTOs;

public class GetMonitoringDataDto
{
    public DateTime TimeStamp { get; set; }
    public int Count { get; set; }
    public int Value { get; set; }
}