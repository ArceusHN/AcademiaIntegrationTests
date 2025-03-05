using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Repositories
{
    public class PersonaRepository(ApplicationDbContext context) : IPersonaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.personas.FindAsync(id);
        }

        public async Task AddAsync(Persona persona)
        {
            await _context.personas.AddAsync(persona);
        }

        public void Update(Persona persona)
        {
            _context.personas.Update(persona);
        }

        public void Delete(Persona persona)
        {
            _context.personas.Remove(persona);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}

