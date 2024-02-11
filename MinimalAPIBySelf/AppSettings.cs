using System.Runtime.CompilerServices;

namespace MinimalAPIBySelf;

#nullable disable
public class AppSettings
{
    public string JwtIssuer { get; set; }
    public string JwtAudience { get; set; }
    public string JwtSecurityKey { get; set; }
    public string DbConnectionStrings { get; set; }

    /// <summary>
    /// 当前站点url链接
    /// </summary>
    public string WebUrl { get; set; }

    /// <summary>
    /// 默认账号
    /// </summary>
    public string DefaultAccount { get; set; }

    /// <summary>
    /// 默认密码
    /// </summary>
    public string DefaultPwd { get; set; }

    /// <summary>
    /// 管理员邮箱
    /// </summary>
    public string AdminEmail { get; set; }
}