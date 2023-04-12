/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（字典）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// 字典扩展
    /// </summary>
    public static partial class Helper
    {
        /// 
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(
            this Dictionary<TKey, TValue> dict,
            TKey key,
            TValue value,
            bool replaceExisted = true)
        {
            lock (_objLock)
            {
                if (dict.ContainsKey(key) && replaceExisted)
                {
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
        public static TValue GetValue<TKey, TValue>( this Dictionary<TKey, TValue> dict, TKey key,TValue defaultValue = default(TValue) )
        {
            return dict.ContainsKey( key ) ? dict[ key ] : defaultValue;
        }

        /// 
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>( 
            this Dictionary<TKey, TValue> dict, 
            IEnumerable<KeyValuePair<TKey, TValue>> values,
            bool replaceExisted =true)
        {
            foreach( var item in values )
            {
                dict.AddOrReplace(item.Key,item.Value, replaceExisted);
            }

            return dict;
        }
    }
}