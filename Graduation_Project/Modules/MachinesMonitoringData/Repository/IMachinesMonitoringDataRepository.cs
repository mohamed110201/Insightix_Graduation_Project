using Graduation_Project.Data.FunctionsData;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.MachinesMonitoringData.Repository;

public interface IMachinesMonitoringDataRepository
{
    public Task<List<MachineMonitoringData>> GetAll(int machineId,
        int monitoringAttributeId,
        int windowSize,
        DateTime startDate,
        DateTime endDate);

    public Task<List<GetSummaryDto>> GetSummary(int machineId, int monitoringAttributeId, DateTime startDate, DateTime endDate);
    public Task<List<CurrentMonitoringAttributesValues>> GetCurrent(int machineId);
}