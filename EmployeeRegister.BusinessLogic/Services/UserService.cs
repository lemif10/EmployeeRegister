using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        public void Delete(int id)
        { 
            _userRepository.Delete(id);
        }

        public void Edit(User user)
        {
            _userRepository.Edit(user);
        }

        public void Create(User user)
        {
            user.Password = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));
            
            _userRepository.Create(user);
        }
    }
}