using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Repository;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class DepartmentService
    {
        private readonly DepartmentRepository  _departmentRepository;
        
        public DepartmentService(ConnectionSettings connectionSettings)
        {
            _departmentRepository = new DepartmentRepository(connectionSettings);
        }

        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }
        
        public void Create(DepartmentViewModel model)
        {
            _departmentRepository.Create(model);
        }

        public DepartmentViewModel Get(int id)
        {
            Department department = _departmentRepository.Get(id);

            return new DepartmentViewModel
            {
                Name = department.Name,
                Address = department.Address,
                Description = department.Description,
                PhoneNumber = department.PhoneNumber
            };
        }

        public void Edit(DepartmentViewModel departmentViewModel, int id)
        {
            _departmentRepository.Edit( new Department
            {
                Id = id,
                Address = departmentViewModel.Address,
                Description = departmentViewModel.Description,
                Name = departmentViewModel.Name,
                PhoneNumber = departmentViewModel.PhoneNumber
            });
        }
        
        public List<Department> Index()
        {
            return _departmentRepository.Index();
        }
    }
}