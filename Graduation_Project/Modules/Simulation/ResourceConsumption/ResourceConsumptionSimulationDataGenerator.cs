using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.Simulation;

public class ResourceConsumptionSimulationDataGenerator(IServiceProvider serviceProvider)
{
    public async Task<List<ResourceConsumptionData>> GenerateData()
    {
        using var scope = serviceProvider.CreateScope();
        var machinesService = scope.ServiceProvider.GetRequiredService<IMachinesService>();
        var machines = await machinesService.GetMachinesForSimulation();
        var now = DateTime.Now;
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

    private static int RandomNumber(int min, int max)
    {
        return _rand.Next(min, max); 
    }
}