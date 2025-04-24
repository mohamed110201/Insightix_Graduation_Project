using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;

namespace Graduation_Project.Modules.Simulation.PipeLineSteps;

public class ResourceConsumptionStorePipelineStep (IMachinesResourceConsumptionDataService machinesResourceConsumptionDataService) : IPipelineStep<List<ResourceConsumptionData>>
{
    public async Task<List<ResourceConsumptionData>> Process(List<ResourceConsumptionData> input)
    {
        var tasks = input.Select(monitoringData =>
        {
            var dto = new ResourceConsumptionDataDto()
            {
                MachineId = monitoringData.MachineId,
                ResourceConsumptionAttributeId = monitoringData.ResourceConsumptionAttributeId,
                Value = monitoringData.Value,
                TimeStamp = monitoringData.TimeStamp
            };

            return machinesResourceConsumptionDataService.AddResourceConsumptionData(dto);
        });

        await Task.WhenAll(tasks);
        return input;    }
}