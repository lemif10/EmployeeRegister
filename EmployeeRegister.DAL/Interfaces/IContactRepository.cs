using EmployeeRegister.Common.Models;

namespace EmployeeRegister.DAL.Interfaces
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        
        Contact Get(int id);

        void Edit(Contact contact);

        void Delete(int id);
    }
}