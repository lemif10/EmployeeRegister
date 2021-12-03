using EmployeeRegister.BusinessLogic.Interface;
using EmployeeRegister.Common.Models;
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
        public IActionResult Create(DepartmentViewModel model)
        {
            _departmentService.Create(model);
            
            return RedirectToAction(nameof(Index));
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
        public IActionResult Edit(DepartmentViewModel departmentViewModel, int id)
        {
            _departmentService.Edit(departmentViewModel, id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}