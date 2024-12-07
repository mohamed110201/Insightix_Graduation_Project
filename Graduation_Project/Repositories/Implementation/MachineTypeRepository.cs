using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Repositories.Implementation;

public class MachineTypeRepository(AppDbContext context) : IMachinetypeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<MachineType>> GetAllMachineTypesAsync()
    {
        var machineTypes = await _context.MachineTypes.ToListAsync();
        return machineTypes;
    }

    public async Task<MachineType?> GetMachineTypeByIdAsync(int id)
    {
        var machineType = await _context.MachineTypes
            .Include(mt => mt.MachineTypeMonitoringAttributes)
            .Include(mt => mt.MachineTypeResourceConsumptionAttributes)
            .FirstOrDefaultAsync(mt => mt.Id == id);
        return machineType;
    }

    public async Task<MachineType> AddMachineTypeAsync(MachineType machineType)
    {
        var machineTypeAdded = await _context.MachineTypes.AddAsync(machineType);
        await _context.SaveChangesAsync();
        return machineTypeAdded.Entity;
    }
}