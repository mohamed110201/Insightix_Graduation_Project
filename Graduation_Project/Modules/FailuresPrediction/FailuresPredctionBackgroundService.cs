
namespace Graduation_Project.Modules.FailuresPrediction;

public class FailuresPredctionBackgroundService(FailuresPredictionManger failuresPredictionManger) : BackgroundService
{
    static TimeSpan _period = TimeSpan.FromSeconds(5);
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Work();
            await Task.Delay(_period, stoppingToken);
        }
    }

    async Task Work()
    {
        await failuresPredictionManger.ExecuteProcedure();
    }
}