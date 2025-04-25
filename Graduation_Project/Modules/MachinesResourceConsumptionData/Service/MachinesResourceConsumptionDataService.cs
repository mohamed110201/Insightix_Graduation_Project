using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Modules.MachinesResourceConsumptionData.DTOs;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Graduation_Project.Modules.MachinesResourceConsumptionData.Service;

public class MachinesResourceConsumptionDataService(IMachinesResourceConsumptionDataRepository machinesResourceConsumptionDataRepository) : IMachinesResourceConsumptionDataService
{
    public async Task<List<GetResourceConsumptionDataDto>> GetAll(int machineId 
        , int resourceConsumptionAttributeId
        , int? lastSeconds)
    {
        if(lastSeconds==null)
            throw new AppError(StatusCodes.Status400BadRequest, "Last Seconds Is Required");
        var windowSize = 60;
        var startDate = DateTime.Now.AddSeconds(-(double)lastSeconds);
        var endDate = DateTime.Now;
        var ResourceConsumptionData = await machinesResourceConsumptionDataRepository.GetAll(machineId, resourceConsumptionAttributeId, windowSize, startDate, endDate);
        var ResourceConsumptionDataDto = ResourceConsumptionData.Select(x=>new GetResourceConsumptionDataDto
        {
            TimeStamp = x.TimeStamp,
            Value = (int)x.Value,
            Count = x.Count
        });
        return ResourceConsumptionDataDto.ToList();
    }

    public async Task<GetSummaryDto> GetSummary(int machineId
        , int resourceConsumptionAttributeId
        , int? lastSeconds)
    {
        if (lastSeconds == null)
            throw new AppError(StatusCodes.Status400BadRequest, "Last Seconds Is Required");
        var startDate = DateTime.Now.AddSeconds(-(double)lastSeconds);
        var endDate = DateTime.Now;
        var summary = await machinesResourceConsumptionDataRepository.GetSummary(machineId, resourceConsumptionAttributeId, startDate, endDate);
        if (!summary.Any())
            throw new AppError(StatusCodes.Status404NotFound, "There Are No Data For This Machine");
        return summary[0];
    }

    public async Task AddResourceConsumptionData(ResourceConsumptionDataDto resourceConsumptionDataDto)
    {
        var resourceConsumptionData = new ResourceConsumptionData()
        {
            MachineId = resourceConsumptionDataDto.MachineId,
            ResourceConsumptionAttributeId = resourceConsumptionDataDto.ResourceConsumptionAttributeId,
            Value = resourceConsumptionDataDto.Value,
            TimeStamp = resourceConsumptionDataDto.TimeStamp,
        };
        await machinesResourceConsumptionDataRepository.AddResourceConsumptioData(resourceConsumptionData);
    }
}