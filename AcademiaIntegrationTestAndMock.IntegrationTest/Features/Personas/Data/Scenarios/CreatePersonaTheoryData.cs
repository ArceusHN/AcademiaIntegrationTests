using AcademiaIntegrationTestAndMock.Features.Personas;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas.Data.Scenarios
{
    public class CreatePersonaTheoryData : TheoryData<CreatePersonaRequest, (HttpStatusCode, string?)>
    {
        public CreatePersonaTheoryData()
        {
            Add(new CreatePersonaRequest { Nombre = "Juan", Apellido = "Perez", Edad = 30, Sexo = 'M', Identidad = "050100009812", Imagen = ObtenerImagen() }, (HttpStatusCode.OK, null));
            Add(new CreatePersonaRequest { Nombre = "A", Apellido = "Perez", Edad = 30, Sexo = 'M', Identidad="050100009812" ,Imagen = ObtenerImagen() }, (HttpStatusCode.BadRequest, PersonasValidacionMensajes.NombreMinimoCaracteres));
            Add(new CreatePersonaRequest { Nombre = "Gerardo", Apellido = "Perez", Edad = 0, Sexo = 'M', Identidad="050100009812", Imagen = ObtenerImagen() }, (HttpStatusCode.BadRequest, PersonasValidacionMensajes.EdadMayorACero));
        }

        private IFormFile ObtenerImagen()
        {
            return new FormFile(new MemoryStream(new byte[0]), 0, 0, "Data", "imagen.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };
        }
    }
}
