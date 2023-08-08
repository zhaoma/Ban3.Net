/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;
using System.Data;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    private static IDataReader Query<T>(
        this T entity, 
        string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Sql, transaction, conditionOrSql)!
            .ExecuteReader();

    private static async Task<IDataReader> QueryAsync<T>(
        this T entity, 
        string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Sql, transaction, conditionOrSql)!
            .ExecuteReaderAsync();


}