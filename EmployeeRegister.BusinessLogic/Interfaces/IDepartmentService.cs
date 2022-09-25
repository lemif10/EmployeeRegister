using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.BusinessLogic.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();

        void Create(Department departmentViewModel);

        Department Get(int id);

        void Edit(Department departmentViewModel);
        
        void Delete(int id);
    }
}