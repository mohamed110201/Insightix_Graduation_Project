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
        db.SaveChanges();
        db.MachineTypes.AddRange(data.MachineTypes);
        db.SaveChanges();
        db.MonitoringAttributes.AddRange(data.MonitoringAttributes);
        db.SaveChanges();
        db.ResourceConsumptionAttributes.AddRange(data.ResourceConsumptionAttributes);
        db.SaveChanges();
        db.MachineTypeMonitoringAttributes.AddRange(data.MachineTypeMonitoringAttributes);
        db.SaveChanges();
        db.MachineTypeResourceConsumptionAttributes.AddRange(data.MachineTypeResourceConsumptionAttributes);
        db.SaveChanges();
        db.Machines.AddRange(data.Machines);
        db.SaveChanges();
        db.MonitoringData.AddRange(data.MonitoringData);
        db.SaveChanges();
        db.ResourceConsumptionData.AddRange(data.ResourceConsumptionData);
        db.SaveChanges();
    }
}