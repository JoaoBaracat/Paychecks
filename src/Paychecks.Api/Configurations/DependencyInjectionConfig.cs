using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paychecks.Infra.IoC;
using System;

namespace Paychecks.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}