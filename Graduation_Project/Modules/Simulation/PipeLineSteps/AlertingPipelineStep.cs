using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.Simulation;

public class AlertingPipelineStep(IServiceProvider serviceProvider) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        using var scope = serviceProvider.CreateScope();
        var createAlertsService = scope.ServiceProvider.GetRequiredService<ICreateAlertsService>();
        foreach (var monitoringData in input)
        {
            var dto = new MonitoringDataDto
            {
                MachineId = monitoringData.MachineId,
                MonitoringAttributeId = monitoringData.MonitoringAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

            await createAlertsService.CheckMonitoringAlertsAsync(dto);
        }

        return input;
    }
}
