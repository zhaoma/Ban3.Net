using System.Data;

namespace Ban3.Infrastructures.DataPersist.Extensions;

public static partial class Helper
{
    public static T Get<T>(this T entity, IDbTransaction? transaction = null) where T : class
        => typeof(T)
            .DB()!
            .Command(typeof(T).SqlForSelect(), transaction)
            .AddParameters(entity.ParametersForUpdate())
            .AddParameters(entity.ParametersForKeys())
            .ExecuteReader()
            .DataReaderToEntity<T>();
}