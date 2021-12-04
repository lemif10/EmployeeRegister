using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        
        User Get(string login);
        
        void Delete(int id);

        void Edit(User user);

        void Create(User user);
    }
}