using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common.Extensions.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class DateOnlyConverter:DateTimeConverterBase
    {
        private static IsoDateTimeConverter dtConvertor = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            dtConvertor.WriteJson(writer, value, serializer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return dtConvertor.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
