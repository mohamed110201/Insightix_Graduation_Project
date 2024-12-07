using Graduation_Project.Data;
using Graduation_Project.Data.Dtos.MachineDto;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation;

public class MachineRepository(AppDbContext context) : IMachineRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<Machine>> GetMachinesByMachineTypeIdAsync(int machineTypeId)
    {
        return await _context.Machines
            .Where(m => m.MachineTypeId == machineTypeId)
            .ToListAsync();
    }
}