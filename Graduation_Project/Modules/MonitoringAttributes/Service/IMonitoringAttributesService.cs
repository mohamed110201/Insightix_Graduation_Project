using Graduation_Project.DTOs;
using Graduation_Project.Modules.MonitoringAttributes.DTOs;

namespace Graduation_Project.Services.Interfaces;

public interface IMonitoringAttributesService
{
    public Task Add(AddMonitoringAttributeDto addMonitoringAttributeDto);
    
    public Task<List<GetAllMonitoringAttributeDto>> GetAll();
    public Task<List<GetAllMonitoringAttributeDto>> GetByMachineTypeId(int machineTypeId);


}