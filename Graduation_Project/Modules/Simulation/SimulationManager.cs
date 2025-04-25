using Graduation_Project.Modules.Simulation.Monitoring;
using Graduation_Project.Modules.Simulation.ResourceConsumption;

namespace Graduation_Project.Modules.Simulation;

public class SimulationManager(MonitoringSimulationDataGenerator monitoringDataGenerator,
    ResourceConsumptionSimulationDataGenerator resourceConsumptionSimulationDataGenerator,
    ResourceConsumptionSimulationDataPipelineFactory resourceConsumptionPipelineFactory,
    MonitoringSimulationDataPipelineFactory monitoringpipelineFactory)
{
    private readonly Pipeline<List<MonitoringData>> _monitoringPipeline = monitoringpipelineFactory.Create();
    private readonly Pipeline<List<ResourceConsumptionData>> _resourceConsumptionPipeline = resourceConsumptionPipelineFactory.Create();


    public async Task RunSimulation()
    {
        var monitoringData = await monitoringDataGenerator.GenerateData();
        var resourceConsumptionData = await resourceConsumptionSimulationDataGenerator.GenerateData();

        await _monitoringPipeline.ExecuteAsync(monitoringData);
        await _resourceConsumptionPipeline.ExecuteAsync(resourceConsumptionData);
    }
}
