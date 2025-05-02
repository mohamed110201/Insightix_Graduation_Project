using Graduation_Project.Controllers.DTOs;
using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Enums;
using Graduation_Project.Modules.Failures.DTOs;

namespace Graduation_Project.Controllers.Repository;

public class MachineFailuresService(IMachineFailuresRespository machineFailuresRespository) : IMachineFailuresService
{
    
    public async Task<List<MachineFailureGetAll>> GetAll(int machineId)
    {
        var failures = await machineFailuresRespository.GetAll(machineId);

        return failures.Select(x => new MachineFailureGetAll()
        {
            Id = x.Id,
            Status = x.Status,
            StartDateTimeOffset = x.StartDateTimeOffset,
            EndDateTimeOffset = x.EndDateTimeOffset,
            MachineSerialNumber = x.Machine.SerialNumber,
            MachineTypeName = x.Machine.MachineType.Name
        }).ToList();

    }

    public async Task Add(int machineId, FailureAddDTO failureAddDto)
    {
        var pendingFailures =await machineFailuresRespository.GetNumberOfPendingFailures(machineId);;

        if (pendingFailures>0)
            throw new BadRequestError("This Machine is already in failure");
        
        
        var failure = new Failure()
        {
            MachineId = machineId,
            StartDateTimeOffset = failureAddDto.StartDateTimeOffset,
            EndDateTimeOffset = failureAddDto.EndDateTimeOffset,
            Status = failureAddDto.EndDateTimeOffset == null ? FailureStatus.Pending : FailureStatus.Resolved
        };
        
        await machineFailuresRespository.Add(failure);
    }
}