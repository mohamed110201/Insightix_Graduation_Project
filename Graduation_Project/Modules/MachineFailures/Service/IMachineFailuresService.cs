using Graduation_Project.Controllers.DTOs;

namespace Graduation_Project.Controllers.Repository;

public interface IMachineFailuresService
{

    public Task<List<MachineFailureGetAll>> GetAll(int machineId);

    public Task Add(int machineId);
}