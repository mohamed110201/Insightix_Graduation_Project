namespace Graduation_Project.Modules.FailuresPrediction.Repository;

public interface IFailuresPredictionRepository
{
    Task<List<FailurePrediction>> GetAll();
    Task<List<FailurePrediction>> GetByMachineId(int id);
  
}