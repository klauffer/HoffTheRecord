using API.Hasselhoffing;
using HoffTheRecord.Integration.Tests.Infrastructure;

namespace HoffTheRecord.Integration.Tests
{
    [Collection("DefaultCollectionDefinition")]
    public class HasslehoffAPersonShould
    {
        private readonly HoffTheRecordWebApplicationFactory<Program> _factory;

        public HasslehoffAPersonShould(HoffTheRecordWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnASuccessCode()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "Bugs Bunny" };
            var response = await client.Post("/api/Hasselhoffing", request);
            response.EnsureSuccessStatusCode();
        }
    }
}