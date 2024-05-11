//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Components;
using Newtonsoft.Json;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public UtilizeJson(ILoggerServer logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public T Create<T>(T entity, Func<T, string> key)
    {
        try
        {
            EntityFolder(entity, key).WriteFile(entity.ObjToJson());
        }catch (Exception ex) { _logger.Error(ex); }

        return entity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public bool Save<T>(string key,string content)
    {
        try
        {
            TypeFolder(typeof(T),()=> key).WriteFile(content);
            return true;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public string Read<T>(string key)
    {
        try
        {
            return TypeFolder(typeof(T), () => key).ReadFile();
        }
        catch (Exception ex) { _logger.Error(ex); }

        return string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public T Update<T>(T entity, Func<T, string> key)
        => Create(entity, key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities"></param>
    /// <param name="key"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public List<T> LoadList<T>(Type type, Func<string>? key = null)
    {
        try
        {
            return TypeFolder(type,key).ReadFileAs<List<T>>()!;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return new List<T>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T Load<T>(string key)
    {
        try
        {
            return TypeFolder(typeof(T), () => key).ReadFileAs<T>()!;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return default!;
    }

    /*
     
    json files storage data not implement below methods.

     */

    /// see interface
    public T Create<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public T Retrieve<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public T Retrieve<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public IEnumerable<T> RetrieveList<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public int Update<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public int Update<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public int Delete<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public int Delete<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<T> CreateAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<T> RetrieveAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<T> RetrieveAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<IEnumerable<T>> RetrieveListAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<int> UpdateAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<int> UpdateAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<int> DeleteAsync<T>(T entity, IDbTransaction? transaction = null)
        => throw new NotImplementedException();

    /// see interface
    public Task<int> DeleteAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null)
        => throw new NotImplementedException();
}
