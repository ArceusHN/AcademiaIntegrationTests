using AcademiaIntegrationTestAndMock.Common.Interfaces.Services;
using ErrorOr;

namespace AcademiaIntegrationTestAndMock.Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        public async Task<ErrorOr<string>> SaveFileAsync(IFormFile file)
        {
            await Task.Delay(1000);
            return "https://www.google.com";
        }
    }
}
