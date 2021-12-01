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
        
        public List<Department> Index()
        {
            return _departmentRepository.Index();
        }
    }
}