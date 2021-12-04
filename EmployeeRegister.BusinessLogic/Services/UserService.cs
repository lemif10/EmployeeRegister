using System.Collections.Generic;
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

        public User Get(string login)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }
    }
}