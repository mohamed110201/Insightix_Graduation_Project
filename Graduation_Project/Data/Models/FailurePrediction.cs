namespace Graduation_Project.Data.Models;

public class FailurePrediction
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
}