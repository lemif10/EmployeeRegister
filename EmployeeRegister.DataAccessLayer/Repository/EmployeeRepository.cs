using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Enums;
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

        public EmployeeViewModel Get(int id)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM Employees WHERE Id = @Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });
                
                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new EmployeeViewModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                Address = reader["Address"].ToString(),
                                FamilyStatus = ((FamilyStatus) Convert.ToInt32(reader["FamilyStatus"])).ToString(),
                                WorkExperience = Convert.ToDecimal(reader["WorkExperience"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                Contact = _contactRepository.Index(Convert.ToInt32(reader["ContactId"])),
                                Department = _departmentRepository.Index(Convert.ToInt32(reader["DepartmentId"]))
                            };
                        }
                    }
                }
            }

            return new EmployeeViewModel();
        }
        
        
        public List<T> Index<T>()
        {
            IList<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM Employees";

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
                                FamilyStatus = ((FamilyStatus)Convert.ToInt32(reader["FamilyStatus"])).ToString(),
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