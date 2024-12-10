using Graduation_Project.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class MonitoringAttributesService(IMonitoringAttributesRepository monitoringAttributesRepository):IMonitoringAttributesService
{
    public async Task Add(AddMonitoringAttributeDto addMonitoringAttributeDto)
    {
        var monitoringAttribute = new MonitoringAttribute
        {
            Name = addMonitoringAttributeDto.Name,
            Unit = addMonitoringAttributeDto.Unit,
        };
        
        await monitoringAttributesRepository.Add(monitoringAttribute);
    }

    public async Task<List<GetAllMonitoringAttributeDto>> GetAll()
    {
        var monitoringAttributes = await monitoringAttributesRepository.GetAll();
        var getMonitoringAttributeDtoList = monitoringAttributes.Select(x => new GetAllMonitoringAttributeDto
        {
            Id = x.Id,
            Name = x.Name,
            Unit = x.Unit,
        }).ToList();
        
        return getMonitoringAttributeDtoList;
    }

    public async Task<List<GetAllMonitoringAttributeDto>> GetByMachineTypeId(int machineTypeId)
    {
        var monitoringAttributes = await monitoringAttributesRepository.GetByMachineTypeId(machineTypeId);
        var getMonitoringAttributeDtoList = monitoringAttributes.Select(x => new GetAllMonitoringAttributeDto
        {
            Id = x.Id,
            Name = x.Name,
            Unit = x.Unit,
        }).ToList();
        
        return getMonitoringAttributeDtoList;
    }
}