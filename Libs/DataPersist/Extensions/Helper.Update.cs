using System.Data;
using Ban3.Infrastructures.DataPersist.Entities;
using Ban3.Infrastructures.DataPersist.Enums;

namespace Ban3.Infrastructures.DataPersist.Extensions;

/// <summary>
/// 更新
/// </summary>
public static partial class Helper
{
    public static int Update<T>(this T entity, IDbTransaction? transaction = null) 
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Update, transaction)!
            .AddParameters(entity.ParametersForUpdate())
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();
}