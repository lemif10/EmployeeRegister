using EmployeeRegister.Common.Models;

namespace EmployeeRegister.BusinessLogic.Interfaces
{
    public interface IContactService
    {
        void Create(Contact contact);
        
        Contact Get(int id);

        void Edit(Contact contact);
        
        void Delete(int id);
    }
}