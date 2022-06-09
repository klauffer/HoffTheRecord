namespace HoffTheRecord.Acceptance.Tests.Infrastructure
{
    [CollectionDefinition("DefaultCollectionDefinition")]
    public class DefaultCollectionDefinition :
        ICollectionFixture<HoffTheRecordWebApplicationFactory<Program>>
    {
    }
}
