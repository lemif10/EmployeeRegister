using System.Collections.Generic;

namespace EmployeeRegister.BusinessLogic.Services
{
    public interface IExtendedServiceData : IServiceData
    {
        List<T> Index<T>();
    }
}