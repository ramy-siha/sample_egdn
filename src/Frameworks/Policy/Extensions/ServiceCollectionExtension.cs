namespace Policy.Framework.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Policy.Framework.Data;
    using Policy.Framework.Data.Interface;
    using Policy.Framework.Data.Repositories;
    using Policy.Framework.Services;
    using Policy.Framework.Services.Interface;
    using Policy.Framework.Mappers;
    using AutoMapper;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IServiceService, ServiceService>();

            // Repository
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            // Mappers
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
