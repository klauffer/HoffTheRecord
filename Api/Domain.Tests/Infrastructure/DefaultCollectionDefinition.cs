namespace HoffTheRecord.Integration.Tests.Infrastructure
{
    [CollectionDefinition("DefaultCollectionDefinition")]
    public class DefaultCollectionDefinition :
        ICollectionFixture<HoffTheRecordWebApplicationFactory<Program>>
    {
    }
}
