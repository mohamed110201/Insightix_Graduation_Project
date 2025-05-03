namespace Graduation_Project.Hubs.Notifications.NotificationDataDtos;

public class NotificationFailurePredictionDataDto:NotificationDataDto
{
    public int MachineId { get; set; }
    public int FailurePrediction { get; set; }
    public string MachineSerialNumber { get; set; }
    public string MachineTypeName { get; set; }
    public DateTimeOffset TimeStamp { get; set; }
}