using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.Email.Models;
using Graduation_Project.Modules.Email.Templates;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Modules.Email;

public class BroadcastFailurePredictionEmailService(
    UserManager<IdentityUser> userManager,
    EmailService emailService,
    IConfiguration config
    )
{
    public async Task Send(int failurePredictionId,DateTime timestamp,string machineSerialNumber)
    {
        try
        {
            var frontUrl = config.GetValue<string>("Front_Url");
            var users = await userManager.Users.ToListAsync();
            
            
            foreach (var user in users)
            {
                
                if (user.Email == null)
                {
                    continue;
                }
                
                await emailService.Send(user.Email, "Predicted Machine Failure – Take Preventive Action Now", new AlertEmailModel()
                {
                    UserName = user.UserName??"user",
                    AlertType = "Failure Prediction",
                    AlertMessage = "Our AI-based monitoring system has predicted a potential failure in one of your machines.",
                    AlertDetails = [
                        new ("Machine Serial Number",machineSerialNumber),
                        new ("Prediction Time",timestamp.ToString("g"))
                    ],
                    ActionUrl = $"{frontUrl}/failurePredictions/{failurePredictionId}"
                });
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}