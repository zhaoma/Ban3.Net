using System.Data;
using System.Threading.Tasks;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 更新
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 更新记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static int Update<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Update, transaction)!
            .AddParameters(entity.ParametersForUpdate())
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();

    /// <summary>
    /// 更新记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static int Update<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Update, transaction, conditionOrSql)!
            .AddParameters(entity.ParametersForUpdate())
            .ExecuteNonQuery();

    /// <summary>
    /// 异步更新记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<int> UpdateAsync<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Update, transaction)!
            .AddParameters(entity.ParametersForUpdate())
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQueryAsync();

    /// <summary>
    /// 异步更新记录(按条件)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<int> UpdateAsync<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => await entity
            .Command(Operate.Update, transaction, conditionOrSql)!
            .AddParameters(entity.ParametersForUpdate())
            .ExecuteNonQueryAsync();
}