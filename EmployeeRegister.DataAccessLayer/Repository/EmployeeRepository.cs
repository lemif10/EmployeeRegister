using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public class EmployeeRepository : IExtendedRepository
    {
        public void Create<T>(T model)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> Index<T>()
        {
            throw new NotImplementedException();
        }
    }
}