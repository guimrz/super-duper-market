using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDuperMarket.Services.Products.Domain;

namespace SuperDuperMarket.Services.Products.Repository.TypeConfigurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products")
                .HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(product => product.CreationDate)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(product => product.UpdateDate)
                .ValueGeneratedOnUpdate();
        }
    }
}