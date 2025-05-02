using System.Data.SqlTypes;
using System.Text;
using System.Text.Json;
using Graduation_Project.Data;
using Graduation_Project.Hubs.Notifications;
using Graduation_Project.Hubs.Notifications.NotificationDataDtos;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.FailuresPrediction;

public class FailuresPredictionManger(IServiceProvider serviceProvider,NotificationsNotifier notificationsNotifier)
{
    private const string failurePredictionServiceUrl = "http://127.0.0.1:8000/predict";
    private const string modelName = "best_model_overall.py";
    private HttpClient httpClient = new HttpClient();



    public async Task ExecuteProcedure()
    {
        using var scope = serviceProvider.CreateScope();
        var machinesRepository = scope.ServiceProvider.GetRequiredService<IMachinesRepository>();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await Work(machinesRepository, context);
    }
    private async Task Work(IMachinesRepository machinesRepository, AppDbContext context)
    {
        var machines = await machinesRepository.GetMachinesForPrediction();
        foreach (var m in machines)
        {
            var now = DateTime.Now;
            var data = await context.GetMachineMonitoringData(m.Id
                ,m.FailurePredictionCheckPoint?? (DateTime)(SqlDateTime.MinValue)
                ,now);

            if (data.Count == 0) {
                continue;
            }
            
            var prediction = await SendFailurePredictionRequest(data);

            if (prediction == null) {
                continue;
            }

            if (prediction == true) {
                await machinesRepository.AddPrediction(m.Id, now);
                await notificationsNotifier.SendNotificationsAsync(new NotificationDto()
                {
                    Type = "failurePrediction",
                    Data = new NotificationFailurePredictionDataDto()
                    {
                        MachineSerialNumber = m.SerialNumber,
                        TimeStamp = now,
                    }
                });
            }
                
            await  machinesRepository.UpdatePredictionCheckPoint(m.Id, now);
        }
        
    }

    private async Task<bool?> SendFailurePredictionRequest(List<List<dynamic?>> data)
    {
        try
        {
            var requestBody = new AiRequestBody()
            {
                ModelName=modelName ,
                Data = data
            };
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(failurePredictionServiceUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AiResponseBody>(responseBody);

            if (!response.IsSuccessStatusCode || result?.Prediction is null)
                return null;
        
            return  result.Prediction!;
        }
        catch (Exception e)
        {
            return null;
        }
        

    }
}