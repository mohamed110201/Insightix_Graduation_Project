using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesMonitoringData.Service;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class StorePipelineStep(IMachinesMonitoringDataService machinesMonitoringDataService) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        var tasks = input.Select(monitoringData =>
        {
            var dto = new MonitoringDataDto
            {
                MachineId = monitoringData.MachineId,
                MonitoringAttributeId = monitoringData.MonitoringAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

            return machinesMonitoringDataService.AddMonitoringData(dto);
        });

        await Task.WhenAll(tasks);
        return input;
    }

}
