using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;


namespace Graduation_Project.Repositories.Implementation;

public class ResourceConsumptionAttributesRepository(AppDbContext dbContext) : IResourceConsumptionAttributesRepository
{
    public async Task<List<ResourceConsumptionAttribute>> GetAll()
    {
        var resourceConsumptionAttributes = await dbContext.ResourceConsumptionAttributes.ToListAsync();
        return resourceConsumptionAttributes;
    }

    public async Task Add(ResourceConsumptionAttribute resourceConsumptionAttribute)
    {
        dbContext.ResourceConsumptionAttributes.Add(resourceConsumptionAttribute);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<ResourceConsumptionAttribute>> GetByMachineTypeId(int machineTypeId)
    {
        var machineType = await dbContext.MachineTypes
            .Where(x => x.Id == machineTypeId)
            .Select(x => new { x.ResourceConsumptionAttributes })
            .SingleOrDefaultAsync();

        if (machineType is null) throw new NullReferenceException();

        return machineType.ResourceConsumptionAttributes.ToList();
    }
}