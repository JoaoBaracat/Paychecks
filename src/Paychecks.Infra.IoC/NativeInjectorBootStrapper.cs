using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paychecks.App.Apps;
using Paychecks.Domain.Apps;
using Paychecks.Domain.Notifications;
using Paychecks.Domain.Repositories;
using Paychecks.Infra.Data.Repositories;

namespace Paychecks.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //App
            services.AddScoped<IEmployeeApp, EmployeeApp>();

            //Domain
            services.AddScoped<INotifier, Notifier>();

            //Infra Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}