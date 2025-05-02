using Graduation_Project.Data;

namespace Graduation_Project.Modules.ResourceConsumptionDataM;

public class ResourceConsumptionDataRepository(AppDbContext dbContext)
{
    public async Task<int> Count()
    {
        return await dbContext.ResourceConsumptionData.CountAsync();
    }

}