using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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