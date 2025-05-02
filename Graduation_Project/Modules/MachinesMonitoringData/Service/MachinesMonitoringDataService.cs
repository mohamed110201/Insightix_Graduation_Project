using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Graduation_Project.Modules.MachinesMonitoringData.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Graduation_Project.Modules.MachinesMonitoringData.Service;

public class MachinesMonitoringDataService(IMachinesMonitoringDataRepository machinesMonitoringDataRepository) : IMachinesMonitoringDataService
{
    public async Task<List<GetMointoringDataDto>> GetAll(int machineId 
        , int monitoringAttributeId
        ,int? lastSeconds)
    {
        if(lastSeconds==null)
            throw new AppError(StatusCodes.Status400BadRequest, "Last Seconds Is Required");
        var windowSize = 60;
        var startDate = DateTime.Now.AddSeconds(-(double)lastSeconds);
        var endDate = DateTime.Now;
        var monitoringData = await machinesMonitoringDataRepository.GetAll(machineId, monitoringAttributeId,windowSize, startDate, endDate);
        var monitoringDataDto = monitoringData.Select(x=>new GetMointoringDataDto
        {
            TimeStamp = x.TimeStamp,
            Value = x.Value,
            Count = x.Count
        });
        return monitoringDataDto.ToList();
    }

    public async Task<GetSummaryDto> GetSummary(int machineId
        , int monitoringAttributeId
        ,int? lastSeconds)
    {
        if(lastSeconds==null)
            throw new AppError(StatusCodes.Status400BadRequest, "Last Seconds Is Required");
        var startDate = DateTime.Now.AddSeconds(-(double)lastSeconds);
        var endDate = DateTime.Now;
        var summary = await machinesMonitoringDataRepository.GetSummary(machineId,monitoringAttributeId,startDate, endDate);
        if(!summary.Any())
            throw new AppError(StatusCodes.Status404NotFound, "There Are No Data For This Machine");
        return summary[0];
    }
    
    public async Task<List<GetCurrentMonitoringAttributesValuesDto>> GetCurrent(int machineId)
    {
        var current = await machinesMonitoringDataRepository.GetCurrent(machineId);
        var currentDto = current.Select(x => new GetCurrentMonitoringAttributesValuesDto
        {
            TimeStamp = x.TimeStamp,
            Value = x.Value,
            MonitoringAttributeId = x.MonitoringAttributeId,
            MonitoringAttributeName = x.MonitoringAttributeName
        }).ToList();
        return currentDto; 
    }

    public async Task AddMonitoringData(MonitoringDataDto monitoringDataDto)
    {
            var monitoringData = new MonitoringData()
            {
                MachineId = monitoringDataDto.MachineId,
                MonitoringAttributeId = monitoringDataDto.MonitoringAttributeId,
                Value = monitoringDataDto.Value,
                TimeStamp = monitoringDataDto.TimeStamp,
            };
            await machinesMonitoringDataRepository.AddMonitorinData(monitoringData);
        }
    }

