using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaIntegrationTestAndMock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaApplicationService _personaApplicationService;

        public PersonaController(IPersonaApplicationService personaApplicationService)
        {
            _personaApplicationService = personaApplicationService;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonaResponse>> GetAllAsync()
        {
            return await _personaApplicationService.GetAllAsync();
        }

        [HttpPost]
        public async Task<PersonaResponse> CreateAsync([FromBody] CreatePersonaRequest request)
        {
            return await _personaApplicationService.CreateAsync(request);
        }
    }
}
