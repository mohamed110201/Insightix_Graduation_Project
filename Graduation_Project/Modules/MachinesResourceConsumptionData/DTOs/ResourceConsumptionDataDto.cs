namespace Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

public class ResourceConsumptionDataDto
{
    public int MachineId { get; set; }
    public int ResourceConsumptionAttributeId { get; set; }
    public double Value { get; set; }
    
    public DateTime TimeStamp { get; set; }
}