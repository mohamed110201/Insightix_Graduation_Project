namespace Graduation_Project.Modules.Simulation;

public class SimulationDataPipelineFactory
{

   public Pipeline<List<MonitoringData>> create()
   {
       return new Pipeline<List<MonitoringData>>()
           .AddStep(new FailurePredictionPipelineStep())
           .AddStep(new AlertingPipelineStep())
           .AddStep(new StorePipelineStep());
   }
    
}