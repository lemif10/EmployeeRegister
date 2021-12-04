using System;
using System.Security.Cryptography;
using System.Text;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
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
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(UserLoginViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                MD5 md5 = MD5.Create();
                var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(userViewModel.Password));
                
                foreach (User user in _userService.GetAll())
                {
                    if (user.Login == userViewModel.Login && Convert.ToBase64String(hashPassword) == user.Password)
                    {
                        return RedirectToAction("HomePage","Home");
                    }
                }
                
                return View(userViewModel);
            }

            return View(userViewModel);
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
    }
}