namespace Graduation_Project.Modules.Simulation;

public class SimulationManager(SimulationDataGenerator dataGenerator, SimulationDataPipelineFactory pipelineFactory)
{
    private readonly Pipeline<List<MonitoringData>> _pipeline = pipelineFactory.Create();

    public async Task RunSimulation()
    {
        var monitoringData = await dataGenerator.GenerateData();
        await _pipeline.ExecuteAsync(monitoringData);
    }
}
