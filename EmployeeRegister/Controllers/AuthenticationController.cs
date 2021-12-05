using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using EmployeeRegister.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeRegister.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
                MD5 md5 = MD5.Create();
                var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(userLoginViewModel.Password));
                
                foreach (User user in _userService.GetAll())
                {
                    if (user.Login == userLoginViewModel.Login && Convert.ToBase64String(hashPassword) == user.Password)
                    {
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
                foreach (User user in _userService.GetAll())
                {
                    if (user.Login == userViewModel.Login || user.Email == userViewModel.Email)
                    {
                        return View(userViewModel);
                    }
                }
                
                MD5 md5 = MD5.Create();
                var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(userViewModel.Password));
                
                _userService.Create(new User
                {
                    Email = userViewModel.Email,
                    Login = userViewModel.Login,
                    Password = Convert.ToBase64String(hashPassword),
                    Role = (int)userViewModel.Role
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