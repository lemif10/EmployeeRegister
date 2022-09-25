using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeRegister.ViewModels;

namespace EmployeeRegister.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IContactService _contactService;

        public EmployeeController(IEmployeeService employeeService,
            IDepartmentService departmentService, IContactService contactService)
        {
            _departmentService = departmentService;
            _contactService = contactService;
            _employeeService = employeeService;
        }
        
        public IActionResult Create()
        {
            return View(new EmployeeViewModel
            {
                Departments = _departmentService.GetAll()
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Create(new Employee
                {
                    Address = employeeViewModel.Address,
                    DepartmentId = employeeViewModel.Department.Id,
                    FamilyStatus = (int)employeeViewModel.FamilyStatus,
                    FullName = employeeViewModel.FullName,
                    Salary = employeeViewModel.Salary,
                    WorkExperience = employeeViewModel.WorkExperience
                });
                
                _contactService.Create(new Contact
                {
                    PhoneNumber = employeeViewModel.ContactViewModel.PhoneNumber,
                    Email = employeeViewModel.ContactViewModel.Email
                });

                return RedirectToAction(nameof(Index));
            }

            try
            {
                employeeViewModel.Departments = _departmentService.GetAll();
                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }
        
        public IActionResult Details(int id)
        {
            Employee employee = _employeeService.Get(id);
            Contact contact = _contactService.Get(id);
            ContactViewModel contactViewModel = new ContactViewModel
            {
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email
            };
            
            return View(new EmployeeViewModel
            {
                FullName = employee.FullName,
                Address = employee.Address,
                ContactViewModel = contactViewModel,
                Department = _departmentService.Get(employee.DepartmentId),
                FamilyStatus = (FamilyStatus)employee.FamilyStatus,
                Salary = employee.Salary,
                WorkExperience = employee.WorkExperience
            });
        }
        
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in _employeeService.GetAll())
            {
                Contact contact = _contactService.Get(employee.Id);
                ContactViewModel contactViewModel = new ContactViewModel
                {
                    PhoneNumber = contact.PhoneNumber,
                    Email = contact.Email
                };
                
                employeeViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Address = employee.Address,
                    ContactViewModel = contactViewModel,
                    Department = _departmentService.Get(employee.DepartmentId),
                    FamilyStatus = (FamilyStatus)employee.FamilyStatus,
                    Salary = employee.Salary,
                    WorkExperience = employee.WorkExperience
                });
            }

            return PartialView(employeeViewModels);
        }
        
        [HttpPost]
        public IActionResult Index(string filter)
        {
            ViewBag.filter = filter;

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            
            foreach (Employee employee in _employeeService.GetAll())
            {
                Contact contact = _contactService.Get(employee.Id);
                ContactViewModel contactViewModel = new ContactViewModel
                {
                    PhoneNumber = contact.PhoneNumber,
                    Email = contact.Email
                };
                
                employeeViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Address = employee.Address,
                    ContactViewModel = contactViewModel,
                    Department = _departmentService.Get(employee.DepartmentId),
                    FamilyStatus = (FamilyStatus)employee.FamilyStatus,
                    Salary = employee.Salary,
                    WorkExperience = employee.WorkExperience
                });
            }

            return PartialView(filter == null ? employeeViewModels : employeeViewModels.Where(x => x.FullName.ToLower().Contains(filter.ToLower())));
        }

        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            _employeeService.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeService.Get(id);
            Contact contact = _contactService.Get(id);
            ContactViewModel contactViewModel = new ContactViewModel
            {
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email
            };
            
            return View(new EmployeeViewModel
            {
                FullName = employee.FullName,
                Address = employee.Address,
                ContactViewModel = contactViewModel,
                Department = _departmentService.Get(employee.DepartmentId),
                FamilyStatus = (FamilyStatus)employee.FamilyStatus,
                Salary = employee.Salary,
                WorkExperience = employee.WorkExperience,
                Departments = _departmentService.GetAll()
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Edit(new Employee
                    {
                        Id = employeeViewModel.Id,
                        Address = employeeViewModel.Address,
                        DepartmentId = employeeViewModel.Department.Id,
                        FamilyStatus = (int)employeeViewModel.FamilyStatus,
                        FullName = employeeViewModel.FullName,
                        Salary = employeeViewModel.Salary,
                        WorkExperience = employeeViewModel.WorkExperience
                    });

                    _contactService.Edit(new Contact
                    {
                        Id = employeeViewModel.Id,
                        Email = employeeViewModel.ContactViewModel.Email,
                        PhoneNumber = employeeViewModel.ContactViewModel.PhoneNumber
                    });

                    return RedirectToAction(nameof(Index));
                }

                employeeViewModel.Departments = _departmentService.GetAll();
                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }
    }
    
}