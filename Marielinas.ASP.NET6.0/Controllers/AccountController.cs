using Marielinas.ASP.NET6._0.Models;
using Marielinas.ASP.NET6._0.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marielinas.ASP.NET6._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;

        public AccountController(SignInManager<StoreUser> SignInManager,UserManager<StoreUser> UserManager)
        {
            _signInManager = SignInManager;
            _userManager = UserManager;
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var result =await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RemeberMe, false);

                if (result.Succeeded) {

                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].FirstOrDefault());
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }

            ModelState.AddModelError("","Failed to log in");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel User)
        {
            StoreUser storeUser = await _userManager.FindByEmailAsync(User.UserName);

            if (storeUser != null)
            {
                ViewBag.SignedInUserMessage = "You already have a account with this Email";
                return View(User);
            }
            if (storeUser == null)
            {
                storeUser = new StoreUser() {
                    FirstName = User.FirstName,
                    LastName= User.LastName,
                    Email= User.Email,
                    UserName = User.UserName
                };

                var result = await _userManager.CreateAsync(storeUser, User.Password);
                if (result == IdentityResult.Success)
                {
                    var signinResult= await _signInManager.PasswordSignInAsync(storeUser, User.Password,User.RemeberMe,false);
                    if (signinResult.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            
            }

            return View(User);
        }
    }
}
