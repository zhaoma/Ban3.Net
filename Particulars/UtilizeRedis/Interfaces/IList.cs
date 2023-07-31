using System;
using System.Collections.Generic;

namespace Ban3.Particulars.UtilizeRedis.Interfaces;

public interface IList
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="value"></param>
    void ListLeftPush<T>(string listKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <returns></returns>
    T ListLeftPop<T>(string listKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="value"></param>
     void ListRightPush<T>(string listKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <returns></returns>
     T ListRightPop<T>(string listKey);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listKey"></param>
    /// <returns></returns>
     int ListLength(string listKey);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <returns></returns>
     List<T> ListRange<T>(string listKey, int start = 0, int stop = -1);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="index"></param>
    /// <returns></returns>
     T ListGetByIndex<T>(string listKey, int index);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="pivot"></param>
    /// <param name="value"></param>
     void ListInsertAfter<T>(string listKey, T pivot, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="pivot"></param>
    /// <param name="value"></param>
     void ListInsertBefore<T>(string listKey, T pivot, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
     bool ListRemove<T>(string listKey, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="listKey"></param>
    /// <param name="index"></param>
    /// <param name="value"></param>
    void ListSetByIndex<T>(string listKey, int index, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listKey"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    void ListTrim(string listKey, int start = 0, int stop = -1);
}

