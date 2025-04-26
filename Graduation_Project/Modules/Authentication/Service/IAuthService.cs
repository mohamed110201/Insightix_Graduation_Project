namespace Graduation_Project.Modules.Authentication.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
    }
}
