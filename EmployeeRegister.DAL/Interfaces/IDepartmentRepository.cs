using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        void Create(Department departmentViewModel);

        Department Get(int departmentId);

        IEnumerable<Department> GetAll();

        void Edit(Department department);
        
        void Delete(int id);
    }
}