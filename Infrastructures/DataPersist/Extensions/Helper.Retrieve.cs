using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 检索
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 检索单个记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static T? Retrieve<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Retrieve, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteReader()
            .DataReaderToEntity<T>();

    /// <summary>
    /// 检索单个记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static T? Retrieve<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity.Read(conditionOrSql)
            .DataReaderToEntity<T>();

    /// <summary>
    /// 检索记录集合(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static List<T> RetrieveList<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity.Read(conditionOrSql)
            .DataReaderToList<T>();

    private static IDataReader Read<T>(this T entity, string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Retrieve, transaction, conditionOrSql)!
            .ExecuteReader();

    /// <summary>
    /// 异步检索单个记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<T?> RetrieveAsync<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
    {
        var reader = await entity
            .Command(Operate.Retrieve, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteReaderAsync();

        return reader.DataReaderToEntity<T>();
    }

    /// <summary>
    /// 异步检索单个记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<T?> RetrieveAsync<T>(this T entity, string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
    {
        var reader = await entity.ReadAsync(conditionOrSql, transaction);
        return reader.DataReaderToEntity<T>();
    }

    /// <summary>
    /// 异步检索记录集合(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<List<T>> RetrieveListAsync<T>(this T entity, string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
    {
        var reader = await entity.ReadAsync(conditionOrSql, transaction);
        return reader.DataReaderToList<T>();
    }

    private static async Task<IDataReader> ReadAsync<T>(this T entity, string conditionOrSql,
        IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Retrieve, transaction, conditionOrSql)!
            .ExecuteReaderAsync();


}
        