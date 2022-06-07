using Domain;

namespace API
{
    public static class DependencyInjectionMapping
    {
        public static void AddImplemenationDependencies(this IServiceCollection services)
        {
            services.AddDomain();
        }
    }
}
