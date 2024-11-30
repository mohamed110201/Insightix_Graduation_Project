using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models;

public abstract class Alert
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public AlertStatus Status { get; set; }
    public AlertType Type { get; set; }

    public int MachineId { get; set; }
    public Machine Machine { get; set; } = null!;
    
    public ICollection<AlertChangeLog> ChangeLogs { get; set; } = [];
    
}