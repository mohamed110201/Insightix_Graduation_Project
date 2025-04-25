using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;

namespace Graduation_Project.Modules.Simulation.ResourceConsumption.PipLineSteps;

public class ResourceConsumptionStorePipelineStep (IServiceProvider serviceProvider) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {
        using var scope = serviceProvider.CreateScope();
        var machinesResourceConsumptionDataService = scope.ServiceProvider.GetRequiredService<IMachinesResourceConsumptionDataService>();
        foreach (var resourceConsumptionData in input)
        {
            var dto = new ResourceConsumptionDataDto()
            {
                MachineId = resourceConsumptionData.MachineId,
                ResourceConsumptionAttributeId = resourceConsumptionData.ResourceConsumptionAttributeId,
                Value = resourceConsumptionData.Value,
                TimeStamp = resourceConsumptionData.TimeStamp
            };

           await machinesResourceConsumptionDataService.AddResourceConsumptionData(dto);
        }
        return input;    
        
    }
}