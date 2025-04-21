using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Graduation_Project.Modules.Simulation;


public class SimulationDataBackgroundService(SimulationManager simulationManager) : BackgroundService
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
      await simulationManager.RunSimulation();
    }
}
