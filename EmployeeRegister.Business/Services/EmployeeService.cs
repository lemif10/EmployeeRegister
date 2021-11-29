using System;
using System.Collections.Generic;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DataAccessLayer.Repository;

namespace EmployeeRegister.Business.Services
{
    public class EmployeeService : IExtendedServiceData
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly ContactRepository _contactRepository;
        
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _contactRepository = new ContactRepository();
        }
        
        public void Add()
        {
            throw new NotImplementedException();
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
            List<EmployeeViewModel> employeeViewModel= new List<EmployeeViewModel>();

            return _employeeRepository.Index<T>();
        }
    }
}