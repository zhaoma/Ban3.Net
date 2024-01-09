//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.Common.Enums;

/// <summary>
/// 排序方式
/// </summary>
public enum Sort
{
    /// <summary>
    /// 升序
    /// </summary>
    [Description( "升序" )]
    Ascending = 1,

    /// <summary>
    /// 降序
    /// </summary>
    [Description( "降序" )]
    Descending = 2
}