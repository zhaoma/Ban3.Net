/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static T Insert<T>(this IDbConnection connection, T entity) where T : class
    {

        return entity;
    }

    public static async Task<T> InsertAsync<T>(this IDbConnection connection, T entity) where T : class
    {
        return T;
    }
}