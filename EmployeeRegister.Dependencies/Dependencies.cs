using EmployeeRegister.BusinessLogic.Azure;
using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.BusinessLogic.Services;
using EmployeeRegister.DAL.Connection;
using EmployeeRegister.DAL.Interfaces;
using EmployeeRegister.DAL.Repository;
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

            services.AddSingleton(new AzureSettings
            {
                ConnectionString = configuration.GetSection("AzureSettings").GetSection("ConnectionString").Value,
                ImageContainerName = configuration.GetSection("AzureSettings").GetSection("ImageContainerName").Value
            });
        }

        public static void AddIRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthService, AuthService>();
        }
        
        public static void AddIService(this IServiceCollection services)
        {
            services.AddTransient<IAzureService, AzureService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}