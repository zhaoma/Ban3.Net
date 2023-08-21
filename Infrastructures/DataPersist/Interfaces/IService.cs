using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

namespace Ban3.Infrastructures.DataPersist.Interfaces;

/// 
public interface IService
{
    /// <summary>
    /// 
    /// </summary>
    IDbConnection Connection { get;}

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    T Save<T>(object id, T t) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    void BulkSave<T>(Dictionary<string, T> data) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    void TupleSave<T>(IEnumerable<Tuple<string, string, T>> data) where T : Entities.BaseEntity;

    /// <summary>
    /// 插入记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    T Insert<T>(object id, T t) where T : Entities.BaseEntity;

    /// <summary>
    /// 获取记录（用主键）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    T Get<T>(object id) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Exists<T>(object id) where T : Entities.BaseEntity;

    /// 
    bool NotExists<T>(string condition) where T : Entities.BaseEntity;

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    T Update<T>(object id, T t) where T : Entities.BaseEntity;

    /// <summary>
    /// 删除记录（用主键）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete<T>(object id) where T : Entities.BaseEntity;

    /// <summary>
    /// 获取全部数据集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IQueryable<T> Set<T>() where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="condition"></param>
    /// <returns></returns>
    IQueryable<T> Set<T>(string condition) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sql"></param>
    /// <returns></returns>
    Models.MultiResult<T> QueryMultiple<T>(string sql) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="condition"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageNo"></param>
    /// <param name="orderField"></param>
    /// <returns></returns>
    Models.MultiResult<T> MultiResult<T>(
            string condition,
            int pageSize,
            int pageNo,
            string orderField
    ) where T : Entities.BaseEntity;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    DataSet QueryMultipleReader(string sql);

    /// 
    void Execute(string sql);
}