using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.Simulation;

public class MonitoringSimulationDataGenerator(IServiceProvider serviceProvider)
{
    public async Task<List<MonitoringData>> GenerateData()
    {
        using var scope = serviceProvider.CreateScope();
        var machinesService = scope.ServiceProvider.GetRequiredService<IMachinesService>();
        var machines = await machinesService.GetMachinesForSimulation();
        var now = DateTime.Now;
        List<MonitoringData> monitoringDataList = new();
        foreach (var machine in machines)
        {
            foreach (var attribute in machine.MonitoringAttributes)
            {
                monitoringDataList.Add(new MonitoringData()
                {
                    MachineId = machine.MachineId,
                    MonitoringAttributeId = attribute.MonitoringAttributeId,
                    TimeStamp = now,
                    Value = RandomNumber(attribute.MinNormalRange, attribute.MaxNormalRange),
                });
            }
        }
        return monitoringDataList;
    }

    private static Random _rand = new Random();

    private static double RandomNumber(double min, double max)
    {
        var rand = new Random();
        var value = min + (max - min) * rand.NextDouble();
        return value;
    }

}