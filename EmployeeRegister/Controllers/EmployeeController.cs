using EmployeeRegister.BusinessLogic.Interface;
using EmployeeRegister.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Repository;

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
        public IActionResult Create(EmployeeViewModel createEmployeeView)
        {
            _employeeService.Create(createEmployeeView);
            
            return RedirectToAction(nameof(Index));
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
        public IActionResult Edit(EmployeeViewModel model, int id)
        {
            _employeeService.Edit(model, id);
            
            return RedirectToAction(nameof(Index));
        }
    }
    
}