using Graduation_Project.Data;
using Graduation_Project.Data.Enums;
using Graduation_Project.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Graduation_Project.Modules.Alerts.Service;

public class AlertsCachingService(
    IMachinesRepository machinesRepository,
    IMemoryCache cache,
    AppDbContext context) : IAlertsCachingService
{
    public async Task<Machine?> GetMachineAsync(int machineId)
    {
        var cacheKey = $"Machine_{machineId}";
        return await cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(10);
            return await machinesRepository.GetById(machineId);
        });
    }

    
    public async Task<List<MonitorAttributeAlertRule>?> GetMonitoringRulesAsync(int machineTypeId, int attributeId)
    {
        var cacheKey = $"MonitoringRules_{machineTypeId}_{attributeId}";
        return await cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(10);
            return await context.MachineTypeMonitoringAttributes
                .Where(m => m.MachineTypeId == machineTypeId && m.MonitoringAttributeId == attributeId)
                .SelectMany(m => m.AlertRules)
                .ToListAsync();
        });
    } 
    
    public async Task<List<ResourceConsumptionAttributeAlertRule>?> GetResourceConsumptionRulesAsync(int machineTypeId,
        int attributeId)
    {
        var cacheKey = $"ResourceConsumptionRules_{machineTypeId}_{attributeId}";
        return await cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(10);
            return await context.MachineTypeResourceConsumptionAttributes
                .Where(m => m.MachineTypeId == machineTypeId && m.ResourceConsumptionAttributeId == attributeId)
                .SelectMany(m => m.AlertRules)
                .ToListAsync();
        });
    }


    public async Task<Alert?> CheckExistingAlert(int machineId, int ruleId, AlertType alertType)
    {
        var cacheKey = $"ExistingAlert_{machineId}_{ruleId}_{alertType}";
        return await cache.GetOrCreateAsync<Alert?>(cacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(5); 

            if (alertType == AlertType.Monitoring)
            {
                return await context.Alerts
                    .OfType<MonitoringAlert>()
                    .Include(a => a.MonitorAttributeAlertRule)
                    .Where(a => a.MachineId == machineId &&
                                a.MonitorAttributeAlertRuleId == ruleId &&
                                a.Status == AlertStatus.Active)
                    .OrderByDescending(a => a.TimeStamp)
                    .FirstOrDefaultAsync();
            }
            else 
            {
                return await context.Alerts
                    .OfType<ResourceConsumptionAlert>()
                    .Include(a => a.ResourceConsumptionAttributeAlertRule)
                    .Where(a => a.MachineId == machineId &&
                                a.ResourceConsumptionAttributeAlertRuleId == ruleId &&
                                a.Status == AlertStatus.Active)
                    .OrderByDescending(a => a.TimeStamp)
                    .FirstOrDefaultAsync();
            }
        });
    }

    public void InvalidateRuleCache(int machineTypeId, int attributeId, string ruleType)
    {
        var cacheKey = ruleType == "ResourceConsumption"
            ? $"ResourceConsumptionRules_{machineTypeId}_{attributeId}"
            : $"MonitoringRules_{machineTypeId}_{attributeId}";
        cache.Remove(cacheKey);
    }
    public void InvalidateExistingAlertCache(int machineId, int ruleId, AlertType alertType)
    {
        var cacheKey = $"ExistingAlert_{machineId}_{ruleId}_{alertType}";
        cache.Remove(cacheKey);
    }

}