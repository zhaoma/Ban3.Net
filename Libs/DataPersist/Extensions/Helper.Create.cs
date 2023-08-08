using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 创建
/// </summary>
public static partial class Helper
{
    public static bool Create<T>(
        this List<T> entities,
        out List<T> result,
        IDbTransaction? transaction = null) 
        where T : BaseEntity,new()
    {
        var cmd = new T().Command(Operate.Create, transaction)!;

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
    public static T Create<T>(this T entity, IDbTransaction? transaction = null) 
        where T : BaseEntity, new()
    {
        var keyValue = entity.Command(Operate.Create,transaction)!
            .AddParameters(entity.ParametersForInsert())
            .ExecuteScalar();

        entity.FulfillKeyValue(keyValue);

        return entity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public static async Task<T> CreateAsync<T>(this T entity, IDbTransaction? transaction = null) 
        where T : BaseEntity, new()
    {
        var keyValue = await entity.Command(Operate.Create,transaction)!
            .AddParameters(entity.ParametersForInsert())
            .ExecuteScalarAsync(CancellationTokenSource.Token);

        entity.FulfillKeyValue(keyValue);

        return entity;
    }
}