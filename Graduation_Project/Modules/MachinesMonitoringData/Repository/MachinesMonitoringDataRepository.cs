using Graduation_Project.Data;
using Graduation_Project.Data.FunctionsData;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.MachinesMonitoringData.Repository;

public class MachinesMonitoringDataRepository(AppDbContext dbContext) : IMachinesMonitoringDataRepository
{
    public async Task<List<MachineMonitoringData>> GetAll(int machineId, int monitoringAttributeId, int windowSize, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var monitoringData = await dbContext.DownSamplingMonitoringData(machineId,
            monitoringAttributeId,
            windowSize,
            startDate,
            endDate)
            .OrderBy(d=>d.TimeStamp)
            .ToListAsync();
        return  monitoringData;
    }

    public async Task<List<GetSummaryDto>> GetSummary(int machineId, int monitoringAttributeId, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var summary = await dbContext.MonitoringData
            .Where(d => d.MachineId == machineId 
                        && d.MonitoringAttributeId == monitoringAttributeId
                        && d.TimeStamp >= startDate
                        && d.TimeStamp <= endDate)
            .GroupBy(d => new { d.MachineId, d.MonitoringAttributeId })
            .Select(g => new
            GetSummaryDto(){
                Avg = g.Average(m => m.Value),
                Min = g.Min(m => m.Value),
                Max = g.Max(m => m.Value),
            }).ToListAsync();
        return summary;
    }

    public async Task<List<CurrentMonitoringAttributesValues>> GetCurrent(int machineId)
    {
        var current = await dbContext.GetCurrentMonitoringAttributesForMachine(machineId).ToListAsync();
        return current;
    }

    public async Task AddMonitorinData(MonitoringData monitoringData)
    {
        await dbContext.MonitoringData.AddAsync(monitoringData);
        await dbContext.SaveChangesAsync();
    }
}