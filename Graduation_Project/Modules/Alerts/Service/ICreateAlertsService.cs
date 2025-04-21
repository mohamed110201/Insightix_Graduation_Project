using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.Alerts.Service;

public interface ICreateAlertsService
{
    public Task CheckResourceConsumptionAlertsAsync(ResourceConsumptionDataDto data);
    public Task CheckMonitoringAlertsAsync(MonitoringDataDto data);
}