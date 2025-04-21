using Graduation_Project.Modules.Alerts.DTOs;

namespace Graduation_Project.Modules.Alerts.Service;

public interface IAlertsService
{
    public Task<List<GetAllAlertsDto>> GetAll();
    public Task<GetAlertByIdDto?> GetById(int id);
    public Task<List<GetAlertsByMachineIdDto>> GetAlertsByMachineId(int machineId);
    public Task ChangeStatus(int id,string status);
    
}