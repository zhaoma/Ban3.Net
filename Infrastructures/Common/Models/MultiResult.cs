//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 实体结果集
/// </summary>
/// <typeparam name="T"></typeparam>
public class MultiResult<T>
{
    /// ctor
    public MultiResult() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="recordCount"></param>
    public MultiResult( List<T>? data, int? recordCount = null )
    {
        RecordCount = recordCount ?? data?.Count;
        Data = data;
    }

    /// <summary>
    /// 记录总数
    /// </summary>

    public int? RecordCount { get; set; }

    /// <summary>
    /// 分页记录集
    /// </summary>
    public List<T>? Data { get; set; }
}