using Microsoft.Extensions.DependencyInjection;
using Persistence.Hasselhoffing;

namespace Persistence
{
    public static class DependencyInjectionMapping
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<HoffTheRecordContext>();
            services.AddHasselhoffingPersistence();
        }
    }
}
