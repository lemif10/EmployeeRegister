using System.Collections.Generic;
using EmployeeRegister.BusinessLogic.Interface;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Repository;

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
        
        public void Create(DepartmentViewModel departmentViewModel)
        {
            _departmentRepository.Create(departmentViewModel);
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
        
        public IEnumerable<Department> Index()
        {
            return _departmentRepository.Index();
        }
    }
}