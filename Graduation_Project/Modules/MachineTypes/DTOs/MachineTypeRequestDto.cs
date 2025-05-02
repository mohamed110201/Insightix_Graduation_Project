namespace Graduation_Project.Modules.MachineTypes.DTOs;

public class MachineTypeRequestDto
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public List<AttributeWithRangesRequestDto> MonitoringAttributes { get; set; } = [];
    public List<AttributeWithRangesRequestDto> ResourceConsumptionAttributes { get; set; } = [];
}