using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Repositories.Interfaces;
using Graduation_Project.Services.Interfaces;

namespace Graduation_Project.Services.Implementation;

public class MachineTypeServices(IMachinetypeRepository machineTypeRepository) : IMachineTypeServices
{
    private readonly IMachinetypeRepository _machineTypeRepository = machineTypeRepository;

    public async Task<List<MachineTypeGetAllDto>> GetAllMachineTypesAsync()
    {
        var machineTypes = await _machineTypeRepository.GetAllMachineTypesAsync();
        var machineTypesDtos = machineTypes.Select(mt => new MachineTypeGetAllDto()
        {
            Id = mt.Id,
            Name = mt.Name,
            Model = mt.Model
        });
        return machineTypesDtos.ToList();
    }

    public async Task<MachineTypeGetByIdDto?> GetMachineTypeByIdAsync(int id)
    {
        var machineType = await _machineTypeRepository.GetMachineTypeByIdAsync(id);
        if (machineType == null)
        {
            throw new NullReferenceException();
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

    public async Task<MachineTypeGetByIdDto> AddMachineTypeAsync(MachineTypeRequestDto machineTypeRequestDto)
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
                MachineTypeId = machineType.Id,
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
        var machineTypeAdded = await _machineTypeRepository.AddMachineTypeAsync(machineType);
        var machineTypeDto = new MachineTypeGetByIdDto()
        {
            Id = machineTypeAdded.Id,
            Name = machineTypeAdded.Name,
            Model = machineTypeAdded.Model,
            MonitoringAttributes = machineTypeAdded.MachineTypeMonitoringAttributes.Select(ma=>ma.MonitoringAttribute.Name).ToList(),  
            ResourceConsumptionAttributes = machineTypeAdded.MachineTypeResourceConsumptionAttributes.Select(ra=>ra.ResourceConsumptionAttribute.Name).ToList()
        };
        return machineTypeDto;
    }
}