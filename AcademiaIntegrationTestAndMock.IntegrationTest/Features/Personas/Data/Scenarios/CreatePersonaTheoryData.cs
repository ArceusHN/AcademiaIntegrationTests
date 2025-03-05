using AcademiaIntegrationTestAndMock.Features.Personas;
using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using System.Net;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Features.Personas.Data.Scenarios
{
    public class CreatePersonaTheoryData : TheoryData<CreatePersonaRequest, (HttpStatusCode, string?)>
    {
        public CreatePersonaTheoryData()
        {
            Add(new CreatePersonaRequest { Nombre = "Juan", Apellido = "Perez", Edad = 30, Sexo = 'M' }, (HttpStatusCode.OK, null) );
            Add(new CreatePersonaRequest { Nombre = "", Apellido = "Perez", Edad = 30, Sexo = 'M' }, (HttpStatusCode.BadRequest, PersonasValidacionMensajes.NombreRequerido));
            Add(new CreatePersonaRequest { Nombre = "Juan", Apellido = "Perez", Edad = 0, Sexo = 'M' }, (HttpStatusCode.BadRequest, PersonasValidacionMensajes.EdadMayorACero));
        }
    }
}
