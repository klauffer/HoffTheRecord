using API.Hasselhoffing;
using API.UniversalExceptionHandler;
using FluentValidation;
using HoffTheRecord.Integration.Tests.Infrastructure;
using System.Net;

namespace HoffTheRecord.Integration.Tests
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
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "Bugs Bunny" };
            var response = await client.Post("/api/Hasselhoffing", request);
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
            await Assert.ThrowsAsync<OperationCanceledException>(async () => await client.Post("/api/Hasselhoffing", request, token));
        }

        [Fact]
        public async Task RequirePersonThatCommittedTheOffense()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest() { PersonThatCommittedTheOffense = "" };
            var response = await client.Post("/api/Hasselhoffing", request);

            var note = await response.GetResponse<HttpValidationErrorResponse>();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            //await Assert.ThrowsAsync<ValidationException>(async () => await client.Post("/api/Hasselhoffing", request));
        }
    }
}