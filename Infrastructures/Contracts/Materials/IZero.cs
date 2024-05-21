//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

[JsonObject(
    ItemNullValueHandling = NullValueHandling.Ignore,
    NamingStrategyType = typeof(CamelCaseNamingStrategy))]
public interface IZero
{
}
