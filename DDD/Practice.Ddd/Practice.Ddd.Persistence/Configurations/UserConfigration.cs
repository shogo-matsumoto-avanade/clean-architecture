using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Ddd.Domain.Users;

namespace Practice.Ddd.Persistence.Configurations;

internal class UserConfigration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            userId => userId.Value,
            value => new UserId(value))
            .HasMaxLength(30);

        builder.Property(u => u.FirstName).HasMaxLength(50);

        builder.Property(u => u.FamilyName).HasMaxLength(50);

        builder.Property(u => u.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();
    }
}
