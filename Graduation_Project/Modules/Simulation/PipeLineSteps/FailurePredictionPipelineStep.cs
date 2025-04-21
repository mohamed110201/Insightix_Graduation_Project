namespace Graduation_Project.Modules.Simulation;

public class FailurePredictionPipelineStep : IPipelineStep<List<MonitoringData>>
{
    public async Task<List<MonitoringData>> Process(List<MonitoringData> input)
    {
        return input;
    }
}
