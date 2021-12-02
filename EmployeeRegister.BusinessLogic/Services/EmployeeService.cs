using System;
using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Repository;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class EmployeeService
    {
        private readonly ContactRepository _contactRepository;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(ConnectionSettings connectionSettings)
        {
            _contactRepository = new ContactRepository(connectionSettings);
            _employeeRepository = new EmployeeRepository(connectionSettings);
        }
        
        public EmployeeViewModel Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Create(EmployeeViewModel employeeViewModel)
        {
            _employeeRepository.Create(new Employee
           {
               FullName = employeeViewModel.FullName,
               Address = employeeViewModel.Address,
               DepartmentId = employeeViewModel.Department.Id,
               FamilyStatus = (int)employeeViewModel.FamilyStatus,
               Salary = employeeViewModel.Salary,
               WorkExperience = employeeViewModel.WorkExperience
           });
            
            _contactRepository.Create(employeeViewModel.Contact);
        }

        public void Edit(EmployeeViewModel employeeViewModel, int id)
        {
            _employeeRepository.Edit(new Employee
            {
                Id = employeeViewModel.Id,
                FullName = employeeViewModel.FullName,
                Address = employeeViewModel.Address,
                DepartmentId = employeeViewModel.Department.Id,
                FamilyStatus = (int)employeeViewModel.FamilyStatus,
                Salary = employeeViewModel.Salary,
                WorkExperience = employeeViewModel.WorkExperience
            });
            
            _contactRepository.Edit(employeeViewModel.Contact, id);
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
            _employeeRepository.Delete(id);
        }

        public List<T> Index<T>()
        {
            return _employeeRepository.Index<T>();
        }
    }
}