namespace Graduation_Project.Modules.MachineTypes.DTOs;

public class AttributeWithRangesResponseDto
{
    public int AttributeId { get; set; }
    public string Name {get; set;} = string.Empty;
    public double UpperRange { get; set; }
    public double LowerRange { get; set; }
}