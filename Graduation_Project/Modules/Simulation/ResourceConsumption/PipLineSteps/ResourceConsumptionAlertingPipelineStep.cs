using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.Simulation.ResourceConsumption.PipLineSteps;

public class ResourceConsumptionAlertingPipelineStep(IServiceProvider serviceProvider) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {
        using var scope = serviceProvider.CreateScope();
        var createAlertsService = scope.ServiceProvider.GetRequiredService<ICreateAlertsService>();
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