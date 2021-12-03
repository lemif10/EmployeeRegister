using System;
using EmployeeRegister.BusinessLogic.Interface;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeRegister.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        private readonly ILogger<EmployeeController> _logger;

        public DepartmentController(ILogger<EmployeeController> logger, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_departmentService.Index());
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
                _departmentService.Create(departmentViewModel);
            
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
            return View(_departmentService.Get(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentViewModel departmentViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Edit(departmentViewModel, id);
                
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