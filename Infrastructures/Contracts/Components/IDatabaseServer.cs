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
    T Create<T>(T entity, Func<T, string> key);

    T Update<T>(T entity, Func<T, string> key);

    bool Delete<T>(T entity, Func<T, string> key);

    bool SaveList<T>( List<T> entities, Func<string>? key=null);

    List<T> LoadList<T>(Type type, Func<string>? key=null);

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

    Task<T> CreateAsync<T>(T entity, IDbTransaction? transaction = null);

    Task<T> RetrieveAsync<T>(T entity, IDbTransaction? transaction = null);

    Task<T> RetrieveAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    Task<IEnumerable<T>> RetrieveListAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    Task<int> UpdateAsync<T>(T entity, IDbTransaction? transaction = null);

    Task<int> UpdateAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);

    Task<int> DeleteAsync<T>(T entity, IDbTransaction? transaction = null);

    Task<int> DeleteAsync<T>(T entity, string conditionOrSql, IDbTransaction? transaction = null);
}
