using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace HoffTheRecord.Integration.Tests.Infrastructure
{
    public class HoffTheRecordWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
        }

        public HoffTheRecordHttpClient BuildClient(Action<IServiceCollection>? mockServices = null)
        {
            var client = WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    if (mockServices != null)
                        mockServices(services);
                });
            }).CreateClient();
            return new HoffTheRecordHttpClient(client);
        }
    }
}
