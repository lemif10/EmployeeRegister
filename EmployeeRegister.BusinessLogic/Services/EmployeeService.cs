
using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Interfaces;
using EmployeeRegister.DAL.Repository;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository, IContactRepository contactRepository)
        {
            _employeeRepository = employeeRepository;
            _contactRepository = contactRepository;
        }
        
        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Create(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void Edit(Employee employee)
        {
            _employeeRepository.Edit(employee);
        }

        public void Delete(int id)
        {
            _contactRepository.Delete(id);
            _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}