using System.Collections.Generic;
using EmployeeRegister.Common.Models;

namespace EmployeeRegister.Business.Services
{
    public interface IExtendedServiceData : IServiceData
    {
        IEnumerable<Employee> Index();
    }
}