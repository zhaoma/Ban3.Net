/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（字典）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using System.Linq;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 字典扩展
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 字典取值
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dict">字典</param>
    /// <param name="key">键</param>
    /// <param name="defaultValue">默认值</param>
    /// <returns></returns>
    public static TValue GetValue<TKey, TValue>(
        this Dictionary<TKey, TValue> dict,
        TKey key,
        TValue defaultValue)
        => dict.TryGetValue(key, out var result) ? result : defaultValue;

    /// <summary>
    /// 字典添加项(可以保留原有项)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dict"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="replaceExisted"></param>
    /// <returns></returns>
    public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(
        this Dictionary<TKey, TValue> dict,
        TKey key,
        TValue value,
        bool replaceExisted = true)
    {
        lock (ObjLock)
        {
            if (dict.ContainsKey(key))
            {
                if (replaceExisted)
                    dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        return dict;
    }

    /// <summary>
    /// 字典添加键值对列表(可以保留原有项)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dict">字典</param>
    /// <param name="values">键值对列表</param>
    /// <param name="replaceExisted">替换原有项</param>
    /// <returns></returns>
    public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(
        this Dictionary<TKey, TValue> dict,
        IEnumerable<KeyValuePair<TKey, TValue>> values,
        bool replaceExisted = true)
    {
        foreach (var item in values)
        {
            dict.AddOrReplace(item.Key, item.Value, replaceExisted);
        }

        return dict;
    }
    
    /// <summary>
    /// 字典键计数
    /// </summary>
    /// <param name="dic">字典</param>
    /// <param name="keys">键集合</param>
    public static void AppendKeys(this Dictionary<string, int> dic, IEnumerable<string> keys)
    {
        foreach (var o in keys)
        {
            if (dic.ContainsKey(o))
            {
                dic[o] += 1;
            }
            else
            {
                dic.Add(o, 1);
            }
        }
    }

    /// <summary>
    /// 键集合列表合并成键字典
    /// </summary>
    /// <param name="keys">键集合列表</param>
    /// <returns></returns>
    public static Dictionary<string, int> MergeToDictionary(this IEnumerable<IEnumerable<string>> keys)
    {
        var dic = new Dictionary<string, int>();
        foreach (var list in keys)
        {
            dic.AppendKeys(list);
        }

        return dic;
    }

    /// <summary>
    /// 键字典合并
    /// </summary>
    /// <param name="dic">目标字典</param>
    /// <param name="addDic">新增字典</param>
    /// <returns></returns>
    public static Dictionary<string, int> Merge(this Dictionary<string, int> dic, Dictionary<string, int>? addDic)
    {
        if (addDic != null)
        {

            foreach (var i in addDic)
            {
                if (dic.ContainsKey(i.Key))
                {
                    dic[i.Key] += i.Value;
                }
                else
                {
                    dic.Add(i.Key, i.Value);
                }
            }
        }

        return dic;
    }


    /// <summary>
    /// 字典追加值集合
    /// </summary>
    /// <typeparam name="TK"></typeparam>
    /// <typeparam name="TV"></typeparam>
    /// <param name="result">字典</param>
    /// <param name="key">键</param>
    /// <param name="values">值集合</param>
    public static void Append<TK, TV>(this Dictionary<TK, List<TV>> result, TK key, List<TV> values)
    {
        if (result.ContainsKey(key))
        {
            result[key] = result[key].Union(values).ToList();
        }
        else
        {
            result.Add(key, values);
        }
    }

    /// <summary>
    /// 字典追加键集合
    /// </summary>
    /// <param name="result">字典</param>
    /// <param name="keys">键集合</param>
    /// <param name="value">值</param>
    public static void Append(this Dictionary<string, List<string>> result, List<string> keys, string value)
    {
        keys.ForEach(key =>
        {
            if (!string.IsNullOrEmpty(key))
            {
                if (result.ContainsKey(key))
                {
                    result[key] = result[key].Union(new List<string> { value }).ToList();
                }
                else
                {
                    result.Add(key, new List<string> { value });
                }
            }
        });
    }

}