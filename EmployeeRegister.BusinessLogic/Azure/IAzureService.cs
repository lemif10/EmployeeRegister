using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegister.BusinessLogic.Azure
{
    public interface IAzureService
    {
        Task<List<string>> GetImageUrls();
    }
}