using Graduation_Project.Modules.MonitoringDataM;
using Graduation_Project.Modules.ResourceConsumptionDataM;
using Graduation_Project.Modules.Simulation.Monitoring;
using Graduation_Project.Modules.Simulation.ResourceConsumption;

namespace Graduation_Project.Modules.Simulation;

public class SimulationManager(MonitoringSimulationDataGenerator monitoringDataGenerator,
    ResourceConsumptionSimulationDataGenerator resourceConsumptionSimulationDataGenerator,
    ResourceConsumptionSimulationDataPipelineFactory resourceConsumptionPipelineFactory,
    MonitoringSimulationDataPipelineFactory monitoringPipelineFactory,
    IServiceProvider serviceProvider,
    IConfiguration configuration
    )
{
    
    private readonly Pipeline<List<MonitoringData>> _monitoringPipeline = monitoringPipelineFactory.Create();
    private readonly Pipeline<List<ResourceConsumptionData>> _resourceConsumptionPipeline = resourceConsumptionPipelineFactory.Create();


    public async Task RunSimulation()
    {
        
        using var scope = serviceProvider.CreateScope();
        var resourceConsumptionDataRepository = scope.ServiceProvider.GetRequiredService<ResourceConsumptionDataRepository>();
        var monitoringDataRepository = scope.ServiceProvider.GetRequiredService<MonitoringDataRepository>();


        var dataLimitCount = configuration.GetValue<int?>("DataLimitCount");

        if (dataLimitCount==null)
        {
            return;
        }
        
        if (await monitoringDataRepository.Count() < dataLimitCount)
        {
            var monitoringData = await monitoringDataGenerator.GenerateData();
            await _monitoringPipeline.ExecuteAsync(monitoringData);
        }
        
        
        if (await resourceConsumptionDataRepository.Count() < dataLimitCount)
        {
            var resourceConsumptionData = await resourceConsumptionSimulationDataGenerator.GenerateData();
            await _resourceConsumptionPipeline.ExecuteAsync(resourceConsumptionData);
        }
        
    }
}
