using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class ResourceConsumptionStorePipelineStep (IMachinesResourceConsumptionDataService machinesResourceConsumptionDataService) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {

        foreach (var monitoringData in input)
        {
            var dto = new ResourceConsumptionDataDto()
            {
                MachineId = monitoringData.MachineId,
                ResourceConsumptionAttributeId = monitoringData.ResourceConsumptionAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

           await machinesResourceConsumptionDataService.AddResourceConsumptionData(dto);
        }
        return input;    
        
    }
}