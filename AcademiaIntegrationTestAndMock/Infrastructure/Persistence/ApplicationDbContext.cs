using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIntegrationTestAndMock.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions dbContext) : DbContext(dbContext)
    {
       public DbSet<Persona> personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
