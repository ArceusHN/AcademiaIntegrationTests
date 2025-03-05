using AcademiaIntegrationTestAndMock.Infrastructure.Persistence;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using AcademiaIntegrationTestAndMock.IntegrationTest.Helpers;
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
                services.RemoveService<ApplicationDbContext>();
                services.RemoveService<DbConnection>();

                services.AddSingleton<DbConnection>(sp =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<ApplicationDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    options.UseSqlite(connection);
                });

            });
        }
    }
}
