using Graduation_Project.Data.FunctionsData;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;

namespace Graduation_Project.Modules.MachinesResourceConsumptionData.Repository;

public interface IMachinesResourceConsumptionDataRepository
{
    public Task<List<MachineResourceConsumptionData>> GetAll(int machineId,
        int resourceConsumptionAttributeId,
        int windowSize,
        DateTimeOffset startDate,
        DateTimeOffset endDate);

    public Task<List<GetSummaryDto>> GetSummary(int machineId, int resourceConsumptionAttributeId, DateTimeOffset startDate, DateTimeOffset endDate);
    public Task AddResourceConsumptioData(ResourceConsumptionData resourceConsumptionData);

}