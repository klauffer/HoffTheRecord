using MediatR;
using Microsoft.Extensions.DependencyInjection;
using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;

namespace Domain.Hasselhoffing.ACoworker
{
    internal static class DependencyInjectionMapping
    {
        public static void AddHasselhoffingACoworker(this IServiceCollection services)
        {
            services.AddScoped<IPipelineBehavior<HasselhoffingACoworkerCommand, HasselhoffingACoworkerResponse>, PersistCoworkerHoffed>();
        }
    }
}
