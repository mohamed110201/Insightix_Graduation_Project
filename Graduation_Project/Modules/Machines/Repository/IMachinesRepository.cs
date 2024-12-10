
namespace Graduation_Project.Repositories.Interfaces
{
    public interface IMachinesRepository
    {
        Task<List<Machine>>  GetAll();
        Task<Machine?> GetById(int id);
        Task<List<Machine>> GetMachinesBySystemId(int systemId);
        Task AddMachineToSystem(int systemId, Machine machine);
        Task<List<Machine>> GetMachinesByMachineTypeId(int machineTypeId);

        Machine? SearchBySerialNumber(string serialNumber);

    }
}
