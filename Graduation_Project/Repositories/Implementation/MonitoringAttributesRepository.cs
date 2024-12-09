using Graduation_Project.Data;
using Graduation_Project.DTOs;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation;

public class MonitoringAttributesRepository(AppDbContext db) : IMonitoringAttributesRepository
{
    public async Task Add(MonitoringAttribute monitoringAttribute)
    {
        await db.MonitoringAttributes.AddAsync(monitoringAttribute);
        await db.SaveChangesAsync();
    }     
    
    public async Task<List<MonitoringAttribute>> GetAll()
    {
        var monitoringAttributes = await db.MonitoringAttributes.ToListAsync();
        return monitoringAttributes;
    }  
    
}