using System;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ConnectionSettings _connectionSettings;
        
        public ContactRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        
        public void Create(Contact contact)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO Contacts (PhoneNumber, Email) VALUES (@PhoneNumber, @Email)";

                var command = new SqlCommand(query, connection);
                
                command.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.Text)
                {
                    Value = contact.PhoneNumber
                });
                
                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = contact.Email
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(Contact contact)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "UPDATE Contacts SET PhoneNumber=@PhoneNumber, Email=@Email WHERE Idn = @Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = contact.Id
                });

                command.Parameters.Add(new SqlParameter("PhoneNumber", SqlDbType.Text)
                {
                    Value = contact.PhoneNumber
                });

                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = contact.Email
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
        
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "DELETE FROM Contacts WHERE Idn=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });
                
                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public Contact Get(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Idn, PhoneNumber, Email FROM Employees JOIN Contacts ON @Id = Id";

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