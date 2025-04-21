using Graduation_Project.Data.Enums;

namespace Graduation_Project.Controllers.DTOs;

public class MachineFailureGetAll
{
    public int Id { get; set; }
    
    public DateTime StartDateTime { get; set;}

    public DateTime? EndDateTime { get; set; }
        
    public FailureStatus Status { get; set;}
}