namespace Graduation_Project.Modules.Failures.Repository;

public interface IFailuresRepository
{
    Task<List<Failure>> GetAll();
    Task<Failure?> GetById(int id);
    Task Resolve(int id,DateTimeOffset endDateTimeOffset);
}