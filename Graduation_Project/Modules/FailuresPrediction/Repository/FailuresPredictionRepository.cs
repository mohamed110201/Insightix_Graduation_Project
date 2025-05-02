using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.FailuresPrediction.Repository;

public class FailuresPredictionRepository(AppDbContext dbContext) : IFailuresPredictionRepository
{

    public async Task<List<FailurePrediction>> GetByMachineId(int id)
    {
        var machine = await dbContext.Machines.FindAsync(id);
        var failuresPredictions = await dbContext.FailurePredictions
            .Where(f => f.MachineId == id).Include(fp=>fp.Machine).ToListAsync();
        return failuresPredictions;
    }
    

    async Task<List<FailurePrediction>> IFailuresPredictionRepository.GetAll()
    {
        var failuresPredictions = await dbContext.FailurePredictions
            .Include(fp=>fp.Machine)
            .ToListAsync();
        return failuresPredictions;
        
    }
}