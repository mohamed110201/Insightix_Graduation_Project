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

public class AlertsService(
    IAlertsRepository alertsRepository,
    IMachinesRepository machinesRepository,
    IMemoryCache cache,
    AppDbContext context) : IAlertsService
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
        if (alertFromDb == null)
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
                .Select(cl => new ChangeLogsDto()
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

    public async Task ChangeStatus(int id, string status)
    {
        await alertsRepository.ChangeStatus(id, status);
    }


    private string DetermineAttribute(Alert alert)
    {
        if (alert is MonitoringAlert monitoringAlert)
            return monitoringAlert.MonitorAttributeAlertRule.MachineTypeMonitoringAttribute.MonitoringAttribute.Name;

        if (alert is ResourceConsumptionAlert resourceConsumptionAlert)
            return resourceConsumptionAlert.ResourceConsumptionAttributeAlertRule
                .MachineTypeResourceConsumptionAttribute.ResourceConsumptionAttribute.Name;

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

        throw new AppError(StatusCodes.Status404NotFound, "Unknown Alert Type");

    }
    
    
}


 
