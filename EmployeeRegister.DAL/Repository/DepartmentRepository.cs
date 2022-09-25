using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.DAL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ConnectionSettings _connectionSettings;

        public DepartmentRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        
        public void Create(Department department)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO Departments (Name, PhoneNumber, AddressD, Description) VALUES (@Name, @PhoneNumber, @AddressD, @Description)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Name", department.Name);

                command.Parameters.AddWithValue("PhoneNumber", department.PhoneNumber);

                command.Parameters.AddWithValue("AddressD", department.Address);

                command.Parameters.AddWithValue("Description", department.Description);

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Department department)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "UPDATE Departments SET Name=@Name, PhoneNumber=@PhoneNumber, AddressD=@Address, Description=@Description WHERE Idn=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = department.Id
                });

                command.Parameters.AddWithValue("Name", department.Name);

                command.Parameters.AddWithValue("PhoneNumber", department.PhoneNumber);

                command.Parameters.AddWithValue("Address", department.Address);

                command.Parameters.AddWithValue("Description", department.Description);

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "DELETE FROM Departments WHERE Idn=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM Departments";

                var command = new SqlCommand(query, connection);
                
                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                             departments.Add(new Department 
                            {
                                Id = Convert.ToInt32(reader["Idn"]),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Name = reader["Name"].ToString(),
                                Address = reader["AddressD"].ToString(),
                                Description = reader["Description"].ToString()
                            });
                        }
                    }
                }

                return departments;
            }
        }
        
        public Department Get(int departmentId)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Idn, PhoneNumber, AddressD, Description, Name FROM Employees JOIN Departments ON @DepartmentId = Idn";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("DepartmentId", SqlDbType.Int)
                {
                    Value = departmentId
                });

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new Department
                            {
                                Id = Convert.ToInt32(reader["Idn"]),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Name = reader["Name"].ToString(),
                                Address = reader["AddressD"].ToString(),
                                Description = reader["Description"].ToString()
                            };
                        }
                    }
                }

                return new Department();
            }
        }
    }
}