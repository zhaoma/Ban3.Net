using System.ComponentModel;
using System.Runtime.Serialization;

namespace  Ban3.Infrastructures.Charts.Enums
{
    /// <summary>
    /// To specify how to draw the end points of the line. 
    /// Default value is 'butt'. Refer to MDN lineCap for more details.
    /// </summary>
    public enum BorderCap
    {
        /// <summary>
        /// The ends of lines are squared off at the endpoints.
        /// </summary>
        [Description("butt"), EnumMember(Value = "butt")]
        Butt,

        /// <summary>
        /// The ends of lines are rounded.
        /// </summary>
        [Description("round"), EnumMember(Value = "round")]
        Round,

        /// <summary>
        /// The ends of lines are squared off by adding a box with an equal
        /// width and half the height of the line's thickness.
        /// </summary>
        [Description("square"), EnumMember(Value = "square")]
        Square
    }
}
