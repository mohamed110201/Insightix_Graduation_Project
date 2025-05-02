using Graduation_Project.Data.Enums;

namespace Graduation_Project.Controllers.DTOs;

public class FailureGetById
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    
    public DateTimeOffset StartDateTimeOffset { get; set;}

    public DateTimeOffset? EndDateTimeOffset { get; set; }
        
    public FailureStatus Status { get; set;}
    
    public required string MachineSerialNumber { get; set; }
    
    public required string MachineTypeName { get; set; }
}