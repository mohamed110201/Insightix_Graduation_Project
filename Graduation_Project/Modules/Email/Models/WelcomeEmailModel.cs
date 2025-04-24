namespace Graduation_Project.Modules.Email.Models;

public class WelcomeEmailModel : IBaseTemplateModel
{
    public string UserName { get; set; }
    public DateTime RegistrationDate { get; set; }
    
    public static string TemplateName()
    {
        return "WelcomeEmail";
    }
}