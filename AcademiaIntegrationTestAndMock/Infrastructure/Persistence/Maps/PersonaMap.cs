using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;

namespace AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Maps
{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Edad)
                .IsRequired();

            builder.Property(p => p.Sexo)
                .IsRequired()
                .HasMaxLength(1);
        }
    }
}
