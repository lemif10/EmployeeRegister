using EmployeeRegister.DAL.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegister.Dependencies
{
    public static class Dependencies
    {
        public static void AddConnectionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ConnectionSettings
            {
                ConnectionString = configuration.GetConnectionString("DefaultConnection") 
            });
        }
    }
}