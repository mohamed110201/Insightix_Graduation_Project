namespace Graduation_Project.Modules.FailuresPrediction.Dtos;

public class FailurePredictionDto
{
    public int Id { get; set; }
    public string MachineSerialNumber { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
}