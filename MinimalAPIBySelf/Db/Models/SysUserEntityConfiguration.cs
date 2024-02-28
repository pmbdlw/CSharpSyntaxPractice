using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalAPIBySelf.Db.Models;

/// <summary>
/// SysUser Entity Config
/// </summary>
public class SysUserEntityConfiguration : IEntityTypeConfiguration<SysUserEntity>
{
    public void Configure(EntityTypeBuilder<SysUserEntity> builder)
    {
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.HasData(
            new SysUserEntity { Id = -10000,UserName = "admin1", UsePwd = "111111" }
        );
    }
}