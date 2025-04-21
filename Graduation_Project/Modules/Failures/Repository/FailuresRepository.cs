using Graduation_Project.Data;
using Graduation_Project.Data.Enums;

namespace Graduation_Project.Modules.Failures.Repository;

public class FailuresRepository(AppDbContext dbContext) : IFailuresRepository
{
    
    public Task<List<Failure>> GetAll()
    {
        return dbContext.Failures.OrderByDescending(x=>x.StartDateTime).ToListAsync();
    }

    public async Task<Failure?> GetById(int id)
    {
        return await dbContext.Failures.FindAsync(id);
    }

    public async Task Resolve(int id)
    {
        await dbContext.Failures
            .Where(x => x.Id == id && x.Status == FailureStatus.Pending)
            .ExecuteUpdateAsync(setters => 
                setters.SetProperty(u => u.Status, FailureStatus.Resolved)
                    .SetProperty(u => u.EndDateTime, DateTime.Now));
    }
}