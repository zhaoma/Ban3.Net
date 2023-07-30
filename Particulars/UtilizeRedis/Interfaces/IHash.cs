using System;
using System.Collections.Generic;

namespace Ban3.Particulars.UtilizeRedis.Interfaces;

public interface IHash
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <returns></returns>
     long HashDecrement(string hashKey, string hashField);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <returns></returns>
     bool HashDelete(string hashKey, string hashField);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <returns></returns>
     bool HashExists(string hashKey, string hashField);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <returns></returns>
     T HashGet<T>(string hashKey, string hashField);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <returns></returns>
     List<KeyValuePair<string, T>> HashGetAll<T>(string hashKey);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <returns></returns>
     long HashIncrement(string hashKey, string hashField);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hashKey"></param>
    /// <returns></returns>
     int HashLength(string hashKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <param name="pattern"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageNo"></param>
    /// <returns></returns>
     List<KeyValuePair<string, T>> HashScan<T>(string hashKey, string pattern, int pageSize, int pageNo);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <param name="kvs"></param>
     void HashSet<T>(string hashKey, List<KeyValuePair<string, T>> kvs);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <param name="hashField"></param>
    /// <param name="value"></param>
     void HashSet<T>(string hashKey, string hashField, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hashKey"></param>
    /// <returns></returns>
     List<T> HashValues<T>(string hashKey);
}

