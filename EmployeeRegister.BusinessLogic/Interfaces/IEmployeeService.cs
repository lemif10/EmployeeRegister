using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Services;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        public Employee Get(int id);
        
        public void Edit(Employee employee);

        public IEnumerable<Employee> GetAll();

        public void Create(Employee employee);
        
        void Delete(int id);
    }
}