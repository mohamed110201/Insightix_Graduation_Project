using Graduation_Project.Modules.Authentication.DTOs;
using Graduation_Project.Modules.Authentication.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.Authentication
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController(UserManager<IdentityUser> userManager, IAuthService authService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            var token = authService.GenerateJwtToken(user.UserName);
            return Ok(new { token });
        }
        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            await authService.BlacklistTokenAsync(token); 

            return Ok(new { message = "Logged out successfully." });
        }
    }
}
