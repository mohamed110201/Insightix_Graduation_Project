using Graduation_Project.Data;

namespace Graduation_Project.Modules.MonitoringDataM;

public class MonitoringDataRepository(AppDbContext dbContext)
{
    public async Task<int> Count()
    {
        return await dbContext.MonitoringData.CountAsync();
    }

}