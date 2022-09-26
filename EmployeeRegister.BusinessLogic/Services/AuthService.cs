using System;
using System.Security.Cryptography;
using System.Text;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Interfaces;
using Serilog;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger _logger;

        public AuthService(IUserRepository userRepository, ILogger logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public bool IsLogin(string login, string password, out int id)
        {
            id = _userRepository.GetUserIdByAuth(login,
                Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password))));

            if (id > -1)
            {
                return true;
            }
            
            return false;
        }

        public bool IsRegistration(string login, string email)
        {
            foreach (User user in _userRepository.GetAll())
            {
                if (user.Email == email || user.Login == login)
                {
                    _logger.Warning($"trying to registry new account with old login or email: {user.Login}, {user.Email}");
                    
                    return true;
                }
            }

            return false;
        }
    }
}