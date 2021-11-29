using System;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DataAccessLayer.Connection;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public class ContactRepository
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

        public Contact Index(int contactId)
        {
            using (var connection = new SqlConnection(ConnectionSettings.ConnectionString))
            {
                var query =
                    "SELECT Idi, PhoneNumber, Email FROM Employees JOIN Contacts ON @ContactId = Idi";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("ContactId", SqlDbType.Int)
                {
                    Value = contactId
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
                                Id = Convert.ToInt32(reader["Idi"]),
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