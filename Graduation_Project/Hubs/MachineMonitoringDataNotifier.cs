using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Microsoft.AspNetCore.SignalR;
namespace Graduation_Project.Hubs;

public class MachineMonitoringDataNotifier(IHubContext<MachineHub> hubContext)
{
    public async Task SendMachineDataAsync(int machineId, object machineData)
    {
        await hubContext.Clients.Group($"Machine-{machineId}")
            .SendAsync("ReceiveMachineMonitoringData", machineData);
    }
}