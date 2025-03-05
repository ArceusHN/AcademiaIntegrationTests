using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Repositories;
using AcademiaIntegrationTestAndMock.IntegrationTest.Helpers;
using AcademiaIntegrationTestAndMock.IntegrationTest.Mocks.Storage;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace AcademiaIntegrationTestAndMock.IntegrationTest
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remover DbContext registro
                services.RemoveDbContext<ApplicationDbContext>();
                services.RemoveService<IPersonaRepository>();
                services.RemoveService<IStorageService>();


                services.AddDbContext<ApplicationDbContext>((container, options) =>
                {
                    options.UseInMemoryDatabase(databaseName: "ApplicationDbContext");
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });

                services.AddScoped<IPersonaRepository, PersonaRepository>();

                services.AddDefaultStorageServiceMock();

            });
        }
    }
}
