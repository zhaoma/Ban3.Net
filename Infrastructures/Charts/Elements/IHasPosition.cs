//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Elements;

/// <summary>
/// 
/// </summary>
public interface IHasPosition
{
    /// <summary>
    /// Distance between title component and the left side of the container.
    /// left value can be instant pixel value like 20; 
    /// it can also be a percentage value relative to container width like '20%'; 
    /// and it can also be 'left', 'center', or 'right'.
    /// If the left value is set to be 'left', 'center', or 'right', 
    /// then the component will be aligned automatically based on position.
    /// </summary>
    [JsonProperty("left", NullValueHandling = NullValueHandling.Ignore)]
    object? Left { get; set; }

    /// <summary>
    /// top value can be instant pixel value like 20; 
    /// it can also be a percentage value relative to container width like '20%'; 
    /// and it can also be 'top', 'middle', or 'bottom'.
    /// If the top value is set to be 'top', 'middle', or 'bottom', 
    /// then the component will be aligned automatically based on position.
    /// </summary>
    [JsonProperty("top", NullValueHandling = NullValueHandling.Ignore)]
    object? Top { get; set; }

    /// <summary>
    /// Distance between title component and the right side of the container.
    /// right value can be instant pixel value like 20; 
    /// it can also be a percentage value relative to container width like '20%'.
    /// Adaptive by default.
    /// </summary>
    [JsonProperty("right", NullValueHandling = NullValueHandling.Ignore)]
    object? Right { get; set; }

    /// <summary>
    /// Distance between title component and the bottom side of the container.
    /// bottom value can be instant pixel value like 20; 
    /// it can also be a percentage value relative to container width like '20%'.
    /// Adaptive by default.
    /// </summary>
    [JsonProperty("bottom", NullValueHandling = NullValueHandling.Ignore)]
    object? Bottom { get; set; }

    /// <summary>
    /// Width of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    object? Width { get; set; }

    /// <summary>
    /// Height of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    object? Height { get; set; }
}