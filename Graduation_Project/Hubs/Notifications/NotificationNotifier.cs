using Graduation_Project.Hubs.MachineData;
using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Hubs.Notifications;

public class NotificationsNotifier(IHubContext<NotificationsHub> hubContext)
{
    public async Task SendNotificationsAsync(NotificationDto data)
    {
        try
        {
            await hubContext.Clients.All.SendAsync("ReceiveNotification", data);
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}