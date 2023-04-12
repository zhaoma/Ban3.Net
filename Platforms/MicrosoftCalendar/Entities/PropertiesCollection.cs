using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities
{
    /// <summary>
    /// The class represents a property bag as a collection of key-value pairs.
    /// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
    /// Values of type Byte[], Int32, Double, DateType and String preserve their type,
    /// other primitives are retuned as a String. Byte[] expected as base64 encoded string.
    /// </summary>
    public class PropertiesCollection
    {
        /// <summary>
        /// The count of properties in the collection.
        /// </summary>
        [JsonProperty( "count" )]
        public int Count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty( "item" )]
        public Object Item { get; set; }

        /// <summary>
        /// The set of keys in the collection.
        /// </summary>
        [JsonProperty( "keys" )]
        public string[] Keys { get; set; }

        /// <summary>
        /// The set of values in the collection.
        /// </summary>
        [JsonProperty( "values" )]
        public string[] Values { get; set; }
    }
}