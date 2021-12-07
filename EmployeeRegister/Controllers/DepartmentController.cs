using System;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeRegister.Controllers
{
    [Authorize(Roles = "Admin, Editor")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        
        public DepartmentController(ILogger<EmployeeController> logger, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_departmentService.GetAll());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Create(new Department
                {
                    Name = departmentViewModel.Name,
                    Address = departmentViewModel.Address,
                    PhoneNumber = departmentViewModel.PhoneNumber,
                    Description = departmentViewModel.Description
                });
            
                return RedirectToAction(nameof(Index));
            }

            try
            {
                return View(departmentViewModel);
            }
            catch
            {
                return View();
            }
        }
        
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int id)
        {
            Department department = _departmentService.Get(id);
            
            return View(new DepartmentViewModel
            {
                Name = department.Name,
                Address = department.Address,
                Description = department.Description,
                PhoneNumber = department.PhoneNumber
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel departmentViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Edit(new Department
                {
                    Id = id,
                    Name = departmentViewModel.Name,
                    PhoneNumber = departmentViewModel.PhoneNumber,
                    Address = departmentViewModel.Address,
                    Description = departmentViewModel.Description
                });
                
                return RedirectToAction(nameof(Index));
            }

            try
            {
                return View(departmentViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
}