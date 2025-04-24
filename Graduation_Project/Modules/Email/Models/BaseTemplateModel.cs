namespace Graduation_Project.Modules.Email.Models;

public interface IBaseTemplateModel
{
    static virtual string TemplateName()
    {
        return "";
    }
}