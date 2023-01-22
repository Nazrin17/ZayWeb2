using Microsoft.AspNetCore.Identity;

namespace ZayWebSite.Models
{
    public class AppUser:IdentityUser
    {
        public string FUllName { get; set; }
    }
}
