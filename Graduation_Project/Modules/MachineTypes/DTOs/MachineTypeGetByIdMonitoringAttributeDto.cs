namespace Graduation_Project.Data.Dtos.MachineTypeDto;

public class MachineTypeGetByIdMonitoringAttributeDto
{
    public int Id {  get; set; }
    public string Name { get; set; } = null!;
    public string Unit { get; set; } = null!;
    
    public double UpperRange { get; set; }
    public double LowerRange { get; set; }
}