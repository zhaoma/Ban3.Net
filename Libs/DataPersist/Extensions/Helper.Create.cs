using System.Data;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static T Insert<T>(this T entity, IDbTransaction? transaction = null) where T : class
    {
        var keyValue = entity
            .DB()!
            .Command(entity.SqlForInsert(), transaction)
            .AddParameters(entity.ParametersForInsert())
            .ExecuteScalar();

        return entity.FulfillKeyValue(keyValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<T> InsertAsync<T>(this T entity, IDbTransaction? transaction = null) where T : class
    {
        var keyValue = await entity
            .DB()!
            .Command(entity.SqlForInsert(), transaction)
            .AddParameters(entity.ParametersForInsert())
            .ExecuteScalarAsync(CancellationTokenSource.Token);

        return entity.FulfillKeyValue(keyValue);
    }
}