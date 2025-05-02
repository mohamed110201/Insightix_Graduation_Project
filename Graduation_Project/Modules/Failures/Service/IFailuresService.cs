using Graduation_Project.Controllers.DTOs;

namespace Graduation_Project.Modules.Failures.Repository;

public interface IFailuresService
{
    Task<List<FailureGetAll>> GetAll();
    public Task<FailureGetById> GetById(int id);
    Task Resolve(int id,DateTime? endDateTime);
}