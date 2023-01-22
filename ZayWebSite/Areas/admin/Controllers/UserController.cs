using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZayWebSite.Dtos.UserDto;
using ZayWebSite.Models;

namespace ZayWebSite.Areas.admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null) { return NotFound(); }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "ou already blocked for 5 minutes");
                    return View();
                }
                ModelState.AddModelError("", "Your password or username incorrect");
                return View();
            };
            var result1 = await _userManager.IsInRoleAsync(user, "Admin");
            if (!result1)
            {
                ModelState.AddModelError("", "Your password or username incorrect");
                return View();

            }

            return RedirectToAction("index", "category");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "user");

        }
    }
}
