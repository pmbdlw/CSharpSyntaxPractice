using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MinimalAPIBySelf.Db.Models;

#nullable disable
/// <summary>
/// 系统管理员
/// </summary>
public class SysUserEntity : BaseEntity
{
    /// <summary>
    /// 账号
    /// </summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required]
    public string UsePwd { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 为true的时候禁止登录
    /// </summary>
    public bool IsBan { get; set; } = false;
}
