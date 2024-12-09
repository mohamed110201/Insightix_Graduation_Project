namespace Graduation_Project.Repositories.Interfaces
{
    public interface ISystemRepository
    {
        Data.Models.System Add(Data.Models.System system);
        IEnumerable<Data.Models.System> GetAll();
        Data.Models.System? GetById(int id);

    }
}
