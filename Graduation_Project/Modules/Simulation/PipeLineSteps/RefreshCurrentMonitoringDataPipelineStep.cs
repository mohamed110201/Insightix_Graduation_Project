using Graduation_Project.Hubs;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class RefreshCurrentMonitoringDataPipelineStep(MachineMonitoringDataNotifier notifier) : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        foreach (MonitoringData data in input)
        {
           await notifier.SendMachineDataAsync(data.MachineId,data);
        }
        return input;
    }
}