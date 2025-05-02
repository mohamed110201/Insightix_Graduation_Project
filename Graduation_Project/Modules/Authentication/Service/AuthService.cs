using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Graduation_Project.Modules.Authentication.Service
{
    public class AuthService(IConfiguration configuration, IMemoryCache cache) : IAuthService
    {
       

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(
                configuration.GetValue<int>("JwtSettings:ExpiryInHours", 12)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task BlacklistTokenAsync(string token)
        {
            var expiration = GetTokenExpiration(token);
            cache.Set(token, true, expiration);
            return Task.CompletedTask;
        }

        private TimeSpan GetTokenExpiration(string token)
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            var exp = jwtToken?.ValidTo;
            return exp.HasValue ? exp.Value - DateTime.UtcNow : TimeSpan.FromMinutes(60);
        }
        public Task<bool> IsTokenBlacklistedAsync(string token)
        {
            var isBlacklisted = cache.TryGetValue(token, out _);
            return Task.FromResult(isBlacklisted);
        }
    }
}
