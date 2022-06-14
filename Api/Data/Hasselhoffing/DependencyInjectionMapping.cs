using Domain.Hasselhoffing.ACoworker;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Hasselhoffing
{
    internal static class DependencyInjectionMapping
    {
        public static void AddHasselhoffingPersistence(this IServiceCollection services)
        {
            services.AddTransient<IInsertAHasslehoffRecord, CreateAHasslehoffRecord>();
            services.AddTransient<IGetWhenAUserWasLastHoffed, GetWhenAUserWasLastHoffed>();
        }
    }
}
