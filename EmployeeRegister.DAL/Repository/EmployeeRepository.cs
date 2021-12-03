using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Enums;
using EmployeeRegister.Common.Models;
using EmployeeRegister.Common.ViewModels;
using EmployeeRegister.DAL.Connection;

namespace EmployeeRegister.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionSettings _connectionSettings;
        private readonly IContactRepository _contactRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeRepository(ConnectionSettings connectionSettings,
            IContactRepository contactRepository, IDepartmentRepository departmentRepository)
        {
            _connectionSettings = connectionSettings;
            _contactRepository = contactRepository;
            _departmentRepository = departmentRepository;
        }
        
        public IEnumerable<EmployeeViewModel> Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

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
                                FamilyStatus = (FamilyStatus)Convert.ToInt32(reader["FamilyStatus"]),
                                WorkExperience = Convert.ToDecimal(reader["WorkExperience"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                Contact = _contactRepository.Get(Convert.ToInt32(reader["Id"])),
                                Department = _departmentRepository.Get(Convert.ToInt32(reader["DepartmentId"]))
                            });
                        }
                    }
                }
                
                return employees;
            }
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
                                FamilyStatus = (FamilyStatus)Convert.ToInt32(reader["FamilyStatus"]),
                                WorkExperience = Convert.ToDecimal(reader["WorkExperience"]),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                Contact = _contactRepository.Get(Convert.ToInt32(reader["Id"])),
                                Department = _departmentRepository.Get(Convert.ToInt32(reader["DepartmentId"]))
                            };
                        }
                    }
                }
            }

            return new EmployeeViewModel();
        }
        
        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO Employees (FullName, DepartmentId, Address, FamilyStatus, WorkExperience, Salary) VALUES (@FullName, @DepartmentId, @Address, @FamilyStatus, @WorkExperience, @Salary)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("FullName", SqlDbType.Text)
                {
                    Value = employee.FullName
                });
                
                command.Parameters.Add(new SqlParameter("DepartmentId", SqlDbType.Int)
                {
                    Value = employee.DepartmentId
                });
                
                command.Parameters.Add(new SqlParameter("Address", SqlDbType.Text)
                {
                    Value = employee.Address
                });
                
                command.Parameters.Add(new SqlParameter("FamilyStatus", SqlDbType.Int)
                {
                    Value = employee.FamilyStatus
                });
                
                command.Parameters.Add(new SqlParameter("WorkExperience", SqlDbType.Decimal)
                {
                    Value = employee.WorkExperience
                });
                
                command.Parameters.Add(new SqlParameter("Salary", SqlDbType.Decimal)
                {
                    Value = employee.Salary
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();
                
                command.Connection.Close();
            }
        }

        public void Edit(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "UPDATE Employees SET FullName=@FullName, DepartmentId=@DepartmentId, Address=@Address, FamilyStatus=@FamilyStatus, WorkExperience=@WorkExperience, Salary=@Salary WHERE Id = @Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = employee.Id
                });
                
                command.Parameters.Add(new SqlParameter("FullName", SqlDbType.Text)
                {
                    Value = employee.FullName
                });
                
                command.Parameters.Add(new SqlParameter("DepartmentId", SqlDbType.Int)
                {
                    Value = employee.DepartmentId
                });
                
                command.Parameters.Add(new SqlParameter("Address", SqlDbType.Text)
                {
                    Value = employee.Address
                });
                
                command.Parameters.Add(new SqlParameter("FamilyStatus", SqlDbType.Int)
                {
                    Value = employee.FamilyStatus
                });
                
                command.Parameters.Add(new SqlParameter("WorkExperience", SqlDbType.Decimal)
                {
                    Value = employee.WorkExperience
                });
                
                command.Parameters.Add(new SqlParameter("Salary", SqlDbType.Decimal)
                {
                    Value = employee.Salary
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();
                
                command.Connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "DELETE FROM Employees WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }
    }
}