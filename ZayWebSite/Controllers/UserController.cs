using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;
using ZayWebSite.Dtos.UserDto;
using ZayWebSite.Models;

namespace ZayWebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task<IActionResult> Index()
        //{
        //  //await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //  //await  _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //    return Json("ok");
        //}
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            AppUser appUser = new AppUser
            {
                FUllName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
            };
          IdentityResult result=  await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            };
           await _userManager.AddToRoleAsync(appUser, "User");
            return RedirectToAction("index","home");

        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            AppUser user= await _userManager.FindByNameAsync(loginDto.UserName);
            if(user == null) { return NotFound(); }
            Microsoft.AspNetCore.Identity.SignInResult result =  await _signInManager.PasswordSignInAsync(user, loginDto.Password,true,true);
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
            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");

        }
    }
}
