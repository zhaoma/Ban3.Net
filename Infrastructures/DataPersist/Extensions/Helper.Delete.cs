using System.Data;
using System.Threading.Tasks;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 删除
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static int Delete<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Delete, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();

    /// <summary>
    /// 异步删除记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static int Delete<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.DeleteByCondition, transaction, conditionOrSql)!
            .ExecuteNonQuery();

    /// <summary>
    /// 异步删除记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<int> DeleteAsync<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Delete, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQueryAsync(CancellationTokenSource.Token);

    /// <summary>
    /// 异步删除记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<int> DeleteAsync<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Delete, transaction, conditionOrSql)!
            .ExecuteNonQueryAsync(CancellationTokenSource.Token);
}