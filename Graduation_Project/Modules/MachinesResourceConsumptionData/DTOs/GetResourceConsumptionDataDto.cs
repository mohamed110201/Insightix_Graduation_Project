namespace Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

public class GetResourceConsumptionDataDto
{
    public DateTimeOffset TimeStamp { get; set; }
    public int Count { get; set; }
    public double Value { get; set; }
}