using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaIntegrationTestAndMock.IntegrationTest.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void RemoveService<T>(this IServiceCollection services)
        {

            var dbContextDescriptor = services.SingleOrDefault(
                   d => d.ServiceType ==
                       typeof(T));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }
        }
    }
}
