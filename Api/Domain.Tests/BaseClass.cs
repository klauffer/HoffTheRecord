using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace HoffTheRecord.Integration.Tests
{
    [Collection("WebClientCollection")]
    public partial class BaseClass
    {
        private readonly HoffTheRecordWebApplicationFactory<Program> _factory;
        protected HoffTheRecordHttpClient HoffTheRecordHttpClient;

        public BaseClass(HoffTheRecordWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            SetEnvironmentVariables();
            HoffTheRecordHttpClient = BuildClient(DefaultMockedServices);
        }

        private void DefaultMockedServices(IServiceCollection services)
        {
        }


        protected HoffTheRecordHttpClient BuildClient(Action<IServiceCollection>? mockServices = null)
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    if (mockServices != null)
                        mockServices(services);
                });
            }).CreateClient();
            return new HoffTheRecordHttpClient(client);
        }

        private void SetEnvironmentVariables()
        {
            Environment.SetEnvironmentVariable("AUTHORIZATION_SECRET", "IntegrationTestSuperSecretPhraseForReals");
        }


    }
}
