using Graduation_Project.Core.JSend;
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
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            var user = await userManager.FindByEmailAsync(loginUser.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginUser.Password))
            {
                return JSend.Unauthorized("Email Or Password Is Incorrect ");
            }

            var token = authService.GenerateJwtToken(user.UserName);

            var userInfo = new
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };
            return JSend.Success("Login Successfully", userInfo);
        }
        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            await authService.BlacklistTokenAsync(token); 

            return JSend.Success("Logged out successfully!");
        }
    }
}
