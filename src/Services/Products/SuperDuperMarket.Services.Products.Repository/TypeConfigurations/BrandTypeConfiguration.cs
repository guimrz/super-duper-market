using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository.TypeConfigurations
{
    public class BrandTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands")
                .HasKey(productType => productType.Id);

            builder.Property(productType => productType.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(productType => productType.Name)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}