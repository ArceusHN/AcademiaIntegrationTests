using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas;

namespace AcademiaIntegrationTestAndMock.Features
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonaApplicationService, PersonasAppService>();
            services.AddScoped<PersonasDomainService, PersonasDomainService>();

            return services;
        }
    }
}