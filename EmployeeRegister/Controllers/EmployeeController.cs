using System;
using EmployeeRegister.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeRegister.Common.ViewModels;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger,
            IEmployeeService employeeService, IDepartmentService departmentService )
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
            _logger = logger;
        }
        
        public IActionResult Create()
        {
            return View(new EmployeeViewModel
            {
                Departments = _departmentService.Index()
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Create(employeeViewModel);
                
                return RedirectToAction(nameof(Index));
            }

            try
            {
                employeeViewModel.Departments = _departmentService.Index();
                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }
        
        public IActionResult Details(int id)
        {
            return View(_employeeService.Get(id));
        }
        
        public IActionResult Index()
        {
            return View(_employeeService.Index());
        }
        
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int id)
        {
            EmployeeViewModel employeeViewModel = _employeeService.Get(id);
            employeeViewModel.Departments = _departmentService.Index();
            
            return View(employeeViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Edit(employeeViewModel, id);
                return RedirectToAction(nameof(Index));
            }

            try
            {
                employeeViewModel.Departments = _departmentService.Index();
                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
    
}