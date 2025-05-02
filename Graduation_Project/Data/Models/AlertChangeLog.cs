using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models;

public class AlertChangeLog
{
    public int Id { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
    public AlertStatus Status { get; set; }

    public int AlertId { get; set; }
    public Alert Alert { get; set; } = null!;
    
    
    
}