using EmployeeRegister.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _employeeService = new EmployeeService();
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View(_employeeService.Index<Employee>());
        }
        
        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }
        
        public IActionResult Edit()
        {
            return View();
        }
    }
    
}