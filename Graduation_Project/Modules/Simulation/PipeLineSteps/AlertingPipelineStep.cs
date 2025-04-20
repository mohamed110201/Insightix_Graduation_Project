using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.Simulation;

public class AlertingPipelineStep(ICreateAlertsService createAlertsService) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        var tasks = new List<Task>();
        foreach (var monitoringData in input)
        {
            var dto = new MonitoringDataDto
            {
                MachineId = monitoringData.MachineId,
                MonitoringAttributeId = monitoringData.MonitoringAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

            tasks.Add(createAlertsService.CheckMonitoringAlertsAsync(dto));
        }

        await Task.WhenAll(tasks);
        return input;
    }
}
