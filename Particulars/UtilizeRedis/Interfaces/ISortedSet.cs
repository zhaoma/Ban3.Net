using System.Collections.Generic;

namespace Ban3.Particulars.UtilizeRedis.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ISortedSet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <param name="score"></param>
    /// <returns></returns>
    bool SortedSetAdd<T>(string setKey, T value, double score);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    long SortedSetDifference<T>(string first, string second, string destination);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    long SortedSetIntersect<T>(string first, string second, string destination);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    long SortedSetUnion<T>(string first, string second, string destination);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="setKey"></param>
    /// <returns></returns>
    int SortedSetLength(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <returns></returns>
    T SortedSetPop<T>(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <returns></returns>
    List<T> SortedSetRangeByRank<T>(string setKey, int start, int stop);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <returns></returns>
    List<T> SortedSetRangeByScore<T>(string setKey, int start, int stop);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    long? SortedSetRank<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SortedSetRemove<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    double? SortedSetScore<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="pattern"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageNo"></param>
    /// <returns></returns>
    List<T> SortedSetScan<T>(string setKey, string pattern, int pageSize, int pageNo);
}
