namespace Graduation_Project.Modules.Email.Models;

public class AlertEmailModel: IBaseTemplateModel
{
    public required string UserName { get; set; }
    public required string AlertType { get; set; }
    public required string AlertMessage { get; set; }
    public string? ActionUrl { get; set; }

    public List<KeyValuePair<string, string>> AlertDetails { get; set; } = [];


    public static string TemplateName()
    {
        return "AlertEmail";
    }
}
