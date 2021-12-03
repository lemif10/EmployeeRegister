using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Services;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;

namespace EmployeeRegister.BusinessLogic.Interface
{
    public interface IEmployeeService : IServiceData
    {
        public EmployeeViewModel Get(int id);
        
        public void Edit(EmployeeViewModel employeeViewModel, int id);

        public IEnumerable<EmployeeViewModel> Index();

        public void Create(EmployeeViewModel employeeViewModel);
    }
}