using System;
using StackExchange.Redis;

namespace Ban3.Particulars.UtilizeRedis.Interfaces;

public interface IKeyAndString
{
    /// <summary>
    /// 发布
    /// </summary>
    /// <param name="channel">发布频道</param>
    /// <param name="obj"></param>
    /// <returns></returns>
    long Publish(string channel, string obj);

    /// <summary>
    /// 订阅
    /// </summary>
    /// <param name="channel">订阅频道</param>
    /// <param name="callBack"></param>
    void Subscribe(string channel, Action<string, string> callBack);

    /// <summary>
    /// 链接测速
    /// </summary>
    /// <returns></returns>
    TimeSpan Ping();

    /// <summary>
    /// 链接？
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool IsConnected(string key);

    /// <summary>
    /// 判断键值存在与否
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool KeyExists(string key);

    /// <summary>
    /// 移除键
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
     bool KeyDelete(string key);

    /// <summary>
    /// 读取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">键名</param>
    /// <returns></returns>
    T? StringGet<T>(string key);

    /// <summary>
    /// 写入
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">键名</param>
    /// <param name="value">键值</param>
    /// <param name="expiryMinutes">过期时间</param>
    /// <returns></returns>
    T StringSet<T>(string key, T value, int expiryMinutes);

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns></returns>
    bool StringDelete(string key);
}

