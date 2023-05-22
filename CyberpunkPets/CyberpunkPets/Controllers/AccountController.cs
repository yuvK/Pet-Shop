using CyberpunkPets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CyberpunkPets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login(LoginModel user)
        {
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> PostLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Animal");
                }
            }
            return View("Login", model);
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Animal");
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel user)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });//new role
            var newUser = new IdentityUser { UserName = user.Username }; //new identity
            var result = await _userManager.CreateAsync(newUser, user.Password!); //new user

            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    if (user.Username == "Admin")
                        await _userManager.AddToRoleAsync(newUser, "Admin");

                    return RedirectToAction("Login", user);
                }
                ViewBag.ErrorMsg = "wrong input!";
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
