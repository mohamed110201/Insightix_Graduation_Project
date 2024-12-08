using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation
{
    public class SystemRepository : ISystemRepository
    {
        private readonly AppDbContext _dbContext;

        public SystemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Data.Models.System Add(Data.Models.System system)
        {
            _dbContext.Add(system);
            _dbContext.SaveChanges();   
            return system;

        }

        public IEnumerable<Data.Models.System> GetAll()
        {
            return _dbContext.Systems.ToList();
        }

        public Data.Models.System? GetById(int id)
        {
            return _dbContext.Systems.Include(s => s.Machines).ThenInclude(m => m.MachineType).FirstOrDefault(s => s.Id == id);
        }

        
    }
}
