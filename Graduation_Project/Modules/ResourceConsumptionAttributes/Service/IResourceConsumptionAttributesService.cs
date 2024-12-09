using Graduation_Project.DTOs;

namespace Graduation_Project.Services.Interfaces;

public interface IResourceConsumptionAttributesService
{
    public Task Add(AddResourceConsumptionAttributeDto addResourceConsumptionAttributeDto);
    
    public Task<List<GetAllResourceConsumptionAttributeDto>> GetAll();
    
    public Task<List<GetAllResourceConsumptionAttributeDto>> GetByMachineTypeId(int machineTypeId);


}