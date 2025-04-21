namespace Graduation_Project.Controllers.Repository;

public interface IMachineFailuresRespository
{ 
   
   Task<List<Failure>> GetAll(int machineId);

   Task Add(Failure failure);

   Task<int> GetNumberOfPendingFailures(int machineId);
}