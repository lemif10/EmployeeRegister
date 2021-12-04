using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
       private readonly ConnectionSettings _connectionSettings;

        public UserRepository(ConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
        }
        
        public void Create(User user)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO AppUsers (Email, Login, Password, Role) VALUES (@Email, @Login, @Password, @Role)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = user.Email
                });
                
                command.Parameters.Add(new SqlParameter("Login", SqlDbType.Text)
                {
                    Value = user.Login
                });
                
                command.Parameters.Add(new SqlParameter("Password", SqlDbType.Text)
                {
                    Value = user.Password
                });
                
                command.Parameters.Add(new SqlParameter("Role", SqlDbType.Int)
                {
                    Value = user.Role
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void Edit(User user)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "UPDATE AppUsers SET Email=@Email, Login=@Login, Password=@Password, Role=@Role WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = user.Id
                });

                command.Parameters.Add(new SqlParameter("Email", SqlDbType.Text)
                {
                    Value = user.Email
                });
                
                command.Parameters.Add(new SqlParameter("Login", SqlDbType.Text)
                {
                    Value = user.Login
                });

                command.Parameters.Add(new SqlParameter("Password", SqlDbType.Text)
                {
                    Value = user.Password
                });
                
                command.Parameters.Add(new SqlParameter("Role", SqlDbType.Int)
                {
                    Value = user.Role
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
                    "DELETE FROM AppUsers WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = id
                });

                command.Connection.Open();

                command.ExecuteNonQuery();
            }
        }
        
        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM AppUsers";

                var command = new SqlCommand(query, connection);
                
                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new User 
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Email = reader["Email"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = Convert.ToInt32(reader["Role"])
                            });
                        }
                    }
                }

                return users;
            }
        }
        
        
        public User Get(string login)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM AppUsers WHERE Login = @Login";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Login", SqlDbType.Text)
                {
                    Value = login
                });

                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Email = reader["Email"].ToString(),
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = Convert.ToInt32(reader["Role"])
                            };
                        }
                    }
                }

                return new User();
            }
        }
    }
}