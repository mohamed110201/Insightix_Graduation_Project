namespace Graduation_Project.Data.Dtos.MachineDto;

public class GetMachineByMachineTypeIdDto
{
    public int Id { get; set; }
    public int SystemId { get; set; }
    public string SerialNumber { get; set; } = null!;
}