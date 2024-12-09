using Graduation_Project.DTOs;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMonitoringAttributesRepository
{
    public Task<List<MonitoringAttribute>> GetAll();
    public Task<List<MonitoringAttribute>> GetByMachineTypeId(int machineTypeId);
    public Task Add(MonitoringAttribute monitoringAttribute);
}