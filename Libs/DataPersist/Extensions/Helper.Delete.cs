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
    /// 删除记录
    public static int Delete<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Delete, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();

    /// 异步删除记录
    public static int Delete<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.DeleteByCondition, transaction, conditionOrSql)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();

    /// 删除记录
    public static Task<int> DeleteAsync<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Delete, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQueryAsync(CancellationTokenSource.Token);

    /// 异步删除记录
    public static Task<int> DeleteAsync<T>(this T entity, string conditionOrSql, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Delete, transaction, conditionOrSql)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQueryAsync(CancellationTokenSource.Token);
}