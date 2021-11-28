using System.Collections.Generic;

namespace EmployeeRegister.DataAccessLayer.Repository
{
    public interface IExtendedRepository : IRepository
    {
        List<T> Index<T>();
    }
}