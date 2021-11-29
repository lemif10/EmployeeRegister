using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DataAccessLayer.Connection;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public class EmployeeRepository : IExtendedRepository
    {
        private ContactRepository _contactRepository;
        private DepartmentRepository _departmentRepository;
        
        public EmployeeRepository()
        {
            _contactRepository = new ContactRepository();
            _departmentRepository = new DepartmentRepository();
        }
        
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
            IList<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Id, FullName, ContactId, DepartmentId, Address, FamilyStatus, WorkExperience, Photo, Salary FROM Employees";

                var command = new SqlCommand(query, connection);

                command.Connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeViewModel()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                Address = reader["Address"].ToString(),
                                FamilyStatus = Convert.ToInt32(reader["FamilyStatus"]),
                                WorkExperience = Convert.ToDecimal(reader["WorkExperience"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                Contact = _contactRepository.Index(Convert.ToInt32(reader["ContactId"])),
                                Department = _departmentRepository.Index(Convert.ToInt32(reader["DepartmentId"]))
                            });
                        }
                    }
                }
                
                return (List<T>)employees;
            }
        }
    }
}