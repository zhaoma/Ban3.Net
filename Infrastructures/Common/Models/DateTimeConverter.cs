//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// Newtonsoft DateTime Converter
/// </summary>
public class DateTimeConverter
    : DateTimeConverterBase
{
    private readonly IsoDateTimeConverter _dtConvertor;

    /// 
    public DateTimeConverter()
    {
        _dtConvertor = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffZ" };
    }

    /// 
    public DateTimeConverter( string? formatter )
    {
        _dtConvertor = new IsoDateTimeConverter { DateTimeFormat = formatter };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="serializer"></param>
    public override void WriteJson( JsonWriter writer, object? value, JsonSerializer serializer )
    {
        _dtConvertor.WriteJson( writer, value, serializer );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="objectType"></param>
    /// <param name="existingValue"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    public override object? ReadJson( JsonReader reader,
                                      Type objectType,
                                      object? existingValue,
                                      JsonSerializer serializer )
    {
        if( existingValue == null ) return null;
        return _dtConvertor.ReadJson( reader, objectType, existingValue, serializer );
    }

    /// 
    public static DateTimeConverter DateOnlyConverter = new( "yyyy-MM-dd" );

    ///
    public static DateTimeConverter YmdConverter = new( "yyyyMMdd" );
}