using System;
using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DataAccessLayer.Repository;

namespace EmployeeRegister.Business.Services
{
    public class EmployeeService : IExtendedServiceData
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        
        public void Add()
        {
            throw new NotImplementedException();
        }

        public EmployeeViewModel Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<T> Index<T>()
        {
            return _employeeRepository.Index<T>();
        }
    }
}