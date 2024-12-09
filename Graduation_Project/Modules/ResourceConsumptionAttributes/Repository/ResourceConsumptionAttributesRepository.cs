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
}