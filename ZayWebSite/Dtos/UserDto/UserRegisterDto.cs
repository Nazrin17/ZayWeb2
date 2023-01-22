using System.ComponentModel.DataAnnotations;

namespace ZayWebSite.Dtos.UserDto
{
    public class UserRegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string COnfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }



    }
}
