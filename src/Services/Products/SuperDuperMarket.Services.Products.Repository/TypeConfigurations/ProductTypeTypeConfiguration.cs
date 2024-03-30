using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository.TypeConfigurations
{
    public class ProductTypeTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes")
                .HasKey(productType => productType.Id);

            builder.Property(productType => productType.Id)
                .ValueGeneratedNever();

            builder.Property(productType => productType.Name)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}