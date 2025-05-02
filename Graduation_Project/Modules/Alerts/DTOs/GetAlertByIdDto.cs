namespace Graduation_Project.Modules.Alerts.DTOs;

public class GetAlertByIdDto
{
    public int Id { get; set; } 
    public DateTimeOffset TimeStamp { get; set; }
    public string MachineSerialNumber { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Attribute { get; set; } = null!;
    public double Value { get; set; } 
    public string Condition { get; set; } = null!;
    public string Severity { get; set; } = null!;
    public string Status { get; set; } = null!;
    public List<ChangeLogsDto> ChangeLogs { get; set; } = [];
}