namespace Graduation_Project.Modules.MachineTypes.DTOs;

public class MachineTypeGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public List<AttributeWithRangesResponseDto> MonitoringAttributes { get; set; } = [];
    public List<AttributeWithRangesResponseDto> ResourceConsumptionAttributes { get; set; } = [];
}