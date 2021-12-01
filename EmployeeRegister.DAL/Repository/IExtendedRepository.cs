using System.Collections.Generic;

namespace EmployeeRegister.DAL.Repository
{
    public interface IExtendedRepository : IRepository
    {
        List<T> Index<T>();
    }
}