using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation
{
    public class SystemsRepository(AppDbContext dbContext) : ISystemsRepository
    {
        public async Task Add(Data.Models.System system)
        {
            dbContext.Add(system);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Data.Models.System>> GetAll()
        {
            return await dbContext.Systems.ToListAsync();
        }

        public async Task<Data.Models.System?> GetById(int id)
        {
            return await dbContext.Systems.Include(s => s.Machines).ThenInclude(m => m.MachineType)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}