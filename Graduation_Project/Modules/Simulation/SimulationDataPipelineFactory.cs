using Graduation_Project.Data;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesMonitoringData.Service;
using Graduation_Project.Modules.Simulation.PipeLineSteps;

namespace Graduation_Project.Modules.Simulation;

public class SimulationDataPipelineFactory(ICreateAlertsService createAlertsService,
    IMachinesMonitoringDataService machinesMonitoringDataService)
    
{

   public Pipeline<List<MonitoringData>> create()
   {
       return new Pipeline<List<MonitoringData>>()
           .AddStep(new AlertingPipelineStep(createAlertsService))
           .AddStep(new StorePipelineStep(machinesMonitoringDataService));
   }
    
}