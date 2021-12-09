using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using EmployeeRegister.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegister.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthenticationController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("HomePage", "Home");
            }
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.IsLogin(userLoginViewModel.Login, userLoginViewModel.Password, out int id))
                {
                    User user = _userService.Get(id);
                    
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, ((Role)user.Role).ToString())
                    };

                    var claimIdentity =
                        new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                        
                    return RedirectToAction("HomePage","Home");
                }
            }

            return View(userLoginViewModel);
        }
        
        public IActionResult Registration()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Registration(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.IsRegistration(userViewModel.Login, userViewModel.Email))
                {
                    return View(userViewModel);
                }
                
                _userService.Create(new User
                {
                    Email = userViewModel.Email,
                    Login = userViewModel.Login,
                    Password = userViewModel.Password,
                    Role = 0
                });
                
                return RedirectToAction(nameof(Login));
            }

            return View(userViewModel);
        }
        
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("HomePage", "Home");
        }
    }
}