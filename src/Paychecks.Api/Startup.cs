using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Paychecks.Api.Configurations;
using Paychecks.Infra.Data.Contexts;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Paychecks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PaychecksDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddDependencyInjectionConfiguration(Configuration);

            services.AddControllers();
            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<PaychecksDbContext>();
                    context.Database.Migrate();
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                ConfigureSwaggerUIActions(apiVersionDescriptionProvider, setupAction);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            loggerFactory.AddSerilog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureSwaggerUIActions(IApiVersionDescriptionProvider apiVersionDescriptionProvider, SwaggerUIOptions setupAction)
        {
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                setupAction.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
            setupAction.DefaultModelExpandDepth(2);
            setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
            setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            setupAction.EnableDeepLinking();
            setupAction.DisplayOperationId();
        }
    }
}