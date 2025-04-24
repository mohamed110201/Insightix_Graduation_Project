using Graduation_Project.Hubs;
using Graduation_Project.Hubs.MachineData;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class MonitoringRefreshCurrentDataPipelineStep(MachineDataNotifier notifier) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        foreach (var data in input)
        {
           await notifier.SendMachineDataAsync(MachineHubType.Monitoring,data.MachineId,new RefreshMonitorDataDto()
           {
               MachineId = data.MachineId,
               AttributeId = data.MonitoringAttributeId,
               Value = data.Value,
               TimeStamp = data.TimeStamp
           });
        }
        return input;
    }
}