using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIntegrationTestAndMock.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("DataSource= AcademiaIntegrationTestAndMock.sqlite"));

            services.AddScoped<IPersonaRepository, PersonaRepository>();

            return services;
        }
    }
}
