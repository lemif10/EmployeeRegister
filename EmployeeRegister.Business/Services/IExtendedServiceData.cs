using System.Collections.Generic;

namespace EmployeeRegister.Business.Services
{
    public interface IExtendedServiceData : IServiceData
    {
        List<T> Index<T>();
    }
}