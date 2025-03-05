namespace AcademiaIntegrationTestAndMock.Infrastructure.Persistence.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public string Identidad { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
    }
}
