using API.Hasselhoffing;
using API.UniversalExceptionHandler;
using Bogus;
using HoffTheRecord.Acceptance.Tests.Infrastructure;
using System.Net;
using static Domain.Hasselhoffing.ACoworker.HasselhoffingACoworkerHandler;

namespace HoffTheRecord.Acceptance.Tests
{
    [Collection("DefaultCollectionDefinition")]
    public class HasslehoffACoworkerShould
    {
        private readonly HoffTheRecordWebApplicationFactory<Program> _factory;
        private readonly Faker _faker = new Faker();

        public HasslehoffACoworkerShould(HoffTheRecordWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnASuccessCode()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest (
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: _faker.Name.FullName(),
                imageUrl: "https://picsum.photos/200/300"
            );
            var response = await client.Post("/api/Hasselhoff", request);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CancelTheRequest()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: _faker.Name.FullName(),
                imageUrl: "https://picsum.photos/200/300"
            );

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

            var request = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: personThatCommittedTheOffense,
                personThatWasHoffed: _faker.Name.FullName(),
                imageUrl: "https://picsum.photos/200/300"
            );
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
            var request = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: personThatWasHoffed,
                imageUrl: "https://picsum.photos/200/300"
            );
            var response = await client.Post("/api/Hasselhoff", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task RequireImageUrl(string imageUrl)
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: _faker.Name.FullName(),
                imageUrl: imageUrl
            );
            var response = await client.Post("/api/Hasselhoff", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task RecordATimeStamp()
        {
            var client = _factory.BuildClient();
            var request = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: _faker.Name.FullName(),
                imageUrl: "https://picsum.photos/200/300"
            );
            var response = await client.Post("/api/Hasselhoff", request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.GetResponse<HasselhoffingACoworkerResponse>();
            Assert.NotNull(responseBody?.TimeOfTheHoffing);
        }

        [Fact]
        public async Task NotAllowMoreThenOneHoffingPerPersonPerMinute()
        {
            var client = _factory.BuildClient();
            var personThatWasHoffed = _faker.Name.FullName();

            var request1 = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: personThatWasHoffed,
                imageUrl: "https://picsum.photos/200/300"
            );
            await client.Post("/api/Hasselhoff", request1);

            var request2 = new HasslehoffACoworkerRequest(
                personThatCommittedTheOffense: _faker.Name.FullName(),
                personThatWasHoffed: personThatWasHoffed,
                imageUrl: "https://picsum.photos/200/300"
            );
            var response2 = await client.Post("/api/Hasselhoff", request2);

            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);
        }
    }
}