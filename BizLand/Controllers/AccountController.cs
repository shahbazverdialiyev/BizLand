using BizLand.Models;
using BizLand.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            AppUser? user = await _userManager.FindByNameAsync(register.Username);
            if (user!=null)
            {
                ModelState.AddModelError("", "bele istifadechi var");
                return View(register);
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            user = new AppUser()
            {
                Name = register.Name,
                Surname = register.Surname,
                UserName = register.Username,
                Email = register.Email
            };
             IdentityResult identityResult= await _userManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if(login == null)
            {
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            AppUser? user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
