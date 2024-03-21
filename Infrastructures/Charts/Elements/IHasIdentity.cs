// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Elements;

public interface IHasIdentity
{
    /// <summary>
    /// Component ID, not specified by default. If specified, it can be used to refer the component in option or API.
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id { get; set; }

    /// <summary>
    /// Set this to false to prevent the title from showing
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    bool? Show { get; set; }

    /// <summary>
    /// zlevel value of all graphical elements in .
    /// zlevel is used to make layers with Canvas. 
    /// Graphical elements with different zlevel values will be placed in different Canvases, 
    /// which is a common optimization technique. 
    /// We can put those frequently changed elements (like those with animations) to a separate zlevel.
    /// Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
    /// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel.
    /// </summary>
    [JsonProperty("ZLevel", NullValueHandling = NullValueHandling.Ignore)]
    int? ZLevel { get; set; }

    /// <summary>
    /// z value of all graphical elements in , which controls order of drawing graphical components. 
    /// Components with smaller z values may be overwritten by those with larger z values.
    /// z has a lower priority to zlevel, and will not create new Canvas.
    /// </summary>
    [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
    int? Z { get; set; }
}