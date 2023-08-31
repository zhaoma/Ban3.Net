using System.ComponentModel;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Charts.Enums;

/// <summary>
/// To determine the shape used to join two line segments where they meet.
/// </summary>
public enum BorderJoin
{
    /// <summary>
    /// Fills an additional triangular area between the common endpoint of connected segments, 
    /// and the separate outside rectangular corners of each segment.
    /// </summary>
    [Description("bevel"), EnumMember(Value = "bevel")]
    Bevel,

    /// <summary>
    /// Rounds off the corners of a shape by filling an additional sector of disc centered 
    /// at the common endpoint of connected segments. 
    /// The radius for these rounded corners is equal to the line width.
    /// </summary>
    [Description("round"), EnumMember(Value = "round")]
    Round,

    /// <summary>
    /// Connected segments are joined by extending their outside edges to connect at a single point, 
    /// with the effect of filling an additional lozenge-shaped area. 
    /// This setting is affected by the borderMiterLimit property.
    /// </summary>
    [Description("miter"), EnumMember(Value = "miter")]
    Miter
}