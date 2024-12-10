using Graduation_Project.Data;
using Graduation_Project.DTOs;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation;

public class MonitoringAttributesRepository(AppDbContext dbContext) : IMonitoringAttributesRepository
{
    public async Task<List<MonitoringAttribute>> GetAll()
    {
        var monitoringAttributes = await dbContext.MonitoringAttributes.ToListAsync();
        return monitoringAttributes;
    }

    public async Task<List<MonitoringAttribute>> GetByMachineTypeId(int machineTypeId)
    {
        var machineType = await dbContext.MachineTypes
            .Where(x => x.Id == machineTypeId)
            .Select(x => new { x.MonitoringAttributes })
            .SingleOrDefaultAsync();

        if (machineType is null) throw new NullReferenceException();

        return machineType.MonitoringAttributes.ToList();
    }

    public async Task Add(MonitoringAttribute monitoringAttribute)
    {
        await dbContext.MonitoringAttributes.AddAsync(monitoringAttribute);
        await dbContext.SaveChangesAsync();
    }
}