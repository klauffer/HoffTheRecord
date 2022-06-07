using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoffTheRecord.Integration.Tests.Infrastructure
{
    [CollectionDefinition("DefaultCollectionDefinition")]
    public class DefaultCollectionDefinition :
        ICollectionFixture<HoffTheRecordWebApplicationFactory<Program>>
    {
    }
}
