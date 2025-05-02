using Graduation_Project.Data;
using Graduation_Project.Data.Enums;

namespace Graduation_Project.Modules.Failures.Repository;

public class FailuresRepository(AppDbContext dbContext) : IFailuresRepository
{
    
    public Task<List<Failure>> GetAll()
    {
        return dbContext.Failures
            .OrderByDescending(x=>x.StartDateTimeOffset)
            .Include(x=>x.Machine)
            .ThenInclude(x=>x.MachineType)
            .ToListAsync();
    }

    public async Task<Failure?> GetById(int id)
    {
        return await dbContext.Failures.Include(x=>x.Machine)
            .ThenInclude(x=>x.MachineType)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Resolve(int id, DateTimeOffset endDateTimeOffset)
    {
        await dbContext.Failures
            .Where(x => x.Id == id && x.Status == FailureStatus.Pending)
            .ExecuteUpdateAsync(setters => 
                setters.SetProperty(u => u.Status, FailureStatus.Resolved)
                    .SetProperty(u => u.EndDateTimeOffset, endDateTimeOffset));
    }
}