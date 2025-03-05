namespace AcademiaIntegrationTestAndMock.Features.Personas.DTOs
{
    public class PersonaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public char Sexo { get; set; }
    }
}
