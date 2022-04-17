using BaseIdentityProject.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Observer.Models;
using WebApp.Observer.Subject;

namespace BaseProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IUserObserverSubject _userObserverSubject;

        public AccountController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IUserObserverSubject userObserverSubject)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userObserverSubject = userObserverSubject;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser == null) return View();

            var signInResult = await _signInManager.PasswordSignInAsync(appUser, password, isPersistent: false, lockoutOnFailure: false);
            if (!signInResult.Succeeded) return View();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid) return View();

            var appUser = new AppUser
            {
                UserName = createUserViewModel.Email,
                Email = createUserViewModel.Email
            };

            var result = await _userManager.CreateAsync(appUser, createUserViewModel.Password);
            if (result.Succeeded)
            {
                ViewBag.message = "User created successfully";
                _userObserverSubject.NotifyObservers(appUser);
            }
            else
            {
                ViewBag.message = "User creation failed";
            }

            await _signInManager.SignInAsync(appUser, isPersistent: false);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
