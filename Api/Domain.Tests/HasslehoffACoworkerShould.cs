using API.Hasselhoffing;
using API.UniversalExceptionHandler;
using HoffTheRecord.Acceptance.Tests.Infrastructure;
using System.Net;

namespace HoffTheRecord.Acceptance.Tests
{
    [Collection("DefaultCollectionDefinition")]
    public class HasslehoffACoworkerShould
    {
        private readonly HoffTheRecordWebApplicationFactory<Program> _factory;

        public HasslehoffACoworkerShould(HoffTheRecordWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnASuccessCode()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "Bugs Bunny", PersonThatWasHoffed="Elmer Fudd" };
            var response = await client.Post("/api/Hasselhoff", request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CancelTheRequest()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "Bugs Bunny" };

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await client.Post("/api/Hasselhoff", request, token));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task RequirePersonThatCommittedTheOffense(string personThatCommittedTheOffense)
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = personThatCommittedTheOffense };
            var response = await client.Post("/api/Hasselhoff", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task RequirePersonThatWasHoffed(string personThatWasHoffed)
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "Bugs Bunny", PersonThatWasHoffed = personThatWasHoffed };
            var response = await client.Post("/api/Hasselhoff", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}