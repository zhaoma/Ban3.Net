/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（实体）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ban3.Infrastructures.Common.Attributes;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// POCO相关
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T FillFrom<T>( this T obj, object source ) where T : class, new()
        {
            if( source != null )
            {
                PropertyInfo[] pis = typeof( T ).GetProperties();
                PropertyInfo[] pisSource = source.GetType().GetProperties();

                foreach( PropertyInfo pi in pis )
                {
                    try
                    {
                        foreach( var propertyInfo in pisSource )
                        {
                            if( propertyInfo.Name == pi.Name )
                            {
                                object value = propertyInfo.GetValue( source, null );
                                pi.SetValue( obj, value, null );

                                break;
                            }
                        }
                    }
                    catch( Exception ) {}
                }

                return obj;
            }

            return new T();
        }

        /// <summary>
        /// 从FormCollection填充
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        public static T FillFromCollection<T>(this T obj, Dictionary<string, object> formCollection) where T : class, new()
        {
            PropertyInfo[] pis = typeof(T).GetProperties();

            foreach (PropertyInfo pi in pis)
            {
                try
                {
                    if (formCollection[pi.Name] != null)
                    {
                        object value = formCollection[pi.Name] ?? "";

                        if (pi.PropertyType == typeof(int))
                            value = value.ToInt();
                        if (pi.PropertyType == typeof(decimal))
                            value = value.ToDecimal();
                        if (pi.PropertyType == typeof(int?))
                            value = value.ToInt();
                        if (pi.PropertyType == typeof(bool))
                            value = ((value + "") != "false");
                        if (pi.PropertyType == typeof(DateTime))
                            value = value.ToDateTime(DateTime.Now);

                        pi.SetValue(obj, value, null);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }

            return obj;
        }

    }
}