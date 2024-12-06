using Bogus;

namespace Graduation_Project.Data.Seed;

public class SeedData
{
    private List<Models.System> _systems = null!;
    private List<MachineType> _machineTypes = null!;
    private List<Machine> _machines = null!;
    private List<MonitoringAttribute> _monitoringAttributes = null!;
    private List<ResourceConsumptionAttribute> _resourceConsumptionAttributes = null!;

    public void Seed()
    {
    }

    private void GenerateSystems()
    {
        var id = 1;
        var systemsFaker = new Faker<Models.System>()
            .RuleFor(x => x.Id, f => id++)
            .RuleFor(o => o.Name, f => f.Vehicle.Manufacturer());
        _systems = systemsFaker.Generate(10);
    }

    private void GenerateMachinesType()
    {
        var id = 1;
        var machineTypesFaker = new Faker<MachineType>()
            .RuleFor(x => x.Id, f => id++)
            .RuleFor(o => o.Name, f => f.Vehicle.Type())
            .RuleFor(x => x.Model, f => f.Vehicle.Model());


        _machineTypes = machineTypesFaker.Generate(10);
    }

    private void GenerateMonitoringAttribute()
    {
        var id = 1;
        var monitoringAttributeFaker = new Faker<MonitoringAttribute>()
            .RuleFor(x => x.Id, f => id++)
            .RuleFor(o => o.Name, f => f.Vehicle.Fuel())
            .RuleFor(x => x.Unit, f => f.Lorem.Word());


        _monitoringAttributes = monitoringAttributeFaker.Generate(10);
    }

    private void GenerateResourceConsumptionAttribute()
    {
        var id = 1;
        var resourceConsumptionAttributeFaker = new Faker<ResourceConsumptionAttribute>()
            .RuleFor(x => x.Id, f => id++)
            .RuleFor(o => o.Name, f => f.Vehicle.Fuel())
            .RuleFor(x => x.Unit, f => f.Lorem.Word());


        _resourceConsumptionAttributes = resourceConsumptionAttributeFaker.Generate(10);
    }


    private void GenerateMachine(List<MachineType> machineTypes, List<Models.System> systems)
    {
        var id = 1;
        var machineFaker = new Faker<Machine>()
            .RuleFor(x => x.Id, f => id++)
            .RuleFor(o => o.SerialNumber, f => f.Random.Uuid().ToString())
            .RuleFor(x => x.MachineTypeId, f => f.PickRandom(machineTypes).Id)
            .RuleFor(x => x.SystemId, f => f.PickRandom(systems).Id);


        _machines = machineFaker.Generate(10);
    }

    private void GenerateMachineTypeMonitoringAttribute()
    {
        var id = 1;

        var machineTypeMonitoringAttributeFaker = new Faker<MachineTypeMonitoringAttribute>()
            .RuleFor(x => x.Id, f => id++);


        machineTypeMonitoringAttributeFaker.Generate(10);
    }
}