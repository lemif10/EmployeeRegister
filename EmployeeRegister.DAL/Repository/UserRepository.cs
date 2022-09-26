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

        public int GetUserIdByAuth(string login, string password)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM AppUsers WHERE Login=@Login and Password=@Password";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Login", SqlDbType.NVarChar)
                {
                    Value = login
                });

                command.Parameters.Add(new SqlParameter("Password", SqlDbType.NVarChar)
                {
                    Value = password
                });

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

        public void Create(User user)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query = 
                    "INSERT INTO AppUsers (Email, Login, Password, Role) VALUES (@Email, @Login, @Password, @Role)";

                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Email", user.Email);

                command.Parameters.AddWithValue("Login", user.Login);
                
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
                    "UPDATE AppUsers SET Email=@Email, Login=@Login, Role=@Role WHERE Id=@Id";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add(new SqlParameter("Id", SqlDbType.Int)
                {
                    Value = user.Id
                });

                command.Parameters.AddWithValue("Email", user.Email);

                command.Parameters.AddWithValue("Login", user.Login);

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
        
        public User Get(int id)
        {
            using (var connection = new SqlConnection(_connectionSettings.ConnectionString))
            {
                var query =
                    "SELECT * FROM AppUsers WHERE Id = @Id";

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