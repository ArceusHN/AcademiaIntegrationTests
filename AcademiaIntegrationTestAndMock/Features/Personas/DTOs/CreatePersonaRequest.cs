namespace AcademiaIntegrationTestAndMock.Features.Personas.DTOs
{
    public class CreatePersonaRequest
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public char Sexo { get; set; }
    }
}
