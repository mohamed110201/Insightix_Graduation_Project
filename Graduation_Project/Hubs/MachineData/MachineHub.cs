using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Hubs.MachineData;

public class MachineHub : Hub
{
    public async Task JoinMachineGroup(int machineId,string type)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Machine-{machineId}-{type}");
    }

    public async Task LeaveMachineGroup(int machineId,string type)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Machine-{machineId}-{type}");
    }
}
