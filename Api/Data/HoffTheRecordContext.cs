using Persistence.Hasselhoffing;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal class HoffTheRecordContext : DbContext
    {
        public DbSet<HasslehoffRecord> Hoffs { get; set; }

        public string DbPath { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HoffTheRecordContext()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "HoffTheRecord.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(HoffTheRecordContext).Assembly);
    }
}
