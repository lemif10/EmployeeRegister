using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository  _departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }
        
        public void Create(Department department)
        {
            _departmentRepository.Create(department);
        }

        public Department Get(int id)
        {
            return _departmentRepository.Get(id);
        }

        public void Edit(Department department)
        {
            _departmentRepository.Edit(department);
        }
        
        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
    }
}