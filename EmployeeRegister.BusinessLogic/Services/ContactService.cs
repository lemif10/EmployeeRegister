using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.Common.Models;
using EmployeeRegister.DAL.Interfaces;

namespace EmployeeRegister.BusinessLogic.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public void Delete(int id)
        {
            _contactRepository.Delete(id);
        }

        public void Create(Contact contact)
        {
            _contactRepository.Create(contact);
        }

        public Contact Get(int id)
        {
            return _contactRepository.Get(id);
        }

        public void Edit(Contact contact)
        { 
            _contactRepository.Edit(contact);
        }
    }
}