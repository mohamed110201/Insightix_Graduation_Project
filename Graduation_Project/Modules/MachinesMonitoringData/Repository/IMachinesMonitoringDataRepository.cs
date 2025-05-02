using Graduation_Project.Data.FunctionsData;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.MachinesMonitoringData.Repository;

public interface IMachinesMonitoringDataRepository
{
    public Task<List<MachineMonitoringData>> GetAll(int machineId,
        int monitoringAttributeId,
        int windowSize,
        DateTimeOffset startDate,
        DateTimeOffset endDate);

    public Task<List<GetSummaryDto>> GetSummary(int machineId, int monitoringAttributeId, DateTimeOffset startDate, DateTimeOffset endDate);
    public Task<List<CurrentMonitoringAttributesValues>> GetCurrent(int machineId);
    public Task AddMonitorinData(MonitoringData monitoringData);
}