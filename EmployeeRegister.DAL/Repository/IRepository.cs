using System.Collections.Generic;

namespace EmployeeRegister.DAL.Repository
{
    public interface IRepository
    {
        void Create<T>(T model);

        void Edit(int id);

        void Delete(int id);
    }
}