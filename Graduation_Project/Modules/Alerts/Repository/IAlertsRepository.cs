namespace Graduation_Project.Modules.Alerts.Repository;

public interface IAlertsRepository
{
    public Task<List<Alert>> GetAll();
    public Task<Alert?> GetById(int id);
    public Task<List<Alert>> GetAlertsByMachineId(int machineId);
    public Task ChangeStatus(int id, string status);

}