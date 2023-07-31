/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System.Collections.Generic;

namespace Ban3.Infrastructures.DataPersist.Models;

public class MultiResult<T>
{
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
    public List<T> Data { get; set; }
}