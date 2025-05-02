using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.Email.Models;
using Graduation_Project.Modules.Email.Templates;
using Microsoft.AspNetCore.Identity;

namespace Graduation_Project.Modules.Email;

public class BroadcastAlertEmailService(
    UserManager<IdentityUser> userManager,
    EmailService emailService,
    IAlertsService alertsService,
    IConfiguration config
    )
{
    public async Task Send(int alertId)
    {
        try
        {
            var frontUrl = config.GetValue<string>("FrontUrl");
            var alert = await alertsService.GetById(alertId);
            var users = await userManager.Users.ToListAsync();

            if (alert==null)
            {
                return;
            }
            
            foreach (var user in users)
            {
                if (user.Email == null)
                {
                    continue;
                }
                
                await emailService.Send(user.Email, "Machine Alert Triggered – Immediate Attention Required", new AlertEmailModel()
                {
                    UserName = user.UserName??"user",
                    AlertType = "Alert",
                    AlertMessage = "An alert has been triggered in your monitoring system",
                    AlertDetails = [
                        new ("Machine Serial Number",alert.MachineSerialNumber),
                        new ("Attribute Type",alert.Type),
                        new ($"{alert.Type} Attribute",alert.Attribute),
                        new ("Alert Severity",alert.Severity),
                        new ("Alert Time",alert.TimeStamp.ToString("g"))
                    ],
                    ActionUrl = $"{frontUrl}/alerts/{alertId}"
                });
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}