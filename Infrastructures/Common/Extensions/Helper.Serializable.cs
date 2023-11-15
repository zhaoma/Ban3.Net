// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 序列化
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static JToken JsonToken( this string json )
        => JToken.Parse( json );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static JObject JsonObject( this string json )
        => JObject.Parse( json );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static object? JsonValue( this string json, string key )
        => json.JsonToken().GetPropertyValue( key );

    /// <summary>
    /// 命名约束
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ObjToJson( this object? obj )
        => JsonConvert.SerializeObject( obj );

    /// <summary>
    /// json转实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="str"></param>
    /// <returns></returns>
    public static T? JsonToObj<T>( this string str )
        =>
            string.IsNullOrEmpty( str )
                ? default( T )
                : JsonConvert.DeserializeObject<T>( str );

    /// <summary>
    /// jsonp
    /// </summary>
    /// <param name="inVal"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public static string JsonpParse( this string inVal, string callback )
        => inVal.Substring( callback.Length + 1, inVal.Length - callback.Length - 3 );

    /// <summary>
    /// Serializes the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static byte[] Serialize( this object value )
    {
        using var ms = new MemoryStream();

        var bf1 = new BinaryFormatter();

        bf1.Serialize( ms, value );

        return ms.ToArray();
    }

    /// <summary>
    /// Serializes the XML.
    /// </summary>
    /// <param name="o">The o.</param>
    /// <returns></returns>
    public static string SerializeXml( this object o )
    {
        var serializer = new XmlSerializer( o.GetType() );

        var ns = new XmlSerializerNamespaces();

        ns.Add( "", "" );

        using var stream = new MemoryStream();

        var setting = new XmlWriterSettings { Encoding = new UTF8Encoding( false ), Indent = true };

        using var textWriter = XmlWriter.Create( stream, setting );

        serializer.Serialize( textWriter, o, ns );

        return Encoding.UTF8.GetString( stream.ToArray() );
    }

    /// <summary>
    /// Deserializes the XML.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    public static T DeserializeXml<T>( this string xml )
    {
        return (T)Deserialize( xml, typeof( T ) );
    }

    /// <summary>
    /// Deserializes the specified XML.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    public static object Deserialize( string xml, Type type )
    {
        var serializer = new XmlSerializer( type );
        using TextReader textReader = new StringReader( xml );
        var o = serializer.Deserialize( textReader );
        return o;
    }

    /// <summary>
    /// 尝试读取属性值
    /// </summary>
    /// <param name="node"></param>
    /// <param name="attributeName"></param>
    /// <returns></returns>
    public static string TryGetAttribute( this XmlNode node, string attributeName )
    {
        try
        {
            if( node.Attributes is { Count: > 0 } )
            {
                if( node.Attributes.Cast<XmlAttribute>().Any( nodeAttributes => nodeAttributes.Name == attributeName ) )
                {
                    return node.Attributes[ attributeName ].Value;
                }
            }
        }
        catch( Exception ex )
        {
            Logger.Error( ex );
        }

        return string.Empty;
    }
}