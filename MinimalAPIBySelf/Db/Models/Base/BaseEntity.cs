using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MinimalAPIBySelf.Db.Models;

/// <summary>
/// 数据库实体基类
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// 主键ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 标识版本字段,用于乐观锁
    /// </summary>
    public long Ver { get; set; }
}
