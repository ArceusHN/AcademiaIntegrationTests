using AcademiaIntegrationTestAndMock.Common.Interfaces.Repositories;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using AcademiaIntegrationTestAndMock.Features.Personas.Mappings;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using ErrorOr;

namespace AcademiaIntegrationTestAndMock.Features.Personas
{
    public class PersonasAppService : IPersonaApplicationService
    {
        private readonly PersonasDomainService _personasDomainService;
        private readonly IPersonaRepository _personaRepository;
        public PersonasAppService(IPersonaRepository personaRepository, PersonasDomainService personasDomainService)
        {
            _personaRepository = personaRepository;
            _personasDomainService = personasDomainService;
        }

        public async Task<IEnumerable<PersonaResponse>> GetAllAsync()
        {
            IEnumerable<Persona> personas = await _personaRepository.GetAllAsync();

            return PersonaMapping.ToResponse(personas);
        }
        
        public async Task<ErrorOr<PersonaResponse>> CreateAsync(CreatePersonaRequest request)
        {
            Persona persona = request.ToEntity();

            ErrorOr<Persona> resultValidation = _personasDomainService.ValidateCreatePersona(persona);

            if (resultValidation.IsError)
            {
                return ErrorOr<PersonaResponse>.From(resultValidation.Errors);
            }

            await _personaRepository.AddAsync(persona);
            await _personaRepository.SaveChangesAsync();

            return persona.ToResponse();
        }
    }
}
