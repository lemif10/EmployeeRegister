using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DAL.Repository
{
    public interface IContactRepository : IRepository
    {
        int SelectLastId();
        
        void Create(Contact contact);
        
        Contact Get(int id);

        void Edit(Contact contact, int id);
    }
}