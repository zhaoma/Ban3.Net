using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// The class represents a property bag as a collection of key-value pairs.
/// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
/// Values of type Byte[], Int32, Double, DateType and String preserve their type,
/// other primitives are retuned as a String. Byte[] expected as base64 encoded string.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#propertiescollection
/// </summary>
public class PropertiesCollection
{
    /// <summary>
    /// The count of properties in the collection.
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("item")]
    public object? Item { get; set; }

    /// <summary>
    /// The set of keys in the collection.
    /// </summary>
    [JsonProperty("keys")]
    public List<string>? Keys { get; set; }

    /// <summary>
    /// The set of values in the collection.
    /// </summary>
    [JsonProperty("values")]
    public Dictionary<string,string>? Values { get; set; }
}