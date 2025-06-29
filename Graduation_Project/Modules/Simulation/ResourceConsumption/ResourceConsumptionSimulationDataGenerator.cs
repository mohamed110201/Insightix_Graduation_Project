using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.Simulation;

public class ResourceConsumptionSimulationDataGenerator(IServiceProvider serviceProvider)
{
    public async Task<List<ResourceConsumptionData>> GenerateData()
    {
        using var scope = serviceProvider.CreateScope();
        var machinesService = scope.ServiceProvider.GetRequiredService<IMachinesService>();
        var machines = await machinesService.GetMachinesForSimulation();
        var now = DateTimeOffset.Now;
        List<ResourceConsumptionData> resourceConsumptionDataDataList = new();
        foreach (var machine in machines)
        {
            foreach (var attribute in machine.ResourceConsumptionAttributes)
            {
                resourceConsumptionDataDataList.Add(new ResourceConsumptionData()
                {
                    MachineId = machine.MachineId,
                    ResourceConsumptionAttributeId = attribute.ResourceConsumptionAttributeId,
                    TimeStamp = now,
                    Value = RandomNumber(attribute.MinNormalRange, attribute.MaxNormalRange),
                });
            }
        }
        return resourceConsumptionDataDataList;
    }

    private static Random _rand = new Random();

    private static double RandomNumber(double min, double max)
    {
        var rand = new Random();
        var value = min + (max - min) * rand.NextDouble();
        return value;
    }

}