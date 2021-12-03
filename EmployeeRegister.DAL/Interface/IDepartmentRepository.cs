using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;

namespace EmployeeRegister.DAL.Repository
{
    public interface IDepartmentRepository : IRepository
    {
        void Create(DepartmentViewModel departmentViewModel);

        Department Get(int departmentId);

        IEnumerable<Department> Index();

        void Edit(Department department);
    }
}