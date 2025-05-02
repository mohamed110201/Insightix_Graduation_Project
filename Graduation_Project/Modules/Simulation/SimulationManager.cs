using Graduation_Project.Modules.MonitoringDataM;
using Graduation_Project.Modules.ResourceConsumptionDataM;
using Graduation_Project.Modules.Simulation.Monitoring;
using Graduation_Project.Modules.Simulation.ResourceConsumption;

namespace Graduation_Project.Modules.Simulation;

public class SimulationManager(MonitoringSimulationDataGenerator monitoringDataGenerator,
    ResourceConsumptionSimulationDataGenerator resourceConsumptionSimulationDataGenerator,
    ResourceConsumptionSimulationDataPipelineFactory resourceConsumptionPipelineFactory,
    MonitoringSimulationDataPipelineFactory monitoringPipelineFactory,
    IServiceProvider serviceProvider
    )
{
    
    private static readonly int DataLimitCount = 1000; 
    
    private readonly Pipeline<List<MonitoringData>> _monitoringPipeline = monitoringPipelineFactory.Create();
    private readonly Pipeline<List<ResourceConsumptionData>> _resourceConsumptionPipeline = resourceConsumptionPipelineFactory.Create();


    public async Task RunSimulation()
    {
        
        using var scope = serviceProvider.CreateScope();
        var resourceConsumptionDataRepository = scope.ServiceProvider.GetRequiredService<ResourceConsumptionDataRepository>();
        var monitoringDataRepository = scope.ServiceProvider.GetRequiredService<MonitoringDataRepository>();
        
        if (await monitoringDataRepository.Count() < DataLimitCount)
        {
            var monitoringData = await monitoringDataGenerator.GenerateData();
            await _monitoringPipeline.ExecuteAsync(monitoringData);
        }
        
        
        if (await resourceConsumptionDataRepository.Count() < DataLimitCount)
        {
            var resourceConsumptionData = await resourceConsumptionSimulationDataGenerator.GenerateData();
            await _resourceConsumptionPipeline.ExecuteAsync(resourceConsumptionData);
        }
        
    }
}
