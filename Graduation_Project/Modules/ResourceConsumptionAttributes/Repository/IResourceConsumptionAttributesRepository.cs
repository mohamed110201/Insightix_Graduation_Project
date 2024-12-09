using Graduation_Project.DTOs;

namespace Graduation_Project.Repositories.Interfaces;

public interface IResourceConsumptionAttributesRepository
{
    public Task<List<ResourceConsumptionAttribute>> GetAll();
    public Task Add(ResourceConsumptionAttribute resourceConsumptionAttribute);
    
}