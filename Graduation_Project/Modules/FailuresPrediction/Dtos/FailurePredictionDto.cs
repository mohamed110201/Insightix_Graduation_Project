namespace Graduation_Project.Modules.FailuresPrediction.Dtos;

public class FailurePredictionDto
{
    public int Id { get; set; }
    public int MachineId { get; set; }
    public string MachineSerialNumber { get; set; } = String.Empty;
    public string MachineTypeName { get; set; } = String.Empty;
    public DateTime TimeStamp { get; set; }
}