using AcademiaIntegrationTestAndMock.Features.Personas.DTOs;
using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;

namespace AcademiaIntegrationTestAndMock.Features.Personas.Mappings
{
    public static class PersonaMapping
    {
        public static PersonaResponse ToResponse(this Persona persona)
        {
            return new PersonaResponse
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Edad = persona.Edad,
                Sexo = persona.Sexo,
                Identidad = persona.Identidad,
            };
        }

        public static IEnumerable<PersonaResponse> ToResponse(this IEnumerable<Persona> personas)
        {
            return personas.Select(p => p.ToResponse());
        }

        public static Persona ToEntity(this CreatePersonaRequest request)
        {
            return new Persona
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Edad = request.Edad,
                Sexo = request.Sexo,
                Identidad = request.Identidad
            };
        }
    }
}
