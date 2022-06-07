using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoffTheRecord.Integration.Tests
{
    [CollectionDefinition("WebClientCollection")]
    public class WebClientCollection :
        ICollectionFixture<HoffTheRecordWebApplicationFactory<Program>>
    {
    }
}
