using Microsoft.Extensions.DependencyInjection;

namespace Domain.UniversalDateTime
{
    public static class DependencyInjectionMapping
    {
        public static void AddDateTimeProvider(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, LocalMachineDateTimeProvider>();
        }
    }
}
