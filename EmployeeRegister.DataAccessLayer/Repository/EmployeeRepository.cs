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
            IList<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Id, FullName, DepartmentId, ContactId, Address, FamilyStatus, WorkExperience, Photo, Salary FROM Employees";

                var command = new SqlCommand(query, connection);

                command.Connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                ContactId = Convert.ToInt32(reader["ContactId"]),
                                Address = reader["Address"].ToString(),
                                FamilyStatus = Convert.ToInt32(reader["FamilyStatus"]),
                                WorkExperience = Convert.ToDecimal(reader["WorkExperience"]),
                                Salary = Convert.ToDecimal(reader["Salary"])
                            });
                        }
                    }
                }
                
                return (List<T>)employees;
            }
        }
    }
}