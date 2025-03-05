using AcademiaIntegrationTestAndMock.Common.DTOs;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas.Data.Scenarios;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas
{
    
    public class PersonasTests :
        IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public PersonasTests(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Dado_QueSeHanSembradoPersonas_CuandoSeInvocaElEndpointDePersona_Entonces_Retorna200YUnaColeccionDePersonasNoNula()
        {
            // Arrange
            string url = "/api/Persona";

            //Act
            var response = await _httpClient.GetAsync(url);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var personas = await response.Content.ReadFromJsonAsync<IEnumerable<PersonaResponse>>();

            personas.Should().NotBeNull();
        }


        [Theory]
        [ClassData(typeof(CreatePersonaTheoryData))]
        public async Task Dado_UnaNuevaPersona_CuandoSeInvocaElEndpointDePersonaConDatosValidos_Entonces_RetornaResultadoEsperado(
        CreatePersonaRequest request,
        (HttpStatusCode expectedStatusCode, string? expectedMessage) expectedValues)
        {
            // Arrange
            string url = "/api/Persona";

            // Act
            var response = await _httpClient.PostAsJsonAsync(url, request);

            // Assert
            response.StatusCode.Should().Be(expectedValues.expectedStatusCode);

            // Si no hay mensaje esperado, salimos
            if (string.IsNullOrEmpty(expectedValues.expectedMessage))
            {
                return;
            }

            // Si hay un mensaje esperado, leemos la respuesta y validamos el mensaje
            var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

            errorResponse.Should().NotBeNull();
            errorResponse!.Message.Should().Be(expectedValues.expectedMessage);
        }

    }
}
