using Graduation_Project.Hubs.Notifications.NotificationDataDtos;

namespace Graduation_Project.Hubs.Notifications;

public class NotificationDto
{
    public string Type { get; set; } = null!;
    public NotificationDataDto Data { get; set; } = null!;
}