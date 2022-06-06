namespace API
{
    public static class DependencyInjectionMapping
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddDomain();
        }
    }
}
