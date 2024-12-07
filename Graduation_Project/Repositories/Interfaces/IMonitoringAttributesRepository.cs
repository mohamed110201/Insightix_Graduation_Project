using Graduation_Project.DTOs;

namespace Graduation_Project.Repositories.Interfaces;

public interface IMonitoringAttributesRepository
{
    public Task Add(MonitoringAttribute monitoringAttribute);
    public Task<List<MonitoringAttribute>> GetAll();
}