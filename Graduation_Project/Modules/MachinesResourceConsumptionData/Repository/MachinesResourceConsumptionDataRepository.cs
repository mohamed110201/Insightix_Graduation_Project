using Graduation_Project.Data;
using Graduation_Project.Data.FunctionsData;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.MachinesResourceConsumptionData.Repository;

public class MachinesResourceConsumptionDataRepository(AppDbContext dbContext) : IMachinesResourceConsumptionDataRepository
{
    public async Task<List<MachineResourceConsumptionData>> GetAll(int machineId, int resourceConsumptionAttributeId, int windowSize, DateTime startDate, DateTime endDate)
    {
        var ResourceConsumptionData = await dbContext.DownSamplingResourceConsumptionData(machineId,
            resourceConsumptionAttributeId,
            windowSize,
            startDate,
            endDate)
            .OrderBy(d=>d.TimeStamp)
            .ToListAsync();
        return ResourceConsumptionData;
    }

    public async Task<List<GetSummaryDto>> GetSummary(int machineId, int resourceConsumptionAttributeId, DateTime startDate, DateTime endDate)
    {
        var summary = await dbContext.ResourceConsumptionData
            .Where(d => d.MachineId == machineId
                        && d.ResourceConsumptionAttributeId == resourceConsumptionAttributeId
                        && d.TimeStamp >= startDate
                        && d.TimeStamp <= endDate)
            .GroupBy(d => new { d.MachineId, d.ResourceConsumptionAttributeId })
            .Select(g => new
            GetSummaryDto()
            {
                Avg = g.Average(m => m.Value),
                Min = g.Min(m => m.Value),
                Max = g.Max(m => m.Value),
            }).ToListAsync();
        return summary;
    }

    public async Task AddResourceConsumptioData(ResourceConsumptionData resourceConsumptionData)
    {
        await dbContext.ResourceConsumptionData.AddAsync(resourceConsumptionData);
        await dbContext.SaveChangesAsync();

    }

}