using Data.Hasselhoffing;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class HoffTheRecordContext : DbContext
    {
        public DbSet<HasslehoffRecord> Hoffs { get; set; }

        public string DbPath { get; }

        public HoffTheRecordContext()
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
