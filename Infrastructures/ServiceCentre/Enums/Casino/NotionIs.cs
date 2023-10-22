using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 题材分组
/// </summary>
public enum NotionIs
{
    /// <summary>
    /// 概念
    /// </summary>
    [Description("概念")]
    Concept = 1,

    /// <summary>
    /// 地区
    /// </summary>
    [Description("地区")]
    Region = 3,

    /// <summary>
    /// 行业
    /// </summary>
    [Description("行业")]
    Industry = 4
}

