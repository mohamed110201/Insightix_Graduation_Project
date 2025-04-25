namespace Graduation_Project.Hubs.Notifications.NotificationDataDtos;

public class NotificationAlertDataDto : NotificationDataDto
{
    public int AlertId { get; set; }
    public int MachineId { get; set; }
    public DateTime TimeStamp { get; set; }
}