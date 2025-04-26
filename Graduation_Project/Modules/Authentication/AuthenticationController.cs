using Graduation_Project.Modules.Authentication.DTOs;
using Graduation_Project.Modules.Authentication.Service;
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
    }
}
