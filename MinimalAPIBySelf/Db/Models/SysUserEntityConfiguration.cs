using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalAPIBySelf.Db.Models;

/// <summary>
/// SysUser Entity Config
/// </summary>
public class SysUserEntityConfiguration : IEntityTypeConfiguration<SysUserEntity>
{
    public void Configure(EntityTypeBuilder<SysUserEntity> builder) {
        
    }
}