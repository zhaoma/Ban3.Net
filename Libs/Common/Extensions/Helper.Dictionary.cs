/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（字典）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 字典扩展
/// </summary>
public static partial class Helper
{
    /// 
    public static TValue GetValue<TKey, TValue>(
        this Dictionary<TKey, TValue> dict,
        TKey key,
        TValue defaultValue = default(TValue))
        => dict.TryGetValue(key, out var result) ? result : defaultValue;

    /// 
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

    /// 
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

    public static Dictionary<string, int> MergeToDictionary(this IEnumerable<IEnumerable<string>> keys)
    {
        var dic = new Dictionary<string, int>();
        foreach (var list in keys)
        {
            dic.AppendKeys(list);
        }

        return dic;
    }

    public static Dictionary<string, int> Merge(this Dictionary<string, int> dic, Dictionary<string, int>? addDic)
    {
        if (addDic != null)
        {

            foreach (var i in addDic)
            {
                if (dic.ContainsKey(i.Key))
                {
                    dic[i.Key] += 1;
                }
                else
                {
                    dic.Add(i.Key, 1);
                }
            }
        }

        return dic;
    }
}