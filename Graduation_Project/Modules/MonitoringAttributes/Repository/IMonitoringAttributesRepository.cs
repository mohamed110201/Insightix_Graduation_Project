using Graduation_Project.DTOs;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMonitoringAttributesRepository
{
    public Task<List<MonitoringAttribute>> GetAll();
    public Task Add(MonitoringAttribute monitoringAttribute);
}