namespace Graduation_Project.Data.Dtos.MachineTypeDto;

public class MachineTypeRequestDto
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public List<int> MonitoringAttributeIds { get; set; } = [];
    public List<int> ResourceConsumptionAttributeIds { get; set; } = [];
}