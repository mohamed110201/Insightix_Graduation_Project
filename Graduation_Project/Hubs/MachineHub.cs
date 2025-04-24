namespace Graduation_Project.Hubs;
using Microsoft.AspNetCore.SignalR;

public class MachineHub : Hub
{
    

    public async Task JoinMachineGroup(string machineId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"Machine-{machineId}");
    }

    public async Task LeaveMachineGroup(string machineId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Machine-{machineId}");
    }
}
