using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        
        Employee Get(int id);
        
        void Create(Employee employee);
        
        void Edit(Employee employee);
        
        void Delete(int id);
    }
}