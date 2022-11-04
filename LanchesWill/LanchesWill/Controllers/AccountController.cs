using LanchesWill.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesWill.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManger, SignInManager<IdentityUser> singInManager)
        {
            _userManger = userManger;
            _singInManager = singInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManger.FindByNameAsync(loginVM.UserName);

            if  (user != null)
            {
                var result = await _singInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(loginVM.ReturnUrl);
                    }
                }
            }
            ModelState.AddModelError("", "Falha ao realizar o login");
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registerVM)
        {   
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = registerVM.UserName };
                var result = await _userManger.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await _userManger.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }   
                else
                {
                    this.ModelState.AddModelError("Registro", "Fala ao registrar Usuário");
                }
            }
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        } 
    } 
}
