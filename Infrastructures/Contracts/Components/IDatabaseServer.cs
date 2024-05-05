//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Components;

/// <summary>
/// 数据持久化服务
/// </summary>
public interface IDatabaseServer
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    T Create<T>(T entity, Func<T, string> key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    T Update<T>(T entity, Func<T, string> key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Delete<T>(T entity, Func<T, string> key);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entities"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    bool SaveList<T>( List<T> entities, Func<string>? key=null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    List<T> LoadList<T>(Type type, Func<string>? key=null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    T Load<T>(string key);

    /// <summary>
    /// 创建记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    T Create<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 检索记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    T Retrieve<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 检索记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    T Retrieve<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 查询记录集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    IEnumerable<T> RetrieveList<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    int Update<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    int Update<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    int Delete<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    int Delete<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<T> CreateAsync<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<T> RetrieveAsync<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<T> RetrieveAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> RetrieveListAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<int> UpdateAsync<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<int> UpdateAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<int> DeleteAsync<T>(T entity, IDbTransaction? transaction = null);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="conditionOrSql"></param>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task<int> DeleteAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);
}
