using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Hubs.MachineData;

public class MachineDataNotifier(IHubContext<MachineHub> hubContext)
{
    public async Task SendMachineDataAsync(MachineHubType type,int machineId, RefreshMonitorDataDto machineData)
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