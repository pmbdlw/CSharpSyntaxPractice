using Microsoft.EntityFrameworkCore;
using MinimalAPIBySelf.Db.Models;
using System.Reflection.Metadata;

namespace MinimalAPIBySelf.Db;

/// <inheritdoc />
public class CmsContext : DbContext
{
    /// <inheritdoc />
    public CmsContext()
    {
        // Database.MigrateAsync();//.EnsureCreated();
    }
    public DbSet<SysUserEntity>? SysUser { get; set; }

    // 3. 配置 DbContext
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(AppConfig.Settings?.DbConnectionStrings);
    }
}