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
            return View(_employeeService.Index<EmployeeViewModel>());
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
        
        public IActionResult Details(int id)
        {
            return View(_employeeService.Get(id));
        }
        
        public IActionResult Edit()
        {
            return View();
        }
    }
    
}