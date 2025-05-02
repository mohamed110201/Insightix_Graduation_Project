using Graduation_Project.Modules.FailuresPrediction.Dtos;
using Graduation_Project.Modules.FailuresPrediction.Repository;

namespace Graduation_Project.Modules.FailuresPrediction.Service;

public class FailuresPredictionService(IFailuresPredictionRepository failuresPredictionRepository) : IFailuresPredictionService
{
    public async Task<List<FailurePredictionDto>> GetAll()
    {
        var failurePredictions = await failuresPredictionRepository.GetAll();
        return failurePredictions.Select(fp => new FailurePredictionDto()
        {
            Id = fp.Id,
            MachineSerialNumber = fp.Machine.SerialNumber,
            TimeStamp = fp.TimeStamp
        }).ToList();
    }

    public async Task<List<FailurePredictionDto>> GetByMachineId(int id)
    {
        var machineFailurePredictions = await failuresPredictionRepository.GetByMachineId(id);
        return machineFailurePredictions.Select(fp => new FailurePredictionDto()
        {
            Id = fp.Id,
            MachineSerialNumber = fp.Machine.SerialNumber,
            TimeStamp = fp.TimeStamp
        }).ToList();
    }
}