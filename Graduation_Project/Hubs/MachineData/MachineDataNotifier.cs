using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Hubs.MachineData;

public class MachineDataNotifier(IHubContext<MachineHub> hubContext)
{
    public async Task SendMachineDataAsync(string type,int machineId, RefreshMonitorDataDto machineData)
    {
        try
        {
            await hubContext.Clients.Group($"Machine-{machineId}-{type}")
                .SendAsync("ReceiveMachineData", machineData);
        }
        catch (Exception e)
        {
            // ignored
        }

    }
}