//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

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
    [Description( "concept" )]
    Concept = 1630,

    /// <summary>
    /// 行业
    /// </summary>
    [Description( "industry" )]
    Industry = 1631,

    /// <summary>
    /// 地区
    /// </summary>
    [Description( "region" )]
    Region = 1632
}