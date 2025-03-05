using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;

namespace AcademiaIntegrationTestAndMock.Common.Interfaces.Services
{
    public interface IPersonaApplicationService
    {
        Task<IEnumerable<PersonaResponse>> GetAllAsync();
        Task<PersonaResponse> CreateAsync(CreatePersonaRequest request);
    }
}
