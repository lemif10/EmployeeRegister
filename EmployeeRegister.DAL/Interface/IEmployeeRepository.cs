using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;

namespace EmployeeRegister.DAL.Repository
{
    public interface IEmployeeRepository : IRepository
    {
        IEnumerable<EmployeeViewModel> Index();
        
        EmployeeViewModel Get(int id);
        
        void Create(Employee employee);
        void Edit(Employee employee);
    }
}