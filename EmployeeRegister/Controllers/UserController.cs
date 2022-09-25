using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using EmployeeRegister.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmployeeRegister.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        private readonly ILogger _logger;
        
        public UserController(IUserService userService, ILogger logger, IAuthService authService)
        {
            _userService = userService;
            _logger = logger;
            _authService = authService;
        }
        
        public IActionResult Index()
        {
            return View(_userService.GetAll());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel userViewModel)
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
                    Password = userViewModel.Password
                });
                
                return RedirectToAction(nameof(Index));
            }

            return View(userViewModel);
        }
        
        public IActionResult Edit(int id)
        {
            User user = _userService.Get(id);
            
            return View(new UserEditViewModel
            {
                Email = user.Email,
                Login = user.Login,
                Role = (Role)user.Role
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserEditViewModel userEditViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _userService.Edit(new User
                {
                    Id = id,
                    Email = userEditViewModel.Email,
                    Login = userEditViewModel.Login,
                    Role = (int)userEditViewModel.Role,
                });

                _logger.Information($"{User.Identity.Name}: edit user {_userService.Get(id).Email}");

                return RedirectToAction(nameof(Index));
            }

            return View(userEditViewModel);
        }
        
        public IActionResult Delete(int id)
        {
            _logger.Information($"{User.Identity.Name}: delete user {_userService.Get(id).Email}");
            
            _userService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}