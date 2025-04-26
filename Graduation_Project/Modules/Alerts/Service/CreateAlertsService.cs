using Graduation_Project.Data;
using Graduation_Project.Data.Enums;
using Graduation_Project.Hubs.Notifications;
using Graduation_Project.Hubs.Notifications.NotificationDataDtos;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.Alerts.Service;

public class CreateAlertsService(
    AppDbContext context , IAlertsCachingService cachingService, NotificationsNotifier notificationsNotifier)  : ICreateAlertsService
{
   
    public async Task CheckMonitoringAlertsAsync(MonitoringDataDto data)
    {
        await CheckAlertsAsync<MonitorAttributeAlertRule>(data.MachineId,
            data.MonitoringAttributeId,
            data.Value,
            data.TimeStamp,
            AlertType.Monitoring,
            cachingService.GetMonitoringRulesAsync,
            CreateAlertAsync<MonitoringAlert>);
    }
    
    public async Task CheckResourceConsumptionAlertsAsync(ResourceConsumptionDataDto data)
    {
        await CheckAlertsAsync<ResourceConsumptionAttributeAlertRule>(data.MachineId,
            data.ResourceConsumptionAttributeId,
            data.Value,
            data.TimeStamp,
            AlertType.Monitoring,
            cachingService.GetResourceConsumptionRulesAsync,
            CreateAlertAsync<ResourceConsumptionAlert>);
           
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
    
    private async Task CreateAlertAsync<TAlert>(DateTime timeStamp, int machineId, int ruleId, AlertType alertType)
        where TAlert : Alert, new()
    {
        var alert = new TAlert
        {
            TimeStamp = timeStamp,
            Status = AlertStatus.Active,
            Type = alertType,
            MachineId = machineId
        };

        if (alertType == AlertType.Monitoring)
        {
            ((MonitoringAlert)(object)alert).MonitorAttributeAlertRuleId = ruleId;
        }
        else
        {
            ((ResourceConsumptionAlert)(object)alert).ResourceConsumptionAttributeAlertRuleId = ruleId;
        }

        context.Alerts.Add(alert);
        await context.SaveChangesAsync();
        context.AlertChangeLogs.Add(new AlertChangeLog
        {
            TimeStamp = timeStamp,
            Status = AlertStatus.Active,
            AlertId = alert.Id
        });

        await context.SaveChangesAsync();


        await notificationsNotifier.SendNotificationsAsync(new NotificationDto()
        {
            Type = "alert",
            Data = new NotificationAlertDataDto()
            {
                AlertId = alert.Id,
                MachineId = machineId,
                TimeStamp = timeStamp,
            }
        });
        
        cachingService.InvalidateExistingAlertCache(machineId, ruleId, alertType);
    }

    private async Task CheckAlertsAsync<TAlertRule>(
        int machineId, 
        int attributeId, 
        double value, 
        DateTime timeStamp,
        AlertType alertType,
        Func<int, int, Task<List<TAlertRule>?>> getRulesFunc,
        Func<DateTime, int,int,AlertType, Task> createAlertFunc
        )
        where TAlertRule : AlertRule
    {
        var machine = await cachingService.GetMachineAsync(machineId);
        if (machine == null)
        {
            return;
        }

        var attributeRules = await getRulesFunc(machine.MachineTypeId, attributeId);
        AlertSeverity? highestSeverity = null;
        TAlertRule? selectedRule = null;

        foreach (var rule in attributeRules!)
        {
            if (CheckRuleViolation(value, rule))
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
            var existingAlert = await cachingService.CheckExistingAlert(machineId, selectedRule.Id, alertType);
                int existingSeverity = existingAlert switch
                {
                    MonitoringAlert monitoringAlert => (int)monitoringAlert.MonitorAttributeAlertRule.Severity,
                    ResourceConsumptionAlert resourceAlert => (int)resourceAlert.ResourceConsumptionAttributeAlertRule.Severity,
                    _ => 0
                };

                if (existingAlert == null ||(int)selectedRule.Severity > existingSeverity)
                {
                    await createAlertFunc(timeStamp,machineId,selectedRule.Id, alertType); 
                }    
        }
            
    }
}
    

