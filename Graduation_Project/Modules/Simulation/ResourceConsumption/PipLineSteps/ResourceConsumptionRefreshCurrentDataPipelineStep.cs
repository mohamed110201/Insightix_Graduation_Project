using Graduation_Project.Hubs;
using Graduation_Project.Hubs.MachineData;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class ResourceConsumptionRefreshCurrentDataPipelineStep(MachineDataNotifier notifier) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {
        foreach (var data in input)
        {
           await notifier.SendMachineDataAsync(MachineHubType.Resource,data.MachineId,new RefreshMonitorDataDto()
           {
               MachineId = data.MachineId,
               AttributeId = data.ResourceConsumptionAttributeId,
               Value = data.Value,
               TimeStamp = data.TimeStamp
           });
        }
        return input;
    }
}