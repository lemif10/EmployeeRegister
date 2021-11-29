using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DataAccessLayer.Connection;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public class DepartmentRepository
    {
        public void Create<T>(T model)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Department Index(int departmentId)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Idi, PhoneNumber, AddressD, Description, Name FROM Employees JOIN Departments ON @DepartmentId = Idi";

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
                                Id = Convert.ToInt32(reader["Idi"]),
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