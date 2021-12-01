using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;

namespace EmployeeRegister.DAL.Repository
{
    public class EmployeeRepository
    {
        private readonly ConnectionSettings _connectionSettings;
        private readonly ContactRepository _contactRepository;
        private readonly DepartmentRepository _departmentRepository;

        public EmployeeRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
            _contactRepository = new ContactRepository(_connectionSettings);
            _departmentRepository = new DepartmentRepository(_connectionSettings);
        }
        
        public void Create(Employee model)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO Employees (FullName, DepartmentId, Address, FamilyStatus, WorkExperience, Salary) VALUES (@FullName, @DepartmentId, @Address, @FamilyStatus, @WorkExperience, @Salary)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("FullName", SqlDbType.Text)
                {
                    Value = model.FullName
                });
                
                command.Parameters.Add(new SqlParameter("DepartmentId", SqlDbType.Int)
                {
                    Value = model.DepartmentId
                });
                
                command.Parameters.Add(new SqlParameter("Address", SqlDbType.Text)
                {
                    Value = model.Address
                });
                
                command.Parameters.Add(new SqlParameter("FamilyStatus", SqlDbType.Int)
                {
                    Value = model.FamilyStatus
                });
                
                command.Parameters.Add(new SqlParameter("WorkExperience", SqlDbType.Decimal)
                {
                    Value = model.WorkExperience
                });
                
                command.Parameters.Add(new SqlParameter("Salary", SqlDbType.Decimal)
                {
                    Value = model.Salary
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();
                
                command.Connection.Close();
            }
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
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
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
                                Contact = _contactRepository.GetContact(Convert.ToInt32(reader["Id"])),
                                Department = _departmentRepository.Get(Convert.ToInt32(reader["DepartmentId"]))
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

            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
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
                                Contact = _contactRepository.GetContact(Convert.ToInt32(reader["Id"])),
                                Department = _departmentRepository.Get(Convert.ToInt32(reader["DepartmentId"]))
                            });
                        }
                    }
                }
                
                return (List<T>)employees;
            }
        }
    }
}