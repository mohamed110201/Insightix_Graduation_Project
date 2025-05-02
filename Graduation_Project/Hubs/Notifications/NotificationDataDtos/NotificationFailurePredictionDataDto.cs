namespace Graduation_Project.Hubs.Notifications.NotificationDataDtos;

public class NotificationFailurePredictionDataDto:NotificationDataDto
{
    public string MachineSerialNumber { get; set; }
    public DateTime TimeStamp { get; set; }
}