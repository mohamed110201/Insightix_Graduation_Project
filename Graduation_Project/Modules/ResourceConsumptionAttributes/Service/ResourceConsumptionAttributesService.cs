using Graduation_Project.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class ResourceConsumptionAttributesService(IResourceConsumptionAttributesRepository resourceConsumptionAttributesRepository):IResourceConsumptionAttributesService
{
    public async Task Add(AddResourceConsumptionAttributeDto addResourceConsumptionAttributeDto)
    {
        var resourceConsumptionAttribute = new ResourceConsumptionAttribute()
        {
            Name = addResourceConsumptionAttributeDto.Name,
            Unit = addResourceConsumptionAttributeDto.Unit,
        };
        
        await resourceConsumptionAttributesRepository.Add(resourceConsumptionAttribute);
    }

    public async Task<List<GetAllResourceConsumptionAttributeDto>> GetAll()
    {
        var resourceConsumptionAttributes = await resourceConsumptionAttributesRepository.GetAll();
        var getAllResourceConsumptionAttributeDtos = resourceConsumptionAttributes.Select(x => new GetAllResourceConsumptionAttributeDto()
        {
            Id = x.Id,
            Name = x.Name,
            Unit = x.Unit,
        }).ToList();
        
        return getAllResourceConsumptionAttributeDtos;
    }
}