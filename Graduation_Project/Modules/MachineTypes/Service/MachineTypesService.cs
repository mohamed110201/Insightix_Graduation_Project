using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

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
            MonitoringAttributes = machineType.MonitoringAttributes.Select(ma=>ma.Name).ToList(),  
            ResourceConsumptionAttributes = machineType.ResourceConsumptionAttributes.Select(ra=>ra.Name).ToList()
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

        if (machineTypeRequestDto.MonitoringAttributeIds.Any())
        {
            machineType.MachineTypeMonitoringAttributes = machineTypeRequestDto.MonitoringAttributeIds.Select(maId => new MachineTypeMonitoringAttribute()
            {
                MachineType = machineType,
                MonitoringAttributeId = maId
            }).ToList();
            
        }
        
        if (machineTypeRequestDto.ResourceConsumptionAttributeIds.Any())
        {
            machineType.MachineTypeResourceConsumptionAttributes = machineTypeRequestDto.ResourceConsumptionAttributeIds.Select(raId => new MachineTypeResourceConsumptionAttribute()
            {
                MachineType = machineType,
                ResourceConsumptionAttributeId = raId
            }).ToList();
        } 
        await machineTypeRepository.Add(machineType);
    }
}