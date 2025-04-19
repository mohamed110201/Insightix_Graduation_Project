using System.Data.SqlTypes;
using System.Text;
using System.Text.Json;
using Graduation_Project.Data;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.FailuresPrediction;

public class FailuresPredictionManger()
{
    private readonly IServiceProvider _serviceProvider;

    public FailuresPredictionManger( IServiceProvider serviceProvider ) : this()
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ExecuteProcedure()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var machinesRepository = scope.ServiceProvider.GetRequiredService<IMachinesRepository>();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await Work(machinesRepository, context);
        }
    }
    private HttpClient httpClient = new HttpClient();
    private async Task Work(IMachinesRepository machinesRepository
    , AppDbContext context)
    {
        var machines = await machinesRepository.GetMachinesForPrediction();
        foreach (var m in machines)
        {
            var now = DateTime.Now;
            var data = await context.GetMachineMonitoringData(m.Id
                ,m.FailurePredictionCheckPoint?? (DateTime)(SqlDateTime.MinValue)
                ,now);
            var requestBody = new AiRequestBody()
            {
                ModelName = "best_model_overall.py",
                Data = data
            };
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "http://127.0.0.1:8000/predict/";
            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AiResponseBody>(responseBody);
            if (response.IsSuccessStatusCode && result is not null && result.Prediction is not null)
            {
                if (result.Prediction! == true)
                {
                    Console.WriteLine($"Prediction: {result.Prediction}");
                    await machinesRepository.AddPrediction(m.Id, now);
                }
                await  machinesRepository.UpdatePredictionCheckPoint(m.Id, now);
            }
            
        }
        
    }
}