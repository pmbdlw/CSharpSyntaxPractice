using CodeFirstLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstLearning.Infrastructure.Data.Configurations;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasKey(e => e.AdminId);
        builder.Property(e => e.AdminId).ValueGeneratedOnAdd();
        builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
        builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(64);
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
    }
}