namespace Graduation_Project.Modules.Simulation;

public class SimulationManager(MonitoringSimulationDataGenerator dataGenerator, MonitoringSimulationDataPipelineFactory pipelineFactory)
{
    private readonly Pipeline<List<MonitoringData>> _pipeline = pipelineFactory.Create();

    public async Task RunSimulation()
    {
        var monitoringData = await dataGenerator.GenerateData();
        await _pipeline.ExecuteAsync(monitoringData);
    }
}
