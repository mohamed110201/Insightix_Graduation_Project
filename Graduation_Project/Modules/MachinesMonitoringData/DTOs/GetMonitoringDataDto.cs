namespace Graduation_Project.Modules.MachinesMonitoringData.DTOs;

public class GetMointoringDataDto
{
    public DateTimeOffset TimeStamp { get; set; }
    public int Count { get; set; }
    public double Value { get; set; }
}