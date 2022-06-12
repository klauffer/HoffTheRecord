using Persistence.Hasselhoffing;
using Domain.Hasselhoffing.ACoworker;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjectionMapping
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<HoffTheRecordContext>();
            services.AddTransient<IInsertAHasslehoffRecord, CreateAHasslehoffRecord>();
        }
    }
}
