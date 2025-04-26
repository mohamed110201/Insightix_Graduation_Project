using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.Modules.Authentication.DTOs
{
    public class LoginUserDto
    {
       
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
