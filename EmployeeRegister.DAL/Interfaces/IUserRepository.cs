using System.Collections;
using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        
        User Get(string login);
        
        void Delete(int id);

        void Edit(User user);

        void Create(User user);
    }
}