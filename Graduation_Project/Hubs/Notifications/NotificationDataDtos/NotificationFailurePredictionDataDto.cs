namespace Graduation_Project.Hubs.Notifications.NotificationDataDtos;

public class NotificationFailurePredictionDataDto:NotificationDataDto
{
    public int MachineId { get; set; }
    public int FailurePrediction { get; set; }
    public string MachineSerialNumber { get; set; } =string.Empty;
    public string MachineTypeName { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; }
}