using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Repositories;
using AcademiaIntegrationTestAndMock.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIntegrationTestAndMock.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence()
                    .AddStorage();
            
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("DataSource= AcademiaIntegrationTestAndMock.sqlite"));

            services.AddScoped<IPersonaRepository, PersonaRepository>();

            return services;
        }

        private static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            return services;
        }
    }
}
