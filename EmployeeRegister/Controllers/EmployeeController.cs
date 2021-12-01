﻿using EmployeeRegister.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, ConnectionSettings connectionSettings)
        {
            _departmentService = new DepartmentService(connectionSettings);
            _employeeService = new EmployeeService(connectionSettings);
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
            return View(new CreateEmployeeView
            {
                Departments = _departmentService.Index()
            });
        }
        
        [HttpPost]
        public IActionResult Create(CreateEmployeeView createEmployeeView)
        {
            _employeeService.Create(createEmployeeView);
            
            return RedirectToAction(nameof(Index));
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