using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Ddd.Domain.Products;

namespace Practice.Ddd.Persistence.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            productId => productId.Value,
            value => new ProductId(value));

        builder.Property(p => p.Name).HasMaxLength(50);

        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!)
            .HasMaxLength(15);

        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            priceBuilder.Property(m => m.Amount).HasPrecision(18, 2);
        });
    }
}
