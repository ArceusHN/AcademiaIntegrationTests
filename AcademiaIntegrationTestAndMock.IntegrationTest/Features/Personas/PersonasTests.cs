using AcademiaIntegrationTestAndMock.Common.DTOs;
using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas.Data.Scenarios;
using AcademiaIntegrationTestAndMock.IntegrationTest.Mocks.Storage;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas
{
    
    public class PersonasTests :
        IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageServiceMock;

        public PersonasTests(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();

            using var scope = factory.Services.CreateScope();
            _storageServiceMock = scope.ServiceProvider.GetRequiredService<IStorageService>();
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

        [Fact]
        public async Task Dado_UnaNuevaPersona_CuandoServiceStorageFalla_Entonces_RetornaError()
        {
            // Arrange

            StorageServiceMock.SetupError(_storageServiceMock);

            string url = "/api/Persona";

            var request = new CreatePersonaRequest
            {
                Nombre = "Ana",
                Apellido = "Martinez",
                Edad = 28,
                Sexo = 'F',
                Identidad = "87654321",
                Imagen = new FormFile(new MemoryStream(new byte[0]), 0, 0, "Data", "imagen.jpg")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg"
                }
            };


            // Act

            var response = await _httpClient.PostAsync(url, GetMultipartFormDataContent(request));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            errorResponse.Should().NotBeNull();
            errorResponse!.Message.Should().Be("Ha ocurrido un error al guardar la imagen.");
        }


        [Theory]
        [ClassData(typeof(CreatePersonaTheoryData))]
        public async Task Dado_UnaNuevaPersona_CuandoSeInvocaElEndpointDePersonaConDatosValidos_Entonces_RetornaResultadoEsperado(
        CreatePersonaRequest request,
        (HttpStatusCode expectedStatusCode, string? expectedMessage) expectedValues)
        {
            // Arrange
            StorageServiceMock.SetupExitoso(_storageServiceMock);
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



        private MultipartFormDataContent GetMultipartFormDataContent(CreatePersonaRequest request)
        {
            var content = new MultipartFormDataContent();

            content.Add(new StringContent(request.Nombre), nameof(request.Nombre));
            content.Add(new StringContent(request.Apellido), nameof(request.Apellido));
            content.Add(new StringContent(request.Edad.ToString()), nameof(request.Edad));
            content.Add(new StringContent(request.Sexo.ToString()), nameof(request.Sexo));
            content.Add(new StringContent(request.Identidad), nameof(request.Identidad));

            var fileContent = new StreamContent(request.Imagen.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(request.Imagen.ContentType);

            content.Add(fileContent, nameof(request.Imagen), request.Imagen.FileName);

            return content;
        }

    }
}
