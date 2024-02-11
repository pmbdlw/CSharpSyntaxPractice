﻿using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace WaiBao.Db.Models;

/// <summary>
/// 产品表
/// </summary>
public class ProductEntity : BaseEntity
{
    /// <summary>
    /// 分类ID
    /// </summary>
    [Required(ErrorMessage ="缺少分类ID")]
    public int ClassId { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    [SugarColumn(IsNullable = true, ColumnDataType = "varchar(500)")]
    public string CoverImage { get; set; } = string.Empty;

    /// <summary>
    /// 分类信息
    /// </summary>
    [Navigate(NavigateType.OneToOne, nameof(ClassId))]
    public ProductClassEntity ClassInfo { get; set; } = new ProductClassEntity();

    /// <summary>
    /// 产品详情内容
    /// </summary>
    [SugarColumn(ColumnDataType = "text")]
    public string? Detail { get; set; }

    /// <summary>
    /// 产品货号
    /// </summary>
    public string? ArticleNumber { get; set; }


    /// <summary>
    /// 产品名称
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// 产品颜色
    /// </summary>
    public string? ProductColor { get; set; }

    /// <summary>
    /// 包装方式
    /// </summary>
    public string? Packaging { get; set; }

    /// <summary>
    /// 外箱规格
    /// </summary>
    public string? BoxSpecification { get; set; }

    /// <summary>
    /// 产品规格
    /// </summary>
    public string? ProductSpecification { get; set; }

    /// <summary>
    /// 装箱数量
    /// </summary>
    public int? PackingQuantity { get; set; } = 0;

    /// <summary>
    /// 毛重
    /// </summary>
    public double? GrossWeight { get; set; }

    /// <summary>
    /// 净重
    /// </summary>
    public double? NetWeight { get; set; }

}


/// <summary>
/// 产品分类
/// </summary>
public class ProductClassEntity : BaseEntity
{
    /// <summary>
    /// 父级ID
    /// </summary>
    [SugarColumn(IsNullable = true, DefaultValue = "0")]
    public int ParentId { get; set; }

    /// <summary>
    /// 分类标题
    /// </summary>
    public int Title { get; set; }

    /// <summary>
    /// 子级
    /// </summary>
    [SqlSugar.SugarColumn(IsIgnore = true)]
    public List<ProductClassEntity> Child { get; set; } = new List<ProductClassEntity>();
}
