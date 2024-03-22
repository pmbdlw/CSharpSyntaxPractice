using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalAPIBySelf.Db.Models;

public class ArticleEntityConfiguration : IEntityTypeConfiguration<ArticleEntity>
{
    public void Configure(EntityTypeBuilder<ArticleEntity> builder)
    {
        builder.HasOne<SysUserEntity>()
            .WithMany()
            .HasForeignKey(a => a.CreatorId);
    }
}