using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repositories.Implementation
{
    public class MachinesRepository(AppDbContext dbContext) : IMachinesRepository
    {
        public async Task<List<Machine>> GetAll()
        {
            return await dbContext.Machines.Include(m => m.MachineType).Include(m => m.System).ToListAsync();
        }

        public async Task<Machine?> GetById(int id)
        {
            //Will Be Adjusted Later "Alerts,Monitoring....etc"
            return await dbContext.Machines.Include(m => m.MachineType).Include(m => m.System)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Machine>> GetMachinesByMachineTypeId(int machineTypeId)
        {
            return await dbContext.Machines
                .Where(m => m.MachineTypeId == machineTypeId)
                .ToListAsync();
        }

        public async Task AddMachineToSystem(int systemId, Machine machine)
        {
            machine.SystemId = systemId;
            dbContext.Machines.Add(machine);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Machine>> GetMachinesBySystemId(int systemId)
        {
            return await dbContext.Machines
                .Include(m => m.MachineType)
                .Where(m => m.SystemId == systemId)
                .ToListAsync();
        }
    }
}