namespace Graduation_Project.Modules.MachineTypes.DTOs;

public class AttributeWithRangesRequestDto
{
    public int AttributeId { get; set; }
    public double UpperRange { get; set; }
    public double LowerRange { get; set; }
}