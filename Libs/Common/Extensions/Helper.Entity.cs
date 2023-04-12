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
        /// 按策略属性获取表名
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static string TableName( this Type tp )
        {
            return tp.TableStrategy()?.TableName??tp.Name;
        }

        /// <summary>
        /// 策略属性
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static TableStrategyAttribute TableStrategy( this Type tp )
        {
            var key = $"${tp.Name}.TableStrategy";
            var cachedColumns = key.LoadFromMemoryCache();
            if( !string.IsNullOrEmpty( cachedColumns ) )
                return cachedColumns.JsonToObj<TableStrategyAttribute>();

            var props = tp.GetCustomAttributes( true );
            if( props != null && props.Any() && props.Any( o => o is TableStrategyAttribute ) )
            {
                var ts = props.First( o => o is TableStrategyAttribute ) as TableStrategyAttribute;
                key.AppendToMemoryCacheOneDay( ts.ObjToJson() );
                return ts;
            }

            return new TableStrategyAttribute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static Dictionary<string, FieldAttribute> Columns( this Type tp )
        {
            var key = $"{tp.Name}.Columns";
            var cachedColumns = key.LoadFromMemoryCache();
            if( !string.IsNullOrEmpty( cachedColumns ) )
                return cachedColumns.JsonToObj<Dictionary<string, FieldAttribute>>();

            var props = tp.GetPublicProperties();
            if( props != null )
            {
                var kvs = new Dictionary<string, FieldAttribute>();

                foreach( var p in props )
                {
                    var attributes = p.GetCustomAttributes( true );
                    if( attributes != null && attributes.Any() && attributes.Any( o => o is FieldAttribute ) )
                    {
                        var attr = attributes.First( o => o is FieldAttribute ) as FieldAttribute;
                        attr.TypeName = p.PropertyType.Name;

                        kvs.Add( p.Name, attr );
                    }
                }

                key.AppendToMemoryCacheOneDay( kvs.ObjToJson() );
                return kvs;
            }

            return new Dictionary<string, FieldAttribute>();
        }

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