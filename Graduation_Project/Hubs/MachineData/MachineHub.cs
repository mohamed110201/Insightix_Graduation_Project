using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Hubs.MachineData;

public class MachineHub : Hub
{
    public async Task JoinMachineGroup(MachineHubType type,string machineId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Machine-{machineId}-{type}");
    }

    public async Task LeaveMachineGroup(MachineHubType type,string machineId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Machine-{machineId}-{type}");
    }
}
