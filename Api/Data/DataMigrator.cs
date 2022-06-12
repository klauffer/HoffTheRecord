using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DataMigrator
    {
        public static void MigrateSchema(this IServiceProvider services)
        {
            HoffTheRecordContext context = services.GetRequiredService<HoffTheRecordContext>();
            context.Database.Migrate();
        }
    }
}
