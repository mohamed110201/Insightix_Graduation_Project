namespace Graduation_Project.Data.Dtos.MachineTypeDto;

public class MachineTypeGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public List<string> MonitoringAttributes { get; set; } = [];
    public List<string> ResourceConsumptionAttributes { get; set; } = [];
}