using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace AcademiaIntegrationTestAndMock.Common.Interfaces.Services
{
    public interface IStorageService
    {
        Task<ErrorOr<string>> SaveFileAsync(IFormFile file);
    }
}
