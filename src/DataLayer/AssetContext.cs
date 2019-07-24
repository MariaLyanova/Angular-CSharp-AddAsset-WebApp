using DomainClasses;
using System.Data.Entity;

namespace DataLayer
{
    public class AssetContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MimeType> MimeTypes { get; set; }

        public AssetContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new AssetInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new AssetConfiguration())
                .Add(new CountryConfiguration())
                .Add(new MimeTypeConfiguration());
        }
    }
}