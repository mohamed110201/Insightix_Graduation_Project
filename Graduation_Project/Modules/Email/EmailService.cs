using Graduation_Project.Modules.Email.Models;
using Resend;
using RazorLight;

namespace Graduation_Project.Modules.Email;

public class EmailService(IResend resend, RazorLightEngine razorEngine)
{
    private const string FromEmail = "Insightix <info@pulsonic.io>";
    
    public async Task Send<T>(string to, string subject,T model) where T: IBaseTemplateModel
    {

        try
        {
            var htmlContent = await razorEngine.CompileRenderAsync($"{T.TemplateName()}.cshtml", model);
            
            var message = new EmailMessage
            {
                From = FromEmail,
                Subject = subject,
                To = [to],
                HtmlBody = htmlContent
            };
            await resend.EmailSendAsync( message );
        }
        catch (Exception e)
        {
            // ignored
        }
    }
    
}