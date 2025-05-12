using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data;
using Graduation_Project.Data.Enums;

namespace Graduation_Project.Modules.Alerts.Repository;

public class AlertsRepository(AppDbContext dbContext) : IAlertsRepository
{
    public async Task<List<Alert>> GetAll()
    {
        var alerts =await  dbContext.Alerts
            .Include(al=>al.Machine)
            .Include(al=>(al as MonitoringAlert)!.MonitorAttributeAlertRule)
            .ThenInclude(mr => mr!.MachineTypeMonitoringAttribute)
            .ThenInclude(mtma => mtma!.MonitoringAttribute)
            .Include(al =>(al as ResourceConsumptionAlert)!.ResourceConsumptionAttributeAlertRule)
            .ThenInclude(rl => rl!.MachineTypeResourceConsumptionAttribute)
            .ThenInclude(mtra => mtra!.ResourceConsumptionAttribute).ToListAsync();
        return alerts;
    }

    public async Task<Alert?> GetById(int id)
    {
        var alert = await dbContext.Alerts
            .Include(al=>al.Machine)
            .Include(al =>al.ChangeLogs)
            .Include(al=>(al as MonitoringAlert)!.MonitorAttributeAlertRule)
            .ThenInclude(mr => mr!.MachineTypeMonitoringAttribute)
            .ThenInclude(mtma => mtma!.MonitoringAttribute)
            .Include(al =>(al as ResourceConsumptionAlert)!.ResourceConsumptionAttributeAlertRule)
            .ThenInclude(rl => rl!.MachineTypeResourceConsumptionAttribute)
            .ThenInclude(mtra => mtra!.ResourceConsumptionAttribute)
            .FirstOrDefaultAsync(al =>al.Id == id);
        return alert;
    }
    
    public async Task<List<Alert>> GetAlertsByMachineId(int machineId)
    {
        return await dbContext.Alerts
            .Include(al=>(al as MonitoringAlert)!.MonitorAttributeAlertRule)
            .ThenInclude(mr => mr!.MachineTypeMonitoringAttribute)
            .ThenInclude(mtma => mtma!.MonitoringAttribute)
            .Include(al =>(al as ResourceConsumptionAlert)!.ResourceConsumptionAttributeAlertRule)
            .ThenInclude(rl => rl!.MachineTypeResourceConsumptionAttribute)
            .ThenInclude(mtra => mtra!.ResourceConsumptionAttribute)
            .Where(al => al.MachineId == machineId)
            .ToListAsync();
    }

    public async Task ChangeStatus(int id, string status)
    {
        var alert =  await GetById(id);
        if(alert == null) 
            throw new NotFoundError("Alert Does Not Exist");
        
        var newStatus = Enum.Parse<AlertStatus>(status);
        await dbContext.Alerts.Where(al => al.Id == alert.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(z => z.Status,newStatus )
            );
        var changeLog = new AlertChangeLog
        {
            AlertId = alert.Id,
            Status = newStatus,
            TimeStamp = DateTimeOffset.Now
        };

        dbContext.AlertChangeLogs.Add(changeLog);
        
        await dbContext.SaveChangesAsync();

    }
}