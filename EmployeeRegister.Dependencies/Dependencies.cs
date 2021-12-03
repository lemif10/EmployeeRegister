using EmployeeRegister.BusinessLogic.Interface;
using EmployeeRegister.BusinessLogic.Services;
using EmployeeRegister.DAL.Connection;
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
        }

        public static void AddIEmployeeRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
        
        public static void AddIEmployeeService(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
        
        public static void AddIDepartmentRepository(this IServiceCollection services)
        {
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
        
        public static void AddIDepartmentService(this IServiceCollection services)
        {
            services.AddTransient<IDepartmentService, DepartmentService>();
        }
        
        public static void AddIContactRepository(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}