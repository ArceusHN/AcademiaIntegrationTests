using AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities;
using ErrorOr;

namespace AcademiaIntegrationTestAndMock.Features.Personas
{
    public class PersonasDomainService
    {
        public ErrorOr<Persona> ValidateCreatePersona(Persona persona)
        {
            if(string.IsNullOrWhiteSpace(persona.Nombre))
            {
                return Error.Validation(description: PersonasValidacionMensajes.NombreRequerido);
            }

            if (string.IsNullOrWhiteSpace(persona.Apellido))
            {
                return Error.Validation(description: PersonasValidacionMensajes.ApellidoRequerido);
            }

            if (persona.Edad <= 0)
            {
                return Error.Validation(description: PersonasValidacionMensajes.EdadMayorACero);
            }

            if(string.IsNullOrEmpty(string.Concat(persona.Sexo)))
            {
                return Error.Validation(description: PersonasValidacionMensajes.SexoRequerido);
            }

            if (persona.Sexo != 'M' && persona.Sexo != 'F')
            {
                return Error.Validation(description: PersonasValidacionMensajes.SexoValido);
            }

            if (persona.Nombre.Length < 3) { 
                return Error.Validation(description: PersonasValidacionMensajes.NombreMinimoCaracteres);
            }

            return persona;
        }
    }
}
