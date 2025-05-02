using Graduation_Project.Data;
using Graduation_Project.Data.Enums;

namespace Graduation_Project.Controllers.Repository;

public class MachineFailuresRespository(AppDbContext dbContext) : IMachineFailuresRespository
{
    
    
   public Task<List<Failure>> GetAll(int machineId)
    {
        return dbContext.Failures
            .OrderByDescending(x=>x.StartDateTime)
            .Where(f => f.MachineId == machineId)
            .Include(x=>x.Machine)
            .ThenInclude(x=>x.MachineType)
            .ToListAsync();
    }

    public async Task Add(Failure failure)
    {
        await dbContext.Failures.AddAsync(failure);
        await dbContext.SaveChangesAsync();
    }
    
    public Task<int> GetNumberOfPendingFailures(int machineId)
    {
        return dbContext.Failures.Where(f => f.MachineId == machineId && f.Status == FailureStatus.Pending).CountAsync();
    }
}