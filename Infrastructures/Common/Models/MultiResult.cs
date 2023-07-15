
using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 实体结果集
/// </summary>
/// <typeparam name="T"></typeparam>
public class MultiResult<T>
{
    /// ctor
    public MultiResult()
    {
    }

    /// <summary>
    /// 记录总数
    /// </summary>
    public int RecordCount { get; set; }

    /// <summary>
    /// 分页记录集
    /// </summary>
    public List<T>? Data { get; set; }
}