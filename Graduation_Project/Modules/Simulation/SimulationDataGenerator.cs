using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.Simulation;

public class SimulationDataGenerator(IMachinesService machinesService)
{
    public async Task<List<MonitoringData>> GenerateData()
    {
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
                    TimeStamp = now,
                    Value = RandomNumber(attribute.MinNormalRange, attribute.MaxNormalRange),
                });
            }
        }
        return monitoringDataList;
    }

    private static int RandomNumber(int min, int max)
    {
        var rand = new Random();
        var value = min + (max - min) * (int)rand.NextDouble();
        return value;
    }
}