namespace Graduation_Project.Data.Seed;

public class SeedDataLoader(AppDbContext db)
{
    public async Task Load()
    {
        var data = await SeedDataGenerator.GenerateAsync();
        await SaveToDb(data);
    }

    private async Task SaveToDb(SeedDataContainer data)
    {
        await db.Systems.AddRangeAsync(data.Systems);
        await db.SaveChangesAsync();
        await db.MachineTypes.AddRangeAsync(data.MachineTypes);
        await db.SaveChangesAsync();
        await db.MonitoringAttributes.AddRangeAsync(data.MonitoringAttributes);
        await db.SaveChangesAsync();
        await db.ResourceConsumptionAttributes.AddRangeAsync(data.ResourceConsumptionAttributes);
        await db.SaveChangesAsync();
        await db.MachineTypeMonitoringAttributes.AddRangeAsync(data.MachineTypeMonitoringAttributes);
        await db.SaveChangesAsync();
        await db.MachineTypeResourceConsumptionAttributes.AddRangeAsync(data.MachineTypeResourceConsumptionAttributes);
        await db.SaveChangesAsync();
        await db.Machines.AddRangeAsync(data.Machines);
        await db.SaveChangesAsync();
        await db.MonitoringData.AddRangeAsync(data.MonitoringData);
        await db.SaveChangesAsync();
        await db.ResourceConsumptionData.AddRangeAsync(data.ResourceConsumptionData); 
        await db.SaveChangesAsync();
    }
}