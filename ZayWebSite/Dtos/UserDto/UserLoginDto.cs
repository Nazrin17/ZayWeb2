using Microsoft.Build.Framework;

namespace ZayWebSite.Dtos.UserDto
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
