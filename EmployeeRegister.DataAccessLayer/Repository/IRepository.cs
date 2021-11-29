using System.Collections.Generic;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public interface IRepository
    {
        void Create<T>(T model);

        void Edit(int id);

        void Delete(int id);
    }
}