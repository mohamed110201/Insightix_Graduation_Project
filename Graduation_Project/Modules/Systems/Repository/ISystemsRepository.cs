namespace Graduation_Project.Repositories.Interfaces
{
    public interface ISystemsRepository
    {
        Task Add(Data.Models.System system);
        Task<List<Data.Models.System>> GetAll();
        Task<Data.Models.System?> GetById(int id);

    }
}
