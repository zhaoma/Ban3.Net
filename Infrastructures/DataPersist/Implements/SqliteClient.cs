using log4net;

namespace Ban3.Infrastructures.DataPersist.Implements;

/// 
public class SqliteClient
    //: Interfaces.IService
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(SqliteClient));
    /*
    /// <summary>
    /// 
    /// </summary>
    public IDbConnection Connection { get; }
    = new SqliteConnection(Config.DB.ConnectionString);

    public T Save<T>(object id, T t) where T : Entities.BaseEntity
    {
        var exists = Get<T>(id);
        if (exists == null)
        {
            Logger.Debug($"Insert {t.EqualCondition()}");
            return Insert(id, t);
        }
        else
        {
            if (exists.EqualCondition() != t.EqualCondition())
            {
                Logger.Debug($"Update {t.EqualCondition()}");
                return Update(id, t);
            }
            else
            {
                Logger.Debug($"SKIP {t.EqualCondition()}");
            }
        }

        return t;
    }

    public void BulkSave<T>(Dictionary<string, T> data) where T : Entities.BaseEntity
    {
        if (data != null && data.Any())
        {
            foreach (var item in data)
            {
                Save(item.Key, item.Value);
            }
        }
    }

    public void TupleSave<T>(IEnumerable<Tuple<string, string, T>> data) where T : Entities.BaseEntity
    {
        if (data != null && data.Any())
        {
            foreach (var item in data)
            {
                if (NotExists<T>(item.Item2))
                    Insert(item.Item1, item.Item3);
            }
        }
    }

    public T Insert<T>(object id, T t) where T : Entities.BaseEntity
    {
        try
        {
            Connection.Insert(t);
            return t;
        }
        catch (Exception ex)
        {
            Logger.Error(typeof(T).Name);
            Logger.Error(ex);
        }

        return null;
    }

    public T Get<T>(object id) where T : Entities.BaseEntity
    {
        try
        {
            return Connection.Get<T>(id);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    public bool Exists<T>(object id) where T : Entities.BaseEntity
    {
        return Get<T>(id) != null;
    }

    public bool NotExists<T>(string condition) where T : Entities.BaseEntity
    {
        var sql = $"Select 1 Where Exists (Select 1 from {typeof(T).TableName()} Where {condition})";
        try
        {
            return Connection.ExecuteScalar(sql) == null;
        }
        catch (Exception ex)
        {
            Logger.Error(sql);
            Logger.Error(ex);
        }

        return false;
    }

    public T Update<T>(object id, T t) where T : Entities.BaseEntity
    {
        try
        {
            return (Connection.Update(t))
                           ? t
                           : null;
        }
        catch (Exception ex)
        {
            Logger.Error(typeof(T).Name);
            Logger.Error(ex);
        }

        return null;
    }

    public bool Delete<T>(object id) where T : Entities.BaseEntity
    {
        try
        {
            return Connection.Execute($"DELETE FROM {typeof(T).TableName()} Where Id= {id}") > 0;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public IQueryable<T> Set<T>() where T : Entities.BaseEntity
    {
        var sql = $"Select * from {typeof(T).TableName()} ";
        try
        {
            return Connection.Query<T>(sql)
                                 .AsQueryable();
        }
        catch (Exception ex)
        {
            Logger.Error(sql);
            Logger.Error(ex);
        }

        return null;
    }

    public IQueryable<T> Set<T>(string condition) where T : Entities.BaseEntity
    {
        var sql = $"Select * from {typeof(T).TableName()} WHERE {condition}";
        try
        {
            return Connection.Query<T>(sql)
                                 .AsQueryable();
        }
        catch (Exception ex)
        {
            Logger.Error(sql);
            Logger.Error(ex);
        }

        return null;
    }

    public Models.MultiResult<T> QueryMultiple<T>(string sql) where T : Entities.BaseEntity
    {
        var result = new Common.Models.MultiResult<T>();
        try
        {
            using (var reader = Connection.QueryMultiple(sql))
            {
                result.RecordCount = reader.ReadFirst<int>();
                result.Data = reader.Read<T>().ToList();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return result;
    }

    public Models.MultiResult<T> MultiResult<T>(
            string condition,
            int pageSize,
            int pageNo,
            string orderField) where T : Entities.BaseEntity
    {
        var sql = $"Select Count(1) AS RecordCount from {typeof(T).TableName()} WHERE {condition};";
        if (pageSize > 0)
        {
            sql += $"SELECT * FROM {typeof(T).TableName()} WHERE {condition} Order By {orderField} LIMIT {pageSize} Offset {(pageNo - 1) * pageSize};";
        }
        else
        {
            sql += $"SELECT * FROM {typeof(T).TableName()} WHERE {condition} Order By {orderField}";
        }

        var now = DateTime.Now;
        Logger.Info($"sql={sql}");

        var result = QueryMultiple<T>(sql);

        Logger.Info($"{DateTime.Now.Subtract(now).TotalMilliseconds} ms spent. @204");

        return result;
    }

    public DataSet QueryMultipleReader(string sql)
    {
        try
        {
            return Connection.QueryMultiple(sql);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    public void Execute(string sql)
    {
        try
        {
            Connection.Execute(sql);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
    }

    */
}