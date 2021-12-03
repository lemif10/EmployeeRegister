using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Services;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.BusinessLogic.Interface
{
    public interface IDepartmentService : IServiceData
    {
        IEnumerable<Department> Index();

        void Create(DepartmentViewModel departmentViewModel);

        DepartmentViewModel Get(int id);

        void Edit(DepartmentViewModel departmentViewModel, int id);
    }
}