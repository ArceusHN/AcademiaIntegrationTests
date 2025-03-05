namespace AcademiaIntegrationTestAndMock.Features.Personas
{
    public static class PersonasValidacionMensajes
    {
        public static string NombreRequerido => "El nombre es requerido";
        public static string ApellidoRequerido => "El apellido es requerido";
        public static string EdadRequerida => "La edad es requerida";
        public static string SexoRequerido => "El sexo es requerido";
        public static string NombreMinimoCaracteres => "El nombre debe tener al menos 3 caracteres";
        public static string EdadMayorACero => "La edad debe ser mayor a 0";
        public static string SexoValido => "El sexo debe ser M o F";
    }
}
