//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/30 10:01
//  function:	GeneralAxis.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Lines;
using  Ban3.Infrastructures.Charts.Labels;

using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Elements
{
    public class GeneralAxis
        : IHasIdentity, IAxis, IHasAxisName
    {
        public GeneralAxis()
        {
        }

        #region IHasIdentity

        /// 
        public string? Id { get; set; }

        /// 
        public bool? Show { get; set; }

        /// 
        public int? ZLevel { get; set; }

        /// 
        public int? Z { get; set; }

        #endregion

        #region IHasAxis

        /// 
        public ECharts.AxisType? Type { get; set; }

        /// 
        public object? BoundaryGap { get; set; } 

        /// 
        public object? Min { get; set; }

        ///
        public object? Max { get; set; }

        ///
        public bool? Scale { get; set; }

        /// 
        public int? SplitNumber { get; set; } 

        /// 
        public int? MinInterval { get; set; }

        ///
        public int? MaxInterval { get; set; }

        ///
        public object? Interval { get; set; }

        ///
        public int? LogBase { get; set; } 

        ///
        public bool? Silent { get; set; }

        ///
        public bool? TriggerEvent { get; set; }

        ///
        public AxisLine? AxisLine { get; set; }

        ///
        public AxisTick? AxisTick { get; set; }

        ///
        public MinorTick? MinorTick { get; set; }

        ///
        public AxisLabel? AxisLabel { get; set; }

        ///
        public SplitLine? SplitLine { get; set; }

        ///
        public MinorSplitLine? MinorSplitLine { get; set; }

        ///
        public SplitArea? SplitArea { get; set; }

        ///
        public object? Data { get; set; }

        ///
        public Cogs.AxisPointer? AxisPointer { get; set; }

        ///
        public bool? Inverse { get; set; }

        #endregion

        #region IHasAxisName

        ///
        public string? Name { get; set; } 

        /// 
        public ECharts.Position? NameLocation { get; set; }

        /// 
        public TextStyle? NameTextStyle { get; set; }

        /// 
        public int? NameGap { get; set; } 

        /// 
        public int? NameRotate { get; set; }

        #endregion
    }
}

