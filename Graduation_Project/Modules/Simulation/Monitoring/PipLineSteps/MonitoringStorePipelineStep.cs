using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesMonitoringData.Service;

namespace Graduation_Project.Modules.Simulation.Monitoring.PipLineSteps;

public class MonitoringStorePipelineStep(IServiceProvider serviceProvider) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        using var scope = serviceProvider.CreateScope();
        var machinesMonitoringDataService = scope.ServiceProvider.GetRequiredService<IMachinesMonitoringDataService>();

        foreach (var monitoringData in input)
        {
            var dto = new MonitoringDataDto
            {
                MachineId = monitoringData.MachineId,
                MonitoringAttributeId = monitoringData.MonitoringAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

            await machinesMonitoringDataService.AddMonitoringData(dto);
        }
        
        return input;
    }

}
