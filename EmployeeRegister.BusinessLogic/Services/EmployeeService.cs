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
        
        public void Add()
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Create(CreateEmployeeView createEmployeeView)
        {
            _employeeRepository.Create(new Employee
           {
               FullName = createEmployeeView.FullName,
               Address = createEmployeeView.Address,
               DepartmentId = createEmployeeView.Department.Id,
               FamilyStatus = (int)createEmployeeView.FamilyStatus,
               Salary = createEmployeeView.Salary,
               WorkExperience = createEmployeeView.WorkExperience
           });
            
            _contactRepository.Create(createEmployeeView.Contact);
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<T> Index<T>()
        {
            return _employeeRepository.Index<T>();
        }
    }
}