using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    public static bool Insert<T>(
        this List<T> entities,
        out List<T> result,
        IDbTransaction? transaction = null) where T : class
    {
        var sql = typeof(T).SqlForInsert();
        var cmd = typeof(T)
            .DB()!
            .Command(sql,transaction);

        result =new List<T>();
        entities.ForEach(t =>
        {
            var ps = t.ParametersForInsert();

            cmd.Parameters.Clear();
            cmd.AddParameters(ps);
            var kv=cmd.ExecuteScalar();
            t.FulfillKeyValue(kv);
        });

        result = entities;
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static T Insert<T>(this T entity, IDbTransaction? transaction = null) where T : class
    {
        var keyValue = typeof(T)
            .DB()!
            .Command(typeof(T).SqlForInsert(), transaction)
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
    public static async Task<T> CreateAsync<T>(this T entity, IDbTransaction? transaction = null) where T : class
    {
        var strategy = entity.Strategy();
        var keyValue = await strategy.DB!
            .Command(strategy.InsertCommand(), transaction)
            .AddParameters(entity.ParametersForInsert())
            .ExecuteScalarAsync(CancellationTokenSource.Token);

        return entity.FulfillKeyValue(keyValue);
    }
}