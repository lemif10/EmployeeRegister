using EmployeeRegister.DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegister.Dependencies
{
    public static class Dependencies
    {
        public static void GetConnectionSettings(this IServiceCollection services,IConfiguration configuration)
        {
            
        }
    }
}