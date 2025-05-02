
using Graduation_Project.Modules.Machines.DTOs;

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

        Task<List<MachineForSimulation>> GetMachinesForSimulation();
        public Task<List<Machine>> GetMachinesForPrediction();
        public Task<FailurePrediction> AddPrediction(int machineId, DateTimeOffset timestamp);
        public Task UpdatePredictionCheckPoint(int machineId, DateTimeOffset checkPoint);


    }
}
