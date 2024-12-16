namespace Graduation_Project.Modules.Alerts.DTOs;

public class GetAlertsByMachineIdDto
{
    public int Id { get; set; } 
    public DateTime TimeStamp { get; set; }
    public string Status { get; set; } = null!;
    public string Severity { get; set; } = null!;
    public string Condition { get; set; } =null!;
    public string Attribute { get; set; } = null!;
}