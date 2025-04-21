using Graduation_Project.Data.Enums;
namespace Graduation_Project.Modules.Alerts.Service;

public interface IAlertsCachingService
{
    public Task<Machine?> GetMachineAsync(int machineId);
    public Task<List<MonitorAttributeAlertRule>?> GetMonitoringRulesAsync(int machineTypeId, int attributeId);

    public Task<List<ResourceConsumptionAttributeAlertRule>?> GetResourceConsumptionRulesAsync(int machineTypeId,
        int attributeId);

    public Task<Alert?> CheckExistingAlert(int machineId, int ruleId, AlertType alertType);
    public void InvalidateRuleCache(int machineTypeId, int attributeId, string ruleType);

    public void InvalidateExistingAlertCache(int machineId, int ruleId, AlertType alertType);
}