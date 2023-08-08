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
    public static T Retrieve<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
        => entity
            .Command(Operate.Retrieve, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteReader()
            .DataReaderToEntity<T>();

    public static async Task<T> RetrieveAsync<T>(this T entity, IDbTransaction? transaction = null)
        where T : BaseEntity, new()
    {
        var reader = await entity
            .Command(Operate.Retrieve, transaction)!
            .AddParameters(entity.ParametersForKeys())
            .ExecuteReaderAsync();

        return reader.DataReaderToEntity<T>();
    }
}
        