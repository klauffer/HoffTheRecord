using API.Hasselhoffing;

namespace HoffTheRecord.Integration.Tests
{
    public class UnitTest1 : BaseClass
    {
        public UnitTest1(HoffTheRecordWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CreateANote()
        {
            var request = new HasslehoffAPersonRequest() { PersonThatCommittedTheOffense = "Bugs Bunny" };
            var response = await HoffTheRecordHttpClient.Post("/api/Hasselhoffing", request);
            response.EnsureSuccessStatusCode();
        }
    }
}