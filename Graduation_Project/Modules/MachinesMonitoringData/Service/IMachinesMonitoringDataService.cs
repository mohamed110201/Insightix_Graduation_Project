using Graduation_Project.Modules.MachinesMonitoringData.DTOs;

namespace Graduation_Project.Modules.MachinesMonitoringData.Service;

public interface IMachinesMonitoringDataService
{
    public Task<List<GetMointoringDataDto>> GetAll(int machineId, int monitoringAttributeId,int? lastSeconds);
    public Task<GetSummaryDto> GetSummary(int machineId, int monitoringAttributeId,int? lastSeconds);
    public Task<List<GetCurrentMonitoringAttributesValuesDto>> GetCurrent(int machineId);
    public Task AddMonitoringData(MonitoringDataDto monitoringDataDto);
}