using Graduation_Project.Controllers.DTOs;
using Graduation_Project.Core.ErrorHandling.Exceptions;
using Graduation_Project.Data;
using Graduation_Project.Data.Enums;

namespace Graduation_Project.Modules.Failures.Repository;

public class FailuresService(IFailuresRepository failuresRepository) : IFailuresService
{
    
    public async Task<List<FailureGetAll>> GetAll()
    {
        var failures = await failuresRepository.GetAll();

        return failures.Select(x => new FailureGetAll()
        {
            Id = x.Id,
            Status = x.Status,
            StartDateTime = x.StartDateTime,
            EndDateTime = x.EndDateTime,
            MachineId = x.MachineId,
            MachineSerialNumber = x.Machine.SerialNumber,
            MachineTypeName = x.Machine.MachineType.Name
        }).ToList();
    }

    public async Task<FailureGetById> GetById(int id)
    {
        var failure = await failuresRepository.GetById(id);
        if(failure == null) throw new NotFoundError("Failure No Found");
        return new FailureGetById()
        {
            Id = failure.Id,
            Status = failure.Status,
            StartDateTime = failure.StartDateTime,
            EndDateTime = failure.EndDateTime, 
            MachineId = failure.MachineId,
            MachineSerialNumber = failure.Machine.SerialNumber,
            MachineTypeName = failure.Machine.MachineType.Name
        };
    }
    
    public async Task Resolve(int id,DateTime? endDateTime)
    {
        await failuresRepository.Resolve(id,endDateTime??DateTime.Now);
    }
}