using Graduation_Project.DTOs;

namespace Graduation_Project.Services.Interfaces;

public interface IMonitoringAttributesService
{
    public Task Add(AddMonitoringAttributeDto addMonitoringAttributeDto);
    
    public Task<List<GetAllMonitoringAttributeDto>> GetAll();

}