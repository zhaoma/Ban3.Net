/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            扩展方法定义（Datatables）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Requests.DataTables;
using Microsoft.AspNetCore.Http;

namespace Ban3.Infrastructures.Common.Extensions
{
    /// <summary>
    /// HTML/Datatables相关
    /// </summary>
    public static partial class Converter
    {
        /// <summary>
        /// 处理客户端DataTables请求
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTables ToDataTablesRequest( this IQueryCollection query )
        {
            var request = new DataTables
            {
                    Draw = query[ "draw" ][ 0 ].ToInt(),
                    Start = query[ "start" ][ 0 ].ToInt(),
                    Length = query[ "length" ][ 0 ].ToInt(),
                    Search = new ColumnsSearch
                    {
                            Regex = query[ "search[regex]" ][ 0 ] != "false",
                            Value = query[ "search[value]" ][ 0 ]
                    },
                    OrderBy = new List<Order>()
            };

            var orders = query.Count( o => o.Key.StartsWith( "order" ) ) / 2;
            for( var i = 0; i < orders; i++ )
            {
                request.OrderBy.Add(
                                    new Order
                                    {
                                            Column = query[ $"order[{i}][column]" ][ 0 ].ToInt(),
                                            Dir = query[ $"order[{i}][dir]" ][ 0 ]
                                    } );
            }

            return request;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="entityStruct"></param>
        /// <returns></returns>
        public static List<string> GetDatatablesRow<T>( this T obj, EntityStruct entityStruct )
        {
            var result = new List<string>();
            var showFields = entityStruct.ShowFields();

            foreach( var kv in showFields )
            {
                var p = typeof( T ).GetProperty( kv.Key );
                if( p != null )
                {
                    var val = p.GetValue( obj, null );
                    if( !string.IsNullOrEmpty( kv.Value.FormatPattern ) )
                    {
                        if( p.PropertyType == typeof( DateTime ) )
                        {
                            result.Add( ((DateTime)val).ToString( kv.Value.FormatPattern ) );
                        }

                        if( p.PropertyType == typeof( bool ) )
                        {
                            result.Add( (bool)val ? "<i class='fa fa-check'></i>" : "" );
                        }
                    }
                    else
                    {
                        result.Add( val + "" );
                    }
                }
            }

            var id = typeof( T ).GetProperty( "Id" )
                                ?.GetValue( obj, null );

            result.Add( $"<button r='{id}' o='{typeof( T ).Name}' class='btn btn-info editButton'><i class='fa fa-edit'></i></button> " +
                        $"<button r='{id}' o='{typeof( T ).Name}' class='btn btn-warning deleteButton'><i class='fa fa-minus-square'></i></button>" );

            return result;
        }
    }
}