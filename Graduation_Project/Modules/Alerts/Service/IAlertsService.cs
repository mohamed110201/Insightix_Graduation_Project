using Graduation_Project.Modules.Alerts.DTOs;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.Alerts.Service;

public interface IAlertsService
{
    public Task<List<GetAllAlertsDto>> GetAll();
    public Task<GetAlertByIdDto?> GetById(int id);
    public Task<List<GetAlertsByMachineIdDto>> GetAlertsByMachineId(int machineId);
    public Task ChangeStatus(int id,string status);
    public void InvalidateRuleCache(int machineTypeId, int attributeId, string ruleType);
    public Task CheckResourceConsumptionAlertsAsync(ResourceConsumptionDataDto data);
    public Task CheckMonitoringAlertsAsync(MonitoringDataDto data);

    
}