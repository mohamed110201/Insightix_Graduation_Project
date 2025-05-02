namespace Graduation_Project.Modules.Authentication.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
        Task BlacklistTokenAsync(string token);
        public Task<bool> IsTokenBlacklistedAsync(string token);


    }
}
