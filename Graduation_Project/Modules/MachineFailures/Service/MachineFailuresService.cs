using Graduation_Project.Controllers.DTOs;
using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data.Enums;

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
            StartDateTime = x.StartDateTime,
            EndDateTime = x.EndDateTime,
        }).ToList();

    }

    public async Task Add(int machineId)
    {

        var pendingFailures =await machineFailuresRespository.GetNumberOfPendingFailures(machineId);;

        if (pendingFailures>0)
            throw new BadRequestError("This Machine is already in failure");
        
        
        var failure = new Failure()
        {
            MachineId = machineId,
            StartDateTime = DateTime.Now,
            Status = FailureStatus.Pending
        };
        
        await machineFailuresRespository.Add(failure);
    }
    
}