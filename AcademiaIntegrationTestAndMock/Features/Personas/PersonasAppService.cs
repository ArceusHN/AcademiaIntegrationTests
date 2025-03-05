using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using AcademiaIntegrationTestAndMock.Features.Personas.Mappings;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;

namespace AcademiaIntegrationTestAndMock.Features.Personas
{
    public class PersonasAppService : IPersonaApplicationService
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonasAppService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<PersonaResponse>> GetAllAsync()
        {
            IEnumerable<Persona> personas = await _personaRepository.GetAllAsync();

            return PersonaMapping.ToResponse(personas);
        }
        
        public async Task<PersonaResponse> CreateAsync(CreatePersonaRequest request)
        {
            Persona persona = request.ToEntity();

            await _personaRepository.AddAsync(persona);
            await _personaRepository.SaveChangesAsync();

            return persona.ToResponse();
        }
    }
}
