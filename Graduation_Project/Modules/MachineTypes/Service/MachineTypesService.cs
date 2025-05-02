using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Modules.MachineTypes.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Modules.MachineTypes.Service;

public class MachineTypesService(IMachineTypesRepository machineTypeRepository) : IMachineTypesService
{
    public async Task<List<MachineTypeGetAllDto>> GetAll()
    {
        var machineTypes = await machineTypeRepository.GetAll();
        var machineTypesDtos = machineTypes.Select(mt => new MachineTypeGetAllDto()
        {
            Id = mt.Id,
            Name = mt.Name,
            Model = mt.Model
        });
        return machineTypesDtos.ToList();
    }

    public async Task<MachineTypeGetByIdDto?> GetById(int id)
    {
        var machineType = await machineTypeRepository.GetById(id);
        if (machineType == null)
        {
            throw new NotFoundError("Machine Type not found");

        }

        var machineTypeDto = new MachineTypeGetByIdDto()
        {
            Id = machineType.Id,
            Name = machineType.Name,
            Model = machineType.Model,
            MonitoringAttributes = machineType.MachineTypeMonitoringAttributes.Select(mtma=> new AttributeWithRangesResponseDto()
            {
                AttributeId = mtma.MonitoringAttribute.Id,
                Name = mtma.MonitoringAttribute.Name,
                UpperRange = mtma.UpperRange,
                LowerRange = mtma.LowerRange,
            }).ToList(),  
            ResourceConsumptionAttributes = machineType.MachineTypeResourceConsumptionAttributes.Select(mtra => new AttributeWithRangesResponseDto()
            {
                AttributeId = mtra.ResourceConsumptionAttribute.Id,
                Name = mtra.ResourceConsumptionAttribute.Name,
                UpperRange = mtra.UpperRange,
                LowerRange = mtra.LowerRange,
            }).ToList()
        };
        return machineTypeDto;
    }

    public async Task Add(MachineTypeRequestDto machineTypeRequestDto)
    {
        var machineType = new MachineType()
        {
            Name = machineTypeRequestDto.Name,
            Model = machineTypeRequestDto.Model
        };

        if (machineTypeRequestDto.MonitoringAttributes.Any())
        {
            machineType.MachineTypeMonitoringAttributes = machineTypeRequestDto.MonitoringAttributes.Select(ma => new MachineTypeMonitoringAttribute()
            {
                MachineType = machineType,
                MonitoringAttributeId = ma.AttributeId,
                UpperRange = ma.UpperRange,
                LowerRange = ma.LowerRange
                
            }).ToList();
            
        }
        
        if (machineTypeRequestDto.ResourceConsumptionAttributes.Any())
        {
            machineType.MachineTypeResourceConsumptionAttributes = machineTypeRequestDto.ResourceConsumptionAttributes.Select(ra => new MachineTypeResourceConsumptionAttribute()
            {
                MachineType = machineType,
                ResourceConsumptionAttributeId = ra.AttributeId,
                UpperRange = ra.UpperRange,
                LowerRange = ra.LowerRange
            }).ToList();
        } 
        await machineTypeRepository.Add(machineType);
    }
}