using Data.Hasselhoffing;
using Domain.Hasselhoffing.ACoworker;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyInjectionMapping
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<HoffTheRecordContext>();
            services.AddTransient<ICreateAHasslehoffRecord, CreateAHasslehoffRecord>();
        }
    }
}
