//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.DatabaseServer;

/// <summary>
/// 使用json文件实现数据储存组件
/// </summary>
public class UtilizeJson : IDatabaseServer
{
    private readonly ILoggerServer _logger;
    private string EntityFolder<T>(T entity, Func<T, string> key)
        => TypeFolder(typeof(T), () => key(entity));

    private string TypeFolder(Type type, Func<string>? key = null)
    {
        var folder = Path.Combine(Infrastructures.Common.Config.LocalStorage?.RootPath, type.Name);
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        var fullPath= key == null
            ? Path.Combine(folder, "all.json")
            : Path.Combine(folder, $"{key()}.json");

        return fullPath;
    }

    public UtilizeJson(ILoggerServer logger)
    {
        _logger = logger;
    }

    public T Create<T>(T entity, Func<T, string> key)
    {
        try
        {
            EntityFolder(entity, key).WriteFile(entity.ObjToJson());
        }catch (Exception ex) { _logger.Error(ex); }

        return entity;
    }

    public T Update<T>(T entity, Func<T, string> key)
        => Create(entity, key);

    public bool Delete<T>(T entity, Func<T, string> key)
    {
        try
        {
            File.Delete(EntityFolder(entity, key));
            return true;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    public bool SaveList<T>(List<T> entities, Func<string>? key = null)
    {
        try
        {
            TypeFolder(typeof(T), key)
        .WriteFile(entities.ObjToJson());
            return true;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    public List<T> LoadList<T>(Type type, Func<string>? key = null)
    {
        try
        {
            return TypeFolder(type,key).ReadFileAs<List<T>>()!;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return new List<T>();
    }

    public T Load<T>(string key)
    {
        try
        {
            return TypeFolder(typeof(T),()=> key).ReadFileAs<T>()!;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return default(T);
    }

    /*
     
    json files storage data not implement below methods.

     */

    public T Create<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public T Retrieve<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public T Retrieve<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public IEnumerable<T> RetrieveList<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public int Update<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public int Update<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public int Delete<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public int Delete<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<T> CreateAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<T> RetrieveAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<T> RetrieveAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<IEnumerable<T>> RetrieveListAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<int> UpdateAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<int> UpdateAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<int> DeleteAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    public Task<int> DeleteAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();
}
