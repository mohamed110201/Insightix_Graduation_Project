
namespace Graduation_Project.Repositories.Interfaces
{
    public interface IMachineRepository
    {
        IEnumerable<Machine> GetAll();
        Machine? GetById(int id);
        IEnumerable<Machine> GetMachinesBySystemId(int systemId);
        Machine AddMachineToSystem(int systemId, Machine machine);
        Task<List<Machine>> GetMachinesByMachineTypeIdAsync(int machineTypeId);
    }
}
