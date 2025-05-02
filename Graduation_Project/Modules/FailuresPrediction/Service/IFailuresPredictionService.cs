using Graduation_Project.Modules.FailuresPrediction.Dtos;

namespace Graduation_Project.Modules.FailuresPrediction.Service;

public interface IFailuresPredictionService
{
    Task<List<FailurePredictionDto>> GetAll();
    Task<List<FailurePredictionDto>> GetByMachineId(int id);
}