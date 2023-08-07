using System.Data;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    public static int Update<T>(this T entity, IDbTransaction? transaction = null) where T : class
        => typeof(T)
            .DB()!
            .Command(typeof(T).SqlForUpdate(), transaction)
            .AddParameters(entity.ParametersForUpdate())
            .AddParameters(entity.ParametersForKeys())
            .ExecuteNonQuery();
}