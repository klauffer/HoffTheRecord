using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
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
