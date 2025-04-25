namespace Graduation_Project.Hubs.Notifications.NotificationDataDtos;

public class NotificationFailurePredictionDataDto:NotificationDataDto
{
    public int MachineId { get; set; }
    public DateTime TimeStamp { get; set; }
}