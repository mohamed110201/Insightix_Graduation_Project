using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class ResourceConsumptionAlertingPipelineStep(ICreateAlertsService createAlertsService) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {
        foreach (var resourceConsumptionData in input)
        {
            var dto = new ResourceConsumptionDataDto()
            {
                MachineId = resourceConsumptionData.MachineId,
                ResourceConsumptionAttributeId = resourceConsumptionData.ResourceConsumptionAttributeId,
                Value = resourceConsumptionData.Value,
                TimeStamp = resourceConsumptionData.TimeStamp
            };

            await createAlertsService.CheckResourceConsumptionAlertsAsync(dto);
        }

        return input;    
    }
}