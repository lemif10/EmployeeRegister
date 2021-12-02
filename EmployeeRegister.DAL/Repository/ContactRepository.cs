using System;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;

namespace EmployeeRegister.DAL.Repository
{
    public class ContactRepository
    {
        private readonly ConnectionSettings _connectionSettings;
        
        public ContactRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        
        public int SelectLastId()
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Id FROM Employees WHERE Id=(SELECT max(Id) FROM Employees)";

                var command = new SqlCommand(query, connection);
                
                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return Convert.ToInt32(reader["Id"]);
                        }
                    }
                }

                return -1;
            }
        }
        
        public void Create(Contact model)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO Contacts (EmployeeId, PhoneNumber, Email) VALUES (@EmployeeId, @PhoneNumber, @Email)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = SelectLastId()
                });
                
                command.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.Text)
                {
                    Value = model.PhoneNumber
                });
                
                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = model.Email
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
                
                command.Connection.Close();
            }
        }

        public void Edit(Contact model, int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "UPDATE Contacts SET PhoneNumber=@PhoneNumber, Email=@Email WHERE EmployeeId = @EmployeeId";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = id
                });

                command.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.Text)
                {
                    Value = model.PhoneNumber
                });

                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = model.Email
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
                    "DELETE FROM Contacts WHERE EmployeeId=@EmployeeId";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("EmployeeId", SqlDbType.Int)
                {
                    Value = id
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        public Contact Get(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Idn, PhoneNumber, Email FROM Employees JOIN Contacts ON @Id = EmployeeId";

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
                            return new Contact
                            {
                                Id = Convert.ToInt32(reader["Idn"]),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                            };
                        }
                    }
                }

                return new Contact();
            }
        }
    }
}