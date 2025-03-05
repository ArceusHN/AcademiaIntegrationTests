using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading.Tasks;
using ErrorOr;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Mocks.Storage
{
    public static class StorageServiceMock
    {
        public static void AddDefaultStorageServiceMock(this IServiceCollection services)
        {
            // Registra el substitute de IStorageService
            services.AddSingleton(Substitute.For<IStorageService>());
        }

        // Configura el servicio para que devuelva datos exitosos
        public static void SetupExitoso(IStorageService servicio)
        {
            // Devuelve un resultado exitoso con la URL esperada
            servicio.SaveFileAsync(Arg.Any<IFormFile>())
                    .Returns(Task.FromResult((ErrorOr<string>)"https://www.google.commm"));
        }

        public static void SetupError(IStorageService servicio)
        {
            servicio.SaveFileAsync(Arg.Any<IFormFile>())
                .Returns(Task.FromResult<ErrorOr<string>>(
                    (ErrorOr<string>)Error.Failure(description: "Ha ocurrido un error al guardar la imagen.")
                ));
        }


        // Configura el servicio para que lance una excepción simulando un error
        public static void SetupThrowExceptionError(IStorageService servicio)
        {
            // Lanza una excepción al llamar SaveFileAsync
            servicio.SaveFileAsync(Arg.Any<IFormFile>())
                    .ThrowsAsync(new Exception("Error simulando fallo en el almacenamiento."));
        }
    }
}
