using Graduation_Project.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class MonitoringAttributesService(IMonitoringAttributesRepository repo):IMonitoringAttributesService
{
    public async Task Add(AddMonitoringAttributeDto addMonitoringAttributeDto)
    {
        var monitoringAttribute = new MonitoringAttribute
        {
            Name = addMonitoringAttributeDto.Name,
            Unit = addMonitoringAttributeDto.Unit,
        };
        
        await repo.Add(monitoringAttribute);
    }

    public async Task<List<GetAllMonitoringAttributeDto>> GetAll()
    {
        var monitoringAttributes = await repo.GetAll();
        var getMonitoringAttributeDtoList = monitoringAttributes.Select(x => new GetAllMonitoringAttributeDto
        {
            Id = x.Id,
            Name = x.Name,
            Unit = x.Unit,
        }).ToList();
        
        return getMonitoringAttributeDtoList;
    }
}