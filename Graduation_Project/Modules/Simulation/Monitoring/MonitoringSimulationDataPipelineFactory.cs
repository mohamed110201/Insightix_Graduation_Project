using Graduation_Project.Data;
using Graduation_Project.Hubs;
using Graduation_Project.Hubs.MachineData;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesMonitoringData.Service;
using Graduation_Project.Modules.Simulation.PipeLineSteps;

namespace Graduation_Project.Modules.Simulation;

public class MonitoringSimulationDataPipelineFactory(IServiceProvider serviceProvider
, MachineDataNotifier notifier)
{


   public Pipeline<List<MonitoringData>> Create()
   {
       return new Pipeline<List<MonitoringData>>()
           .AddStep(new MonitoringRefreshCurrentDataPipelineStep(notifier))
           .AddStep(new MonitoringAlertingPipelineStep(serviceProvider))
           .AddStep(new MonitoringStorePipelineStep(serviceProvider));
   }
    
}