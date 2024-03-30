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

            builder.Property(product => product.Description);

            builder.Property(product => product.Stock);

            builder.HasOne(product => product.ProductType)
                .WithMany()
                .HasForeignKey(product => product.ProductTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(product => product.Brand)
                .WithMany()
                .HasForeignKey(product => product.BrandId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(product => product.CreationDate)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(product => product.UpdateDate)
                .ValueGeneratedOnUpdate();
        }
    }
}