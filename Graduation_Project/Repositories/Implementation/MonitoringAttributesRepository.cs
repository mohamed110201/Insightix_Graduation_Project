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
    public async Task Add(MonitoringAttribute monitoringAttribute)
    {
        await dbContext.MonitoringAttributes.AddAsync(monitoringAttribute);
        await dbContext.SaveChangesAsync();
    }     
}