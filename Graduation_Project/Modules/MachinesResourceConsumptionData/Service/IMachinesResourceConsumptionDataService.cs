using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.MachinesResourceConsumptionData.Service;

public interface IMachinesResourceConsumptionDataService
{
    public Task<List<GetResourceConsumptionDataDto>> GetAll(int machineId, int resourceConsumptionAttributeId,int? lastSeconds);
    public Task<GetSummaryDto> GetSummary(int machineId, int resourceConsumptionAttributeId, int? lastSeconds);
    public Task AddResourceConsumptionData(ResourceConsumptionDataDto resourceConsumptionDataDto);

}