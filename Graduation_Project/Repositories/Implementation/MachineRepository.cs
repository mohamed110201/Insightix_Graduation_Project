using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repositories.Implementation
{
    public class MachineRepository : IMachineRepository
    {
        private readonly AppDbContext _dbContext;

        public MachineRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<Machine>> GetMachinesByMachineTypeIdAsync(int machineTypeId)
        {
             return await _dbContext.Machines
            .Where(m => m.MachineTypeId == machineTypeId)
            .ToListAsync();
        }

        public Machine AddMachineToSystem(int systemId, Machine machine)
        {
            machine.SystemId = systemId;
            _dbContext.Machines.Add(machine);
            _dbContext.SaveChanges();
            return machine;
        }

        public IEnumerable<Machine> GetAll()
        {
            return _dbContext.Machines.Include(m=>m.MachineType).Include(m => m.System).ToList();

        }

        public Machine? GetById(int id)
        {
            //Will Be Adjusted Later "Alerts,Monitoring....etc"
            return _dbContext.Machines.Include(m => m.MachineType).Include(m => m.System).FirstOrDefault(m => m.Id == id);

        }

        public IEnumerable<Machine> GetMachinesBySystemId(int systemId)
        {
            return _dbContext.Machines
                       .Include(m => m.MachineType)
                       .Where(m => m.SystemId == systemId)
                       .ToList();
        }
    }
}