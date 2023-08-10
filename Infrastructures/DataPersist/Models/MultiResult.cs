/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System.Collections.Generic;

namespace Ban3.Infrastructures.DataPersist.Models;

/// <summary>
/// 带总数，和分页集合的结果
/// </summary>
/// <typeparam name="T"></typeparam>
public class MultiResult<T> where T : class
{
    /// <summary>
    /// 
    /// </summary>
    public MultiResult()
    {
        Data=new List<T>();
    }

    /// <summary>
    /// 记录总数
    /// </summary>
    public int RecordCount { get; set; }

    /// <summary>
    /// 分页记录集
    /// </summary>
    public List<T> Data { get; set; }
}