using Domain.Hasselhoffing.ACoworker;
using Domain.UniversalCancellationHandler;
using Domain.UniversalDateTime;
using Domain.UniversalValidator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain
{
    public static class DependencyInjectionMapping
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CancellationTokenHandler<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHasselhoffingACoworker();
            services.AddDateTimeProvider();
        }
    }
}
