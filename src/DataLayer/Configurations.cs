using DomainClasses;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer
{
    internal class AssetConfiguration : EntityTypeConfiguration<Asset>
    {
        public AssetConfiguration()
        {
            Property(a => a.AssetId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    internal class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(a => a.CountryName)
                .IsRequired()
                // Max key length is required to create Unique index
                .HasMaxLength(100)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }
    }

    internal class MimeTypeConfiguration : EntityTypeConfiguration<MimeType>
    {
        public MimeTypeConfiguration()
        {
            Property(a => a.MimeTypeName)
                .IsRequired()
                // Max key length is required to create Unique index
                .HasMaxLength(100)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }
    }
}