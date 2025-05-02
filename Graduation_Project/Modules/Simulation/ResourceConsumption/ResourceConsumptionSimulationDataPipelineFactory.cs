using Graduation_Project.Hubs.MachineData;
using Graduation_Project.Modules.Simulation.ResourceConsumption.PipLineSteps;

namespace Graduation_Project.Modules.Simulation.ResourceConsumption;

public class ResourceConsumptionSimulationDataPipelineFactory(IServiceProvider serviceProvider
, MachineDataNotifier notifier)
{


   public Pipeline<List<ResourceConsumptionData>> Create()
   {
       return new Pipeline<List<ResourceConsumptionData>>()
           .AddStep(new ResourceConsumptionRefreshCurrentDataPipelineStep(notifier))
           .AddStep(new ResourceConsumptionAlertingPipelineStep(serviceProvider))
           .AddStep(new ResourceConsumptionStorePipelineStep(serviceProvider));
   }
    
}