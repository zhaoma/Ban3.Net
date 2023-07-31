using System.Collections.Generic;

namespace Ban3.Particulars.UtilizeRedis.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ISet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetAdd<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetAdd<T>(string setKey, List<T> value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    List<T> SetDifference<T>(string first, string second);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    List<T> SetIntersect<T>(string first, string second);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKeys"></param>
    /// <returns></returns>
    List<T> SetMerge<T>(List<string>? setKeys);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    List<T> SetUnion<T>(string first, string second);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetContains<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="setKey"></param>
    /// <returns></returns>
    int SetLength(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <returns></returns>
    List<T> SetMembers<T>(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetMove<T>(string source, string destination, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <returns></returns>
    T SetPop<T>(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="setKey"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    IEnumerable<string> SetPop(string setKey, int count);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <returns></returns>
    T SetRandomMember<T>(string setKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    List<T> SetRandomMembers<T>(string setKey, int count);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetRemove<T>(string setKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="setKey"></param>
    /// <param name="pattern"></param>
    /// <param name="pageSize"></param>
    /// <param name="pageNo"></param>
    /// <returns></returns>
    List<T> SetScan<T>(string setKey, string pattern, int pageSize, int pageNo);
}