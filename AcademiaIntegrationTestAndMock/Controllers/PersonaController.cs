using AcademiaIntegrationTestAndMock.Common.Extensions;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using ErrorOr;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] CreatePersonaRequest request)
        {
            ErrorOr<PersonaResponse> resultado = await _personaApplicationService.CreateAsync(request);

            return this.ActionResultFrom(resultado);
        }
    }
}
