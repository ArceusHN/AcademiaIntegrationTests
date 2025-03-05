using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using ErrorOr;

namespace AcademiaIntegrationTestAndMock.Common.Interfaces.Services
{
    public interface IPersonaApplicationService
    {
        Task<IEnumerable<PersonaResponse>> GetAllAsync();
        Task<ErrorOr<PersonaResponse>> CreateAsync(CreatePersonaRequest request);
    }
}
