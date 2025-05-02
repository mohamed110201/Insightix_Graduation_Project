using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.MachineTypes.Repository;

public class MachineTypesRepository(AppDbContext dbContext) : IMachineTypesRepository
{
    public async Task<List<MachineType>> GetAll()
    {
        var machineTypes = await dbContext.MachineTypes.ToListAsync();
        return machineTypes;
    }

    public async Task<MachineType?> GetById(int id)
    {
        var machineType = await dbContext.MachineTypes
            .Include(mt=>mt.MachineTypeMonitoringAttributes)
            .ThenInclude(mtma => mtma.MonitoringAttribute)
            .Include(mt=>mt.MachineTypeResourceConsumptionAttributes)
            .ThenInclude(mtra=>mtra.ResourceConsumptionAttribute)
            .FirstOrDefaultAsync(mt => mt.Id == id);
        return machineType;
    }

    public async Task Add(MachineType machineType)
    {
        dbContext.MachineTypes.Add(machineType);
        await dbContext.SaveChangesAsync();
    }
    
    public MachineType? FindByModel(string model)
    {
        var machineType = dbContext.MachineTypes.FirstOrDefault(mt => mt.Model == model);
        return machineType;
    }
}