namespace Graduation_Project.Data.Seed;

public class SeedDataLoader(AppDbContext db)
{
    public void Load()
    {
        var data = SeedDataGenerator.Generate();
        SaveToDb(data);
    }

    private void SaveToDb(SeedDataContainer data)
    {
        db.Systems.AddRange(data.Systems);
        db.MachineTypes.AddRange(data.MachineTypes);
        db.MonitoringAttributes.AddRange(data.MonitoringAttributes);
        db.ResourceConsumptionAttributes.AddRange(data.ResourceConsumptionAttributes);
        db.MachineTypeMonitoringAttributes.AddRange(data.MachineTypeMonitoringAttributes);
        db.MachineTypeResourceConsumptionAttributes.AddRange(data.MachineTypeResourceConsumptionAttributes);
        db.Machines.AddRange(data.Machines);
        db.SaveChanges();
    }
}