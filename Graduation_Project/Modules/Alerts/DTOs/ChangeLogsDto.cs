using Graduation_Project.Data.Enums;

namespace Graduation_Project.Modules.Alerts.DTOs;

public class ChangeLogsDto
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Status { get; set; }

}