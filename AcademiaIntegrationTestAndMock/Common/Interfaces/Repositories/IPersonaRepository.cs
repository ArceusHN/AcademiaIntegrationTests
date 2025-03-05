using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;

namespace AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(int id);
        Task AddAsync(Persona persona);
        void Update(Persona persona);
        void Delete(Persona persona);
        Task<bool> SaveChangesAsync();
    }
}
