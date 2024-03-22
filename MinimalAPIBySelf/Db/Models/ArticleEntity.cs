using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPIBySelf.Db.Models;

/// <summary>
/// 文章-包括关于我们
/// </summary>
public class ArticleEntity : BaseEntity
{
    /// <summary>
    /// 标题
    /// </summary>
    [Required(ErrorMessage = "缺少标题信息")]
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>

    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 下一个
    /// </summary>
    public int? NetxtId { get; set; }

    /// <summary>
    /// 下一个文章信息
    /// </summary>
    public ArticleEntity? NextArticle { get; set; }

    /// <summary>
    /// 上一个
    /// </summary>
    public int? PreviousId { get; set; }

    /// <summary>
    /// 上一个文章信息
    /// </summary>
    public ArticleEntity? PreviousArticle { get; set; }

    /// <summary>
    /// 序号
    /// </summary>
    public int Sort { get; set; } = 0;

    /// <summary>
    /// 文章类型 0：普通文章 211:关于我们  212：网站底部信息 213：备案号
    /// </summary>
    public Int16 Type { get; set; }
    
    /// <summary>
    /// Creator ID
    /// </summary>
    public int? CreatorId { get; set; }
    
    /// <summary>
    /// Creator
    /// </summary>
    public SysUserEntity Creator { get; set; }
}
