using System.Data.SqlTypes;
using System.Text;
using System.Text.Json;
using Graduation_Project.Data;
using Graduation_Project.Hubs.Notifications;
using Graduation_Project.Hubs.Notifications.NotificationDataDtos;
using Graduation_Project.Modules.Email;
using Graduation_Project.Repositories.Interfaces;

namespace Graduation_Project.Modules.FailuresPrediction;

public class FailuresPredictionManger(IServiceProvider serviceProvider,NotificationsNotifier notificationsNotifier,IConfiguration configuration)
{
    private HttpClient httpClient = new HttpClient();
    
    public async Task ExecuteProcedure()
    {
        using var scope = serviceProvider.CreateScope();
        var machinesRepository = scope.ServiceProvider.GetRequiredService<IMachinesRepository>();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var broadcastFailurePredictionEmailService = scope.ServiceProvider.GetRequiredService<BroadcastFailurePredictionEmailService>();
        await Work(machinesRepository, context,broadcastFailurePredictionEmailService);
    }
    private async Task Work(IMachinesRepository machinesRepository, AppDbContext context,BroadcastFailurePredictionEmailService broadcastFailurePredictionEmailService)
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
               var failurePrediction = await machinesRepository.AddPrediction(m.Id, now);
                
                _ = Task.Run(async () =>
                {
                    await broadcastFailurePredictionEmailService.Send(failurePrediction.Id, now, m.SerialNumber);
                    
                    await notificationsNotifier.SendNotificationsAsync(new NotificationDto()
                    {
                        Type = "failurePrediction",
                        Data = new NotificationFailurePredictionDataDto()
                        {
                            MachineId = m.Id,
                            FailurePrediction = failurePrediction.Id,
                            TimeStamp = now,
                        }
                    });
                });

            }
                
            await  machinesRepository.UpdatePredictionCheckPoint(m.Id, now);
        }
        
    }

    private async Task<bool?> SendFailurePredictionRequest(List<List<dynamic?>> data)
    {
        try
        {
            var failurePredictionServiceUrl = configuration.GetValue<string>("FailurePredictionServiceUrl");
            var wrapperMachineModelName = configuration.GetValue<string>("WrapperMachineModelName");

            if (failurePredictionServiceUrl==null||wrapperMachineModelName==null)
            {
                return null;
            }
            
            var requestBody = new AiRequestBody()
            {
                ModelName=wrapperMachineModelName ,
                Data = data
            };
            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{failurePredictionServiceUrl}/predict", content);
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