using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data;
using Graduation_Project.Data.Enums;
using Graduation_Project.Modules.Alerts.DTOs;
using Graduation_Project.Modules.Alerts.Repository;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Graduation_Project.Modules.Alerts.Service;

public class AlertsService(IAlertsRepository alertsRepository,IMachinesRepository machinesRepository ,IMemoryCache cache , AppDbContext context) : IAlertsService
{
    public async Task<List<GetAllAlertsDto>> GetAll()
    {
        var alertsFromDb = await alertsRepository.GetAll();
        var alertsDto = alertsFromDb.Select(al => new GetAllAlertsDto
        {
            Id = al.Id,
            TimeStamp = al.TimeStamp,
            Status = al.Status.ToString(),
            Severity = DetermineSeverity(al),
            Condition = DetermineCondition(al),
            MachineSerialNumber = al.Machine.SerialNumber,
            Attribute = DetermineAttribute(al),
            Type = al.Type.ToString(),
            Value = DetermineValue(al),
        });
        return alertsDto.ToList();
    }
    
    public async Task<GetAlertByIdDto?> GetById(int id)
    {
        var alertFromDb = await alertsRepository.GetById(id);
        if(alertFromDb ==null)
            throw new NotFoundError("This Alert Does Not Exist");
        var alert = new GetAlertByIdDto()
        {
            Id = alertFromDb.Id,
            TimeStamp = alertFromDb.TimeStamp,
            Status = alertFromDb.Status.ToString(),
            Severity = DetermineSeverity(alertFromDb),
            Condition = DetermineCondition(alertFromDb),
            MachineSerialNumber = alertFromDb.Machine.SerialNumber,
            Attribute = DetermineAttribute(alertFromDb),
            Type = alertFromDb.Type.ToString(),
            Value = DetermineValue(alertFromDb),
            ChangeLogs = alertFromDb.ChangeLogs
                .Select(cl =>new ChangeLogsDto()
                {
                    Id = cl.Id,
                    TimeStamp = cl.TimeStamp,
                    Status = cl.Status.ToString(),
                })
                .ToList()
        };
        return alert;
    }

    public async Task<List<GetAlertsByMachineIdDto>> GetAlertsByMachineId(int machineId)
    {
        var machine = await machinesRepository.GetById(machineId);
        if (machine == null)
        {
            throw new NotFoundError("This Machine Does Not Exist");
        }
        var alertsFromDb = await alertsRepository.GetAlertsByMachineId(machineId);

        var alertsDto = alertsFromDb.Select(al => new GetAlertsByMachineIdDto()
        {
            Id = al.Id,
            TimeStamp = al.TimeStamp,
            Status = al.Status.ToString(),
            Severity = DetermineSeverity(al),
            Condition = DetermineCondition(al),
            Attribute = DetermineAttribute(al),
            
        });
        return alertsDto.ToList();
        
    }

    public async Task ChangeStatus(int id,string status)
    {
        await alertsRepository.ChangeStatus(id,status);
    }


    private string DetermineAttribute(Alert alert)
    {
        if (alert is MonitoringAlert monitoringAlert)
            return monitoringAlert.MonitorAttributeAlertRule.MachineTypeMonitoringAttribute.MonitoringAttribute.Name;
        
        if (alert is ResourceConsumptionAlert resourceConsumptionAlert)
            return resourceConsumptionAlert.ResourceConsumptionAttributeAlertRule.MachineTypeResourceConsumptionAttribute.ResourceConsumptionAttribute.Name;
        
        return "Unknown Attribute";
        
    }
    
    private string DetermineSeverity(Alert alert)
    {
        if (alert is MonitoringAlert monitoringAlert)
            return monitoringAlert.MonitorAttributeAlertRule.Severity.ToString();
        
        if (alert is ResourceConsumptionAlert resourceConsumptionAlert)
            return resourceConsumptionAlert.ResourceConsumptionAttributeAlertRule.Severity.ToString();
        
        return "Unknown Severity";
        
    }
    
    private string DetermineCondition(Alert alert)
    {
        if (alert is MonitoringAlert monitoringAlert)
            return monitoringAlert.MonitorAttributeAlertRule.Condition.ToString();
        
        if (alert is ResourceConsumptionAlert resourceConsumptionAlert)
            return resourceConsumptionAlert.ResourceConsumptionAttributeAlertRule.Condition.ToString();
        
        return "Unknown Condition";
        
    }
    
    private double DetermineValue(Alert alert)
    {
        if (alert is MonitoringAlert monitoringAlert)
            return monitoringAlert.MonitorAttributeAlertRule.Value;
        
        if (alert is ResourceConsumptionAlert resourceConsumptionAlert)
            return resourceConsumptionAlert.ResourceConsumptionAttributeAlertRule.Value;
        
        throw new AppError(StatusCodes.Status404NotFound,"Unknown Alert Type");
        
    }


    private async Task<List<MonitorAttributeAlertRule>?> GetMonitoringRulesAsync(int machineTypeId, int attributeId)
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
    public async Task CheckMonitoringAlertsAsync(MonitoringDataDto data)
    {

        var machine = await GetMachineAsync(data.MachineId);
        if (machine == null)
        {
            return;
        }

        var attributeRules = await GetMonitoringRulesAsync(machine.MachineTypeId, data.MonitoringAttributeId);
        AlertSeverity? highestSeverity = null; 
        MonitorAttributeAlertRule? selectedRule = null;
        foreach (var rule in attributeRules!)
        {
            if (CheckRuleViolation(data.Value, rule))
            {
                if (highestSeverity == null || (int)rule.Severity > (int)highestSeverity)
                {
                    highestSeverity = rule.Severity;
                    selectedRule = rule;
                }
            }
        }

        if (selectedRule != null)
        {
            await CreateMonitoringAlertAsync(data, selectedRule);
        }
    }
    private async Task CreateMonitoringAlertAsync(MonitoringDataDto data, MonitorAttributeAlertRule rule)
    {
        var alert = new MonitoringAlert
        {
            TimeStamp = data.TimeStamp,
            Status = AlertStatus.Active,
            Type = AlertType.Monitoring,
            MachineId = data.MachineId,
            MonitorAttributeAlertRuleId = rule.Id
        };

        context.Alerts.Add(alert);
        await context.SaveChangesAsync();

        context.AlertChangeLogs.Add(new AlertChangeLog
        {
            TimeStamp = DateTime.Now,
            Status = AlertStatus.Active,
            AlertId = alert.Id
        });
        await context.SaveChangesAsync();

    }

    
    private async Task<List<ResourceConsumptionAttributeAlertRule>?> GetResourceConsumptionRulesAsync(int machineTypeId, int attributeId)
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
    public async Task CheckResourceConsumptionAlertsAsync(ResourceConsumptionDataDto data)
    {
        var machine = await GetMachineAsync(data.MachineId);
        if (machine == null)
        {
            return;
        }

        var attributeRules =
            await GetResourceConsumptionRulesAsync(machine.MachineTypeId, data.ResourceConsumptionAttributeId);
        AlertSeverity? highestSeverity = null;
        ResourceConsumptionAttributeAlertRule? selectedRule = null;
        foreach (var rule in attributeRules!)
        {
            if (CheckRuleViolation(data.Value, rule))
            {
                if (highestSeverity == null || (int)highestSeverity < (int)rule.Severity)
                {
                    highestSeverity = rule.Severity;
                    selectedRule = rule;
                }
            }
        }
        if (selectedRule != null)
        {
            await CreateResourceConsumptionAlertAsync(data, selectedRule);
        }
    }
    private async Task CreateResourceConsumptionAlertAsync(ResourceConsumptionDataDto data, ResourceConsumptionAttributeAlertRule rule)
    {
        var alert = new ResourceConsumptionAlert
        {
            TimeStamp = data.TimeStamp,
            Status = AlertStatus.Active,
            Type = AlertType.ResourceConsumption,
            MachineId = data.MachineId,
            ResourceConsumptionAttributeAlertRuleId = rule.Id
        };

        context.Alerts.Add(alert);
        context.AlertChangeLogs.Add(new AlertChangeLog
        {
            TimeStamp = DateTime.Now,
            Status = AlertStatus.Active,
            AlertId = alert.Id
        });

        await context.SaveChangesAsync();
    }

    
    private async Task<Machine?> GetMachineAsync(int machineId)
    {
        var cacheKey = $"Machine_{machineId}";
        return await cache.GetOrCreateAsync(cacheKey, async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(10); 
            return await context.Machines
                .Include(m => m.MachineType)
                .FirstOrDefaultAsync(m => m.Id == machineId);
        });
    }

    private bool CheckRuleViolation(double dataValue, AlertRule rule)
    {
        return rule.Condition switch
        {
            AlertCondition.More => dataValue > rule.Value,
            AlertCondition.Less => dataValue < rule.Value,
            _ => false
        };
    }

    public void InvalidateRuleCache(int machineTypeId, int attributeId, string ruleType)
    {
        var cacheKey = ruleType == "ResourceConsumption"
            ? $"ResourceConsumptionRules_{machineTypeId}_{attributeId}"
            : $"MonitoringRules_{machineTypeId}_{attributeId}";
        cache.Remove(cacheKey);
    }
}

